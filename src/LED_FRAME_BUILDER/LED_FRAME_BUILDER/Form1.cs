using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace LED_FRAME_BUILDER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            build_color_table();
        }


        List<Color> colors = new List<Color>();
        Color current_chosen_color = new Color();


        struct layer
        {
           public  int[,] matrix_cid;
           public string layer_name;
            public int visibilty;
            public int delay;
        }

        List<layer> layers = new List<layer>();
        
        int matrix_size_w = 0;
        int matrix_size_h = 0;
        int current_chosen_color_id = 0;
        int current_selected_layer = 0;
        const int clear_color_id = 0;
        int last_selected_layer = 0;


        private void build_color_table()
        {
            //TODO load from color table file ->input excel string

            colors.Clear();
            try
            {
                //TODO REMOVE THE TRY SHIT
                StreamReader sra = File.OpenText("COLORS.csv");
                sra.Close();
            }
            catch (Exception)
            {
                FileStream sw = File.Create("COLORS.csv");
              MessageBox.Show("basic_color_table.csv could not be found a simple colortable was created");
               //TODO ADD SAMPLE COLORS SIME R G B WHITE BLACK
                sw.Close();

                System.IO.File.WriteAllText("COLORS.csv", "0;0;0;\n255;0;0;\n0;255;0;\n0;0;255;\n");
            //    return;
            }
            StreamReader sr = File.OpenText("COLORS.csv");
            int count = 0;
            while (true)
            {
                string read_string = sr.ReadLine();
                if(read_string == "")
                {
                    break;
                }
                string[] sp_read = read_string.Split(';');
                Color tmc;
                try
                { 
                    int tmp = int.Parse(sp_read[2]);
                }
                catch (Exception)
                {
                    continue;
                }
                tmc = Color.FromArgb(int.Parse(sp_read[0]), int.Parse(sp_read[1]), int.Parse(sp_read[2]));
                colors.Add(tmc);
                count++;
                if (sr.EndOfStream) { break; }
            }
            sr.Close();
            int color_pw = color_chooser.Size.Width / 32;
            int color_ph = colors.Count / color_pw;
            color_chooser.Controls.Clear();
            for (int i = 0; i < colors.Count; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Name = "colorpick_" + i.ToString();
                pic.Size = new Size(32, 32);
                pic.BackColor = colors[i];
                int row_mult = 0;
                if (color_ph > 0)
                {
                     row_mult = (i / color_ph);
                }
                pic.Location = new Point((i % color_pw)*32, row_mult * 32);
                pic.Click += click_color;

                color_chooser.Controls.Add(pic);
            }
        }

private bool AreColorsSimilar(Color c1, Color c2, int tolerance)
 {
             return Math.Abs(c1.R - c2.R) < tolerance && Math.Abs(c1.G - c2.G) < tolerance && Math.Abs(c1.B - c2.B) < tolerance;
 }
        private void export_layers()
        {
            //get sel layer coutn
            saveFileDialog1.Filter = "FRAME_BUIDER_ANIMATION_FILE (.ANI) | *.ANI";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                if (!saveFileDialog1.CheckPathExists)
                {
                    MessageBox.Show("EXPORT FAILED - path does not exits");
                    return;
                }

               


               if (exp_layer_cboxlist.CheckedItems.Count <= 0)
            {
                MessageBox.Show("EXPORT FAILED - PLEASE SELECTE A LAYER TO EXPORT");
                return;
            }
            if (exp_layer_cboxlist.CheckedItems.Count > layers.Count)
            {
                MessageBox.Show("EXPORT FAILED - INTERNAL ERROR");
                return;
            }

            string matrix_data = "";
            for (int i = 0; i < exp_layer_cboxlist.CheckedItems.Count; i++)
            {
                matrix_data += "FRAME_" + i.ToString() + "_"+ exp_layer_cboxlist.CheckedItems.Count + "_" + matrix_size_w.ToString() + "_" + matrix_size_h.ToString() + "_" + (int)layers[exp_layer_cboxlist.CheckedIndices[i]].visibilty + "_" + (int)layers[exp_layer_cboxlist.CheckedIndices[i]].delay + "_" + "\n";
                int layer_id = 0;
               
                for (int x = 0; x < matrix_size_w; x++)
                {
                    for (int y = 0; y < matrix_size_h; y++)
                    {
                        matrix_data += layers[exp_layer_cboxlist.CheckedIndices[i]].matrix_cid[x, y].ToString() + ",";
                    }
                    matrix_data += "\n";
                }
                matrix_data += "\n";
            }
           
                System.IO.File.WriteAllText(saveFileDialog1.FileName.ToUpper(), matrix_data);



                //NOW EXPORT COLOR TABLE
                try
                {
                    FileStream fileStream = File.Open("COLORS.csv", FileMode.Open);
                    fileStream.SetLength(0);
                    fileStream.Flush();
                    string color_text = "";
                    //CREATE COLOR TABLE
                    for (int i = 0; i < colors.Count; i++)
                    {
                        color_text += colors[i].R.ToString() + ";" + colors[i].G.ToString() + ";" + colors[i].B.ToString() +";" + "\n";
                    }
                    char[] bla= color_text.ToCharArray();

                    fileStream.Write(Encoding.UTF8.GetBytes(bla), 0, Encoding.UTF8.GetByteCount(bla));
                    fileStream.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("EXPORT FAILED - COLORS.csv cant export");
                    return;
                }


                int bytes_table = (1 * matrix_size_h * matrix_size_w * exp_layer_cboxlist.CheckedItems.Count) + (7* exp_layer_cboxlist.CheckedItems.Count);
                int bytes_color = 3 * colors.Count;

                MessageBox.Show("BYTES FOR FRAMES : " + bytes_table.ToString() + " BYTES FOR COLOR TABLE: " + bytes_color.ToString() + " = " + (bytes_color + bytes_table).ToString() + " .");
            }
            else
            {
                MessageBox.Show("EXPORT FAILED");
            }
        }
        private void import_layers()
        {
            layers.Clear();
            layers_listbox.Items.Clear();



            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "FRAME_BUIDER_ANIMATION_FILE (.ANI) | *.ANI";
            int frame_counter = 0;
            int frame_id = 0;


            int coll_counter = 0;
            layer tmp_layer;
            tmp_layer = new layer();
            tmp_layer.matrix_cid = new int[1, 1];


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                StreamReader sr = File.OpenText(openFileDialog1.FileName);


                //first array
                string[] lines;
                string read_all = sr.ReadToEnd();
                lines = read_all.Split('\n');

                //Get frame size
                int frame_size_w = 0;
                int frame_size_h = 0;
                int delay = 500;
                int visi = 255;
                for (int i = 0; i < lines.Length; i++)
                {

                    if (lines[i].Contains("FRAME_"))
                    {
                        frame_counter++;
                        string[] split_content = lines[i].Split('_');
                        frame_id = int.Parse(split_content[1]);
                        int t_frame_size_w = int.Parse(split_content[3]);
                        int t_frame_size_h = int.Parse(split_content[4]);
                        visi = int.Parse(split_content[5]);
                        delay = int.Parse(split_content[6]);
                        if(t_frame_size_w > frame_size_w)
                        {
                            frame_size_w = t_frame_size_w;
                        }
                        if (t_frame_size_h > frame_size_h)
                        {
                            frame_size_h = t_frame_size_h;
                        }

                    }
                }
                   
              
                if(frame_size_h <= 0 || frame_size_w <= 0)
                {
                    MessageBox.Show("IMPORT FAILED -> FILE FRAME_SIZE INVALID");
                    return;
                }


                tmp_layer = new layer();
                tmp_layer.delay = delay;
                tmp_layer.visibilty = visi;
                tmp_layer.matrix_cid = new int[frame_size_w, frame_size_h];
                int frame_curr_counter = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(','))
                    {
                        string[] split_col = lines[i].Split(',');
                        for (int j = 0; j < split_col.Length; j++)
                        {
                            if(split_col[j] == "")
                            {
                               coll_counter++;
                                break;
                            }
                            tmp_layer.matrix_cid[ coll_counter,j] = int.Parse(split_col[j]);
                        }
                    }
                    else if(lines[i] == "")
                    {
                        //reset col counter
                        coll_counter = 0;
                        tmp_layer.layer_name = "layer_" + frame_curr_counter.ToString();
                       
                        layers.Add(tmp_layer);
                        tmp_layer = new layer();
                        tmp_layer.matrix_cid = new int[frame_size_w, frame_size_h];
                        frame_curr_counter++;

                    }
                }


                for (int i = 0; i < layers.Count; i++)
                {
                    layers_listbox.Items.Add(layers[i].layer_name);
                }
                //ADD PICTURE BOX MATRIX
                matrix_panel.Controls.Clear();
                int mw_pixel = matrix_panel.Size.Width / (int)matrix_size_widht.Value;
                int mh_pixel = matrix_panel.Size.Height / (int)matrix_size_height.Value;
                matrix_size_w = (int)matrix_size_widht.Value;
                matrix_size_h = (int)matrix_size_height.Value;
                for (int i = 0; i < (int)matrix_size_widht.Value; i++)
                {
                    for (int j = 0; j < (int)matrix_size_height.Value; j++)
                    {
                        PictureBox tmp = new PictureBox();
                        tmp.Size = new Size(mw_pixel, mh_pixel);
                        tmp.Location = new Point(i * mw_pixel, j * mh_pixel);
                        tmp.Name = "mcell_" + i.ToString() + "_" + j.ToString();
                        tmp.BackColor = colors[ layers[0].matrix_cid[i, j]];
                        matrix_panel.Controls.Add(tmp);
                        tmp.Click += click_cell;
                    }
                }
                current_selected_layer = 0;
                last_selected_layer = 0;
                //CREATE NEW PICTUREBOX MATRIX
                //FILE ITEM BOX

            }
            else
            {
                MessageBox.Show("IMPORT FAILED OPEN FILE DIALOG ERROR");
                return;
            }
        }

        private void new_sheet()
        {
            set_matrix_size_btn_Click(null, null);
            neuToolStripMenuItem.Enabled = false;
        }

        private void set_matrix_size_btn_Click(object sender, EventArgs e)
        {
            //set_matrix_size_btn.Enabled = false;
            matrix_panel.Controls.Clear();
          //  matrix_color_ids = new int[(int)matrix_size_widht.Value,(int)matrix_size_height.Value];
            int mw_pixel = matrix_panel.Size.Width / (int)matrix_size_widht.Value;
            int mh_pixel = matrix_panel.Size.Height / (int)matrix_size_height.Value;
            matrix_size_w = (int)matrix_size_widht.Value;
            matrix_size_h = (int)matrix_size_height.Value;

            //CREATE LAYER
            layer first_layer = new layer();
            first_layer.layer_name = "<invalid_layer>";
            first_layer.matrix_cid = new int[(int)matrix_size_widht.Value, (int)matrix_size_height.Value];

            for (int i = 0; i < (int)matrix_size_widht.Value; i++)
            {
                for (int j = 0; j < (int)matrix_size_height.Value; j++)
                {
                    PictureBox tmp = new PictureBox();
                    tmp.Size = new Size(mw_pixel, mh_pixel);
                    tmp.Location = new Point(i * mw_pixel, j* mh_pixel);
                    tmp.Name = "mcell_" + i.ToString() + "_" + j.ToString();
                    tmp.BackColor = colors[clear_color_id];
                    matrix_panel.Controls.Add(tmp);
                    tmp.Click += click_cell;
                  //  first_layer.ref_box = tmp;
                    first_layer.matrix_cid[i, j] = clear_color_id;
                }
            }
            first_layer.layer_name =  "frame_" + layers.Count().ToString();
            first_layer.visibilty = 255;
            layer_visible_up.Value = 255;
            first_layer.delay = 100;
            layer_delay_ud.Value = 100;
            layers.Add(first_layer);

            layers_listbox.Items.Add(first_layer.layer_name);
            layers_listbox.SelectedIndex = 0;
            exp_layer_cboxlist.Items.Add(first_layer.layer_name, true);
        }
        private void click_cell(object sender, EventArgs e) //EVENT
        {
            PictureBox p = (PictureBox)sender;
            if (p != null)
            {
                p.BackColor = current_chosen_color;
                int pos_w = int.Parse(p.Name.Split('_')[1]);
                int pos_h = int.Parse(p.Name.Split('_')[2]);
                layers[current_selected_layer].matrix_cid[pos_w, pos_h] = current_chosen_color_id;
            }
        }
        private void click_color(object sender, EventArgs e) //EVENT
        {
            PictureBox p = (PictureBox)sender;
            if (p != null)
            {
                current_chosen_color = p.BackColor;
                current_chosen_color_id = int.Parse(p.Name.Split('_')[1]); // LOL
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // if(matrix_color_ids.Length() > 0){
                for (int i = 0; i < (int)matrix_size_widht.Value; i++)
                {
                    for (int j = 0; j < (int)matrix_size_height.Value; j++)
                    {
                         layers[current_selected_layer].matrix_cid[i, j] = clear_color_id;
                    }
                }
            //}
            //CLEAR ALL PICURE BOXES
            for (int i = 0; i < matrix_panel.Controls.Count; i++)
            {
                //TODO ADD TYPECHECK
                  PictureBox p = (PictureBox)matrix_panel.Controls[i];
                if(p != null)
                {
                    p.BackColor = colors[clear_color_id];
                }
            }
        }
        //ADD FRAME BTN
        private void button2_Click(object sender, EventArgs e)
        {
            last_selected_layer = current_selected_layer;
            layer tmp_layer = new layer();
            tmp_layer.layer_name = "frame_" + layers.Count.ToString();
            tmp_layer.visibilty = 255;
            tmp_layer.delay = 100;
            layer_delay_ud.Value = 100;
            layer_visible_up.Value = 255;
            tmp_layer.matrix_cid = new int[(int)matrix_size_widht.Value, (int)matrix_size_height.Value];
            layers.Add(tmp_layer);
            layers_listbox.Items.Add(tmp_layer.layer_name);
            layers_listbox.SelectedItem = tmp_layer.layer_name;
            exp_layer_cboxlist.Items.Add(tmp_layer.layer_name, true);
           
            current_selected_layer = layers.Count-1;

            if (copy_frame_data_chbx.Checked)
            {
                tmp_layer.visibilty = layers[last_selected_layer].visibilty;
                for (int i = 0; i < (int)matrix_size_widht.Value; i++)
                {
                    for (int j = 0; j < (int)matrix_size_height.Value; j++)
                    {
                        layers[current_selected_layer].matrix_cid[i, j] = layers[last_selected_layer].matrix_cid[i, j];
                    }
                }
            }

            //TODO REPLACE WITH REF IN STRUCT
            for (int i = 0; i < (int)matrix_size_widht.Value; i++)
            {
                for (int j = 0; j < (int)matrix_size_height.Value; j++)
                {
                    for (int k = 0; k < matrix_panel.Controls.Count; k++)
                    {

                        if (matrix_panel.Controls[k].Name == "mcell_" + i.ToString() + "_" + j.ToString())
                        {
                            matrix_panel.Controls[k].BackColor = colors[layers[current_selected_layer].matrix_cid[i, j]];
                        }
                    }
                }
            }


        }
        //REMOVE FRAME BTN
        private void button3_Click(object sender, EventArgs e)
        {


        }
        private void layers_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox llistbox = (ListBox)sender;
            last_selected_layer = current_selected_layer;
            current_selected_layer = llistbox.SelectedIndex;
            layer_visible_up.Value = layers[current_selected_layer].visibilty;
            layer_delay_ud.Value = layers[current_selected_layer].delay;
            //TODO REPLACE WITH REF IN STRUCT
           for (int i = 0; i < (int)matrix_size_widht.Value; i++)
            {
                for (int j = 0; j < (int)matrix_size_height.Value; j++)
                {
                    for (int k = 0; k < matrix_panel.Controls.Count; k++)
                    {
                    
                       if (matrix_panel.Controls[k].Name == "mcell_" + i.ToString() + "_" + j.ToString())
                        {
                           matrix_panel.Controls[k].BackColor = colors[layers[current_selected_layer].matrix_cid[i, j]];
                        }
                    }
               }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO ADD IMPORT COLOOR TABLE
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export_layers();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            import_layers();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_sheet();
        }

        private void speichernunterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export_layers();
        }

        private void openBMPToLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(layers.Count <= 0)
            {
                MessageBox.Show("BMP IMPORT FAILED - please add a layer");
                return;
            }


            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "BITMAP (.bmp) | *.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog1.FileName);
                int parse_size_w = image.Width;
                int parse_size_h = image.Height;
                if(parse_size_w <= 0 && parse_size_h <= 0)
                {
                    MessageBox.Show("BMP IMPORT FAILED");
                    return;
                }

                if(parse_size_w != parse_size_h /*&&*/ ) //Math.Sqrt(parse_size_h) % 2) == 0)
                {
                    MessageBox.Show("BMP IMPORT ERROR - BMP IS NOT A QUARE");
                    return;
                }

                if(parse_size_w > matrix_size_w)
                {
                    parse_size_w = matrix_size_w;
                }

                if (parse_size_h > matrix_size_h)
                {
                    parse_size_h = matrix_size_h;
                }
                int color_pw = color_chooser.Size.Width / 32;
                int color_ph = colors.Count / color_pw;


                for (int i = 0; i < parse_size_w; i++)
                {
                    for (int j = 0; j < parse_size_h; j++)
                    {
                        Color tmp_col = image.GetPixel(i, j);
                        int color_id_to_write = 0;
                        bool col_simi = false;
                        for (int k = 0; k < colors.Count; k++)
                        {
                            if(AreColorsSimilar(tmp_col, colors[k], 20))
                            {
                                color_id_to_write = k;
                                col_simi = true;
                                break;
                            }
                        }

                        if (!col_simi)
                        {
                            PictureBox pic = new PictureBox();
                            pic.Name = "colorpick_" + colors.Count.ToString();
                            pic.Size = new Size(32, 32);
                            int row_mult = 0;
                            if (color_ph > 0)
                            {
                                row_mult = (colors.Count / color_ph);
                            }
                            pic.Location = new Point((colors.Count % color_pw) * 32, row_mult * 32);
                            pic.Click += click_color;
                            color_chooser.Controls.Add(pic);
                            colors.Add(tmp_col);
                            pic.BackColor = colors[colors.Count - 1];
                            color_id_to_write = colors.Count - 1;
                        }




                        //add color to layer
                        layers[current_selected_layer].matrix_cid[i, j] = color_id_to_write;
                        
                    }
                }
                // erst color table
                //dann id schreiben

            }

            current_selected_layer = 0;
            //TODO REPLACE WITH REF IN STRUCT
            for (int i = 0; i < (int)matrix_size_widht.Value; i++)
            {
                for (int j = 0; j < (int)matrix_size_height.Value; j++)
                {
                    for (int k = 0; k < matrix_panel.Controls.Count; k++)
                    {

                        if (matrix_panel.Controls[k].Name == "mcell_" + i.ToString() + "_" + j.ToString())
                        {
                            matrix_panel.Controls[k].BackColor = colors[layers[current_selected_layer].matrix_cid[i, j]];
                        }
                    }
                }
            }




        }

        private void dateiToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void importMultiframeBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //split into layer size this must fir
            //for each thing add new layer 
            //make color table
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "BITMAP (.bmp) | *.bmp";

            if(matrix_size_w <= 0 || matrix_size_h <= 0)
            {
                MessageBox.Show("MULTI FRAME BMP IMPORT FAILED - PLEASE SET THE MATRIX SIZE TO YOUR FRAME SIZE AND CREATE A NEW FILE");
                return;
            }



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog1.FileName);

                int sprites_w = image.Width / matrix_size_w;
                int sprites_h = image.Height / matrix_size_h;
                int color_pw = color_chooser.Size.Width / 32;
                int color_ph = colors.Count / color_pw;

                bool cbx_state = copy_frame_data_chbx.Checked;
                copy_frame_data_chbx.Checked = false;
                if (layers.Count <= 0)
                {
                    set_matrix_size_btn_Click(null, null); //CREATE NEW PAGE
                }
                current_selected_layer = 0;
 

                for (int sph = 0; sph < sprites_h; sph++)
                {
                    for (int spw = 0; spw < sprites_w; spw++)
                {
                        if (current_selected_layer > layers.Count - 1)
                        {
                            button2_Click(null, null);
                        }

                        for (int x = 0; x < matrix_size_w; x++)
                        {
                            for (int y = 0; y < matrix_size_h; y++)
                            {
                                int rx = (spw * matrix_size_w) + x;
                                int ry = (sph * matrix_size_h) + y;


                                Color tmp_col = image.GetPixel(rx, ry);
                                int color_id_to_write = 0;
                                bool col_simi = false;
                                for (int k = 0; k < colors.Count; k++)
                                {
                                    if (AreColorsSimilar(tmp_col, colors[k], 20))
                                    {
                                        color_id_to_write = k;
                                        col_simi = true;
                                        break;
                                    }
                                }

                                if (!col_simi)
                                {
                                    PictureBox pic = new PictureBox();
                                    pic.Name = "colorpick_" + colors.Count.ToString();
                                    pic.Size = new Size(32, 32);
                                    int row_mult = 0;
                                    if (color_ph > 0)
                                    {
                                        row_mult = (colors.Count / color_ph);
                                    }
                                    pic.Location = new Point((colors.Count % color_pw) * 32, row_mult * 32);
                                    pic.Click += click_color;
                                    color_chooser.Controls.Add(pic);
                                    colors.Add(tmp_col);
                                    pic.BackColor = colors[colors.Count - 1];
                                    color_id_to_write = colors.Count - 1;
                                }




                                //add color to layer
                                layers[current_selected_layer].matrix_cid[x, y] = color_id_to_write;


                            }
                        }

                        //new layer;

                        current_selected_layer++;



                    }
                }

                //restore cbx
                copy_frame_data_chbx.Checked = cbx_state;
            }
        }

        private void layer_visible_up_ValueChanged(object sender, EventArgs e)
        {
           layer l = layers[current_selected_layer];
            l.visibilty = (int)layer_visible_up.Value;
            layers[current_selected_layer] = l;
        }

        private void layer_delay_ud_ValueChanged(object sender, EventArgs e)
        {
            layer l = layers[current_selected_layer];
            l.delay = (int)layer_delay_ud.Value;
            layers[current_selected_layer] = l;
        }

        private void addColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                int color_pw = color_chooser.Size.Width / 32;
                int color_ph = colors.Count / color_pw;
                Color tmp_col =colorDialog1.Color;
                int color_id_to_write = 0;
                bool col_simi = false;
                for (int k = 0; k < colors.Count; k++)
                {
                    if (AreColorsSimilar(tmp_col, colors[k], 40))
                    {
                        color_id_to_write = k;
                        col_simi = true;
                        break;
                    }
                }
                if (!col_simi)
                {
                    PictureBox pic = new PictureBox();
                    pic.Name = "colorpick_" + colors.Count.ToString();
                    pic.Size = new Size(32, 32);
                    int row_mult = 0;
                    if (color_ph > 0)
                    {
                        row_mult = (colors.Count / color_ph);
                    }
                    pic.Location = new Point((colors.Count % color_pw) * 32, row_mult * 32);
                    pic.Click += click_color;
                    color_chooser.Controls.Add(pic);
                    colors.Add(tmp_col);
                    pic.BackColor = colors[colors.Count - 1];
                    color_id_to_write = colors.Count - 1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (int i in exp_layer_cboxlist.CheckedIndices)
            {
                exp_layer_cboxlist.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (int i in exp_layer_cboxlist.CheckedIndices)
            {
                exp_layer_cboxlist.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void importASPRITEProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OPEN FILE
            //SET WATCHDOG
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "ASPRITE (.ase) | *.ase";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (!openFileDialog1.CheckFileExists)
                {
                    MessageBox.Show("ASE FILE ERROR DONT EXISTS");
                    return;
                }
                //SETUP FILE WATCHER
                fileSystemWatcher1.Path = Path.GetDirectoryName(openFileDialog1.FileName);
                fileSystemWatcher1.Filter = Path.GetFileName(openFileDialog1.FileName);
                fileSystemWatcher1.EnableRaisingEvents = true;
                ase_path = openFileDialog1.FileName;
                import_ase(false);
            }
            
        }

        bool ase_import_complete = true;
        string ase_path = "";
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            import_ase(true);
        }

        static object ByteArrayToStruct(byte[] array, int offset, Type structType)
        {
            if (structType.StructLayoutAttribute.Value != LayoutKind.Sequential)
                throw new ArgumentException("structType ist keine Struktur oder nicht Sequentiell.");

            int size = Marshal.SizeOf(structType);


            byte[] tmp = new byte[size];

            if (offset > 0)
                Array.Copy(array, offset, tmp, 0, size);
            else
                tmp = array;

            GCHandle structHandle = GCHandle.Alloc(tmp, GCHandleType.Pinned);
            object structure = Marshal.PtrToStructure(structHandle.AddrOfPinnedObject(), structType);
            structHandle.Free();

            return structure;
        }


        //ASE IMPORT SECTION 
        struct ASE_PARSED_PROJECT
        {
            public int frame_id;
            public ASE_FRAME_HEADER frame_info;
            public List<ASE_CHUNK> chunks;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct ASE_HEADER
        {
            public UInt32 file_size;
            public UInt16 magic_number;
            public UInt16 frames;
            public UInt16 widht;
            public UInt16 height;
            public UInt16 color_depth; //32 = RGBA 16 = GRAY 8 INDEXED
            public UInt32 flags;
            public UInt16 speed;
            public UInt32 reserved_0;
            public UInt32 reserved_1;
            public Byte palette_index;
            public byte[] reserved_2;
            public UInt16 num_colors;
            public byte[] reserved_3;
        };
        private void init_ase_header(ref ASE_HEADER _h)
        {
            _h.file_size = 0;
            _h.magic_number = 0;
            _h.frames = 0;
            _h.widht = 0;
            _h.height = 0;
            _h.color_depth = 0;
            _h.flags = 0;
            _h.speed = 0;
            _h.reserved_0 = 0;
            _h.reserved_1 = 0;
            _h.palette_index = 0;
            _h.reserved_2 = new byte[3];
            _h.num_colors = 0;
            _h.reserved_3 = new byte[94];
        }

        [StructLayout(LayoutKind.Sequential)]
        struct ASE_FRAME_HEADER
        {
            public UInt32 byte_per_frame;
            public UInt16 magic_number;
            public UInt16 chunks;
            public UInt16 frame_duration;
            public byte[] reserved; //6 bytes
        };
        private void init_ase_frame_header(ref ASE_FRAME_HEADER _h)
        {
            _h.byte_per_frame = 0;
            _h.magic_number = 0;
            _h.chunks = 0;
            _h.frame_duration = 100;
            _h.reserved = new byte[3];
        }

        [StructLayout(LayoutKind.Sequential)]
        struct ASE_CHUNK_HEAD
        {
            public UInt32 chunk_size;
            public UInt16 chunk_type; // layer 0x2004 cell 0x2005  mask 0x2016 frame tag 0x2018 user data 0x2020 palette 0x2019
        }

        enum ASE_CHUNK_TYPE
        {
            INVLAID, OLD_PALETTE, PALETTE, LAYER, CELL, USER_DATA, MASK, PATH, FRAME_TAG
        }
        [StructLayout(LayoutKind.Sequential)]
        struct ASE_CHUNK
        {
            public ASE_CHUNK_HEAD chunk_head;
            public ASE_CHUNK_TYPE chunk_type;
            public byte[] chunk_data;
        }

        struct ASE_STRING
        {
            public UInt16 lenght;
            public byte[] string_data;
        }

        //CHUNK STRUCTS
        struct CHUNK_DESC_LAYER
        {
            public UInt16 flags;
            public UInt16 type; //normal = 0 1= layer set
            public UInt16 child_level;
            public UInt16 layer_w; //ignore
            public UInt16 layer_h; //ignore
            public UInt16 blend_mode; //normal, apply,... 0 if layer set
            public byte opacity;
            public byte[] reserved;
            public ASE_STRING layer_name;
        }



        //---------------ASE VARS-----------------
        List<ASE_PARSED_PROJECT> ase_parsed_frames = new List<ASE_PARSED_PROJECT>();

        void init_chunk_desc_layer(ref CHUNK_DESC_LAYER _ref)
        {
            _ref.flags = 0;
            _ref.type = 0;
            _ref.child_level = 0;
            _ref.layer_w = 0;
            _ref.layer_h = 0;
            _ref.blend_mode = 0;
            _ref.opacity = 0;
            _ref.reserved = new byte[3];
            _ref.layer_name = new ASE_STRING();
            _ref.layer_name.lenght = 0;
            _ref.layer_name.string_data = new byte[1];
            _ref.layer_name.string_data[0] = (byte)'\0';
        }

        private void import_ase(bool _from_wd = false)
        {
            if (!ase_auto_import_cbx.Checked && _from_wd)
            {
                return;
            }
            if (!ase_import_complete)
            {
                MessageBox.Show("ASE IMPORT NOT FINISHED");
                return;
            }

            ase_import_complete = false;
            int byte_read_offset = 0;
                
            byte[] buffer = File.ReadAllBytes(ase_path);


            //https://github.com/aseprite/aseprite/blob/master/docs/files/ase.txt

            ASE_HEADER file_head = new ASE_HEADER();
            init_ase_header(ref file_head);
            file_head = (ASE_HEADER)ByteArrayToStruct(buffer, byte_read_offset, typeof(ASE_HEADER));
            if(file_head.magic_number != 42464)
            {
                MessageBox.Show("ASE IMPORT FAILED - MAGIC NUMBER WRONG - AUTO IMPORT DISBALED");
                ase_auto_import_cbx.Checked = false;
                return;

            }
            if(file_head.frames <= 0)
            {
                MessageBox.Show("ASE IMPORT FAILED - NO FRAMES AVARIABLE");
                    return;
            }

            ase_parsed_frames.Clear();
            byte_read_offset += 128; //pos after file head

            for (int frame_head_counter = 0; frame_head_counter < file_head.frames; frame_head_counter++)
            {
                ASE_FRAME_HEADER current_frame_header = new ASE_FRAME_HEADER();
                current_frame_header = (ASE_FRAME_HEADER)ByteArrayToStruct(buffer, byte_read_offset, typeof(ASE_FRAME_HEADER));
                byte_read_offset += 16;
                if (current_frame_header.magic_number != 61946)
                {
                    MessageBox.Show("ASE IMPORT FAILED - INVALID FRAME DATA");
                    return;
                }

                List<ASE_CHUNK> chunks_list = new List<ASE_CHUNK>();
                //FOR EACH CHUNK
                for (int j = 0; j < current_frame_header.chunks; j++)
                {
                ASE_CHUNK curr_chunk = new ASE_CHUNK();
                curr_chunk.chunk_head = new ASE_CHUNK_HEAD();
                //READ CHUNK DATA
                curr_chunk.chunk_head = (ASE_CHUNK_HEAD)ByteArrayToStruct(buffer, byte_read_offset, typeof(ASE_CHUNK_HEAD));
                //READ CHUNK DATA
                curr_chunk.chunk_data = new byte[curr_chunk.chunk_head.chunk_size];
                    
                //SWITCH TYPE AND CREARTE TYPE
                switch (curr_chunk.chunk_head.chunk_type)
                {
                    case 4:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.OLD_PALETTE;
                        break;
                    case 17:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.OLD_PALETTE;
                        break;
                        case 8196:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.LAYER;
                        break;
                    case 8197:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.CELL;
                        break;
                    case 8214:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.MASK;
                        break;
                    case 8215:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.PATH;
                        break;
                    case 2016:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.FRAME_TAG;
                        break;
                    case 8217:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.PALETTE;
                        break;
                    case 8224:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.USER_DATA;
                        break;
                    default:
                        curr_chunk.chunk_type = ASE_CHUNK_TYPE.INVLAID;
                        break;
                }
                //WRITE BYTES TO DATA BLOB
                curr_chunk.chunk_data = new byte[curr_chunk.chunk_head.chunk_size];
                for (int i = 0; i < curr_chunk.chunk_head.chunk_size; i++)
                {
                    curr_chunk.chunk_data[i] = buffer[byte_read_offset + i];
                }
                //SET OFFSET TO NEXT CHUNK START
                byte_read_offset += (int)curr_chunk.chunk_head.chunk_size;
                //ADD PARSED CHUNK TO LIST
                chunks_list.Add(curr_chunk);
                }
                //SAVE DATA AS NEW COMBINED
                ASE_PARSED_PROJECT tmp_frame = new ASE_PARSED_PROJECT();
                tmp_frame.frame_id = frame_head_counter;
                tmp_frame.frame_info = current_frame_header;
                tmp_frame.chunks = chunks_list;
                //SAVE IN FRAME STORE
                ase_parsed_frames.Add(tmp_frame);
            }
            ase_import_complete = true;
            return;
        }
        //EXPORT BMP
        private void exportAsBMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(layers.Count <= 0)
            {
                MessageBox.Show("EXPORT BMP FAILED - NO LAYERS TO EXPORT");
            }

            Bitmap exp_bmp = new Bitmap(matrix_size_w, matrix_size_h * layers.Count);//, 0, System.Drawing.Imaging.PixelFormat.Format32bppRgb, 0);
            for (int i = 0; i < layers.Count; i++)
            {
                for (int x = 0; x < matrix_size_w; x++)
                {
                    for (int y = 0; y < matrix_size_h; y++)
                    {


                        exp_bmp.SetPixel(x, y + (i*matrix_size_h), colors[layers[i].matrix_cid[x, y]]);

                    }
                }
            }
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "BMP (.bmp) | *.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                exp_bmp.Save(saveFileDialog1.FileName);
            }
        }


        /* TODO
         * 
         * 
         * für deden chunk typ einen header bauen
         * dann für jede chunk typ eine funktion bauen die ASE_PARSED_PROJECT in den passenden frame umwandelt
         * 
         * funktion ase project to layers diese dann auch im filewatcher aufrufen
         * -> color table bauen // wenn transparent dann mit hintergrundfarbe füllen
         * 
         * neues dateiformat einführen
         * Ascii und binary
         * ->weather frame ard sketch neues parsing einführen
         * 
         * serial connection mode stream von frame direcly to the weather frame
         * 
         * */


        bool get_ase_specific_chunk(ASE_PARSED_PROJECT _ase_parsed_project, Type _chunk_type, int _from_layer)
        {
            return false;
        }




    }
}
