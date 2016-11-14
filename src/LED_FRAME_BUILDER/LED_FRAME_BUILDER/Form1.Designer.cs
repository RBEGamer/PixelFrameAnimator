namespace LED_FRAME_BUILDER
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openBMPToLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMultiframeBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.copy_frame_data_chbx = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.layers_listbox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.color_chooser = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.matrix_size_widht = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.matrix_size_height = new System.Windows.Forms.NumericUpDown();
            this.matrix_panel = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.exp_layer_cboxlist = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layer_visible_up = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.layer_delay_ud = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrix_size_widht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrix_size_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer_visible_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer_delay_ud)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.toolStripSeparator1,
            this.openBMPToLayerToolStripMenuItem,
            this.importMultiframeBitmapToolStripMenuItem});
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem1.Text = "&Datei";
            this.dateiToolStripMenuItem1.Click += new System.EventHandler(this.dateiToolStripMenuItem1_Click);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripMenuItem.Image")));
            this.neuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.neuToolStripMenuItem.Text = "&Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
            this.öffnenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.öffnenToolStripMenuItem.Text = "Ö&ffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("speichernToolStripMenuItem.Image")));
            this.speichernToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern &unter";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // openBMPToLayerToolStripMenuItem
            // 
            this.openBMPToLayerToolStripMenuItem.Name = "openBMPToLayerToolStripMenuItem";
            this.openBMPToLayerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openBMPToLayerToolStripMenuItem.Text = "Singe Bitmap to Layer";
            this.openBMPToLayerToolStripMenuItem.Click += new System.EventHandler(this.openBMPToLayerToolStripMenuItem_Click);
            // 
            // importMultiframeBitmapToolStripMenuItem
            // 
            this.importMultiframeBitmapToolStripMenuItem.Name = "importMultiframeBitmapToolStripMenuItem";
            this.importMultiframeBitmapToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.importMultiframeBitmapToolStripMenuItem.Text = "Import Multiframe Bitmap";
            this.importMultiframeBitmapToolStripMenuItem.Click += new System.EventHandler(this.importMultiframeBitmapToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 513);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.layer_delay_ud);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.layer_visible_up);
            this.tabPage1.Controls.Add(this.copy_frame_data_chbx);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.layers_listbox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LAYERS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // copy_frame_data_chbx
            // 
            this.copy_frame_data_chbx.AutoSize = true;
            this.copy_frame_data_chbx.Checked = true;
            this.copy_frame_data_chbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copy_frame_data_chbx.Location = new System.Drawing.Point(7, 364);
            this.copy_frame_data_chbx.Name = "copy_frame_data_chbx";
            this.copy_frame_data_chbx.Size = new System.Drawing.Size(163, 17);
            this.copy_frame_data_chbx.TabIndex = 8;
            this.copy_frame_data_chbx.Text = "COPY LAST_FRAME_DATA";
            this.copy_frame_data_chbx.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 416);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "REMOVE FRAME";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ADD FRAME";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // layers_listbox
            // 
            this.layers_listbox.FormattingEnabled = true;
            this.layers_listbox.Location = new System.Drawing.Point(6, 5);
            this.layers_listbox.Name = "layers_listbox";
            this.layers_listbox.Size = new System.Drawing.Size(180, 186);
            this.layers_listbox.TabIndex = 5;
            this.layers_listbox.SelectedIndexChanged += new System.EventHandler(this.layers_listbox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "CLEAR_FRAME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.color_chooser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "COLORS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // color_chooser
            // 
            this.color_chooser.Location = new System.Drawing.Point(3, 6);
            this.color_chooser.Name = "color_chooser";
            this.color_chooser.Size = new System.Drawing.Size(183, 475);
            this.color_chooser.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.exp_layer_cboxlist);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.matrix_size_widht);
            this.tabPage3.Controls.Add(this.Label2);
            this.tabPage3.Controls.Add(this.matrix_size_height);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(192, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SETTINGS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WIDTH";
            // 
            // matrix_size_widht
            // 
            this.matrix_size_widht.Location = new System.Drawing.Point(64, 19);
            this.matrix_size_widht.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.matrix_size_widht.Name = "matrix_size_widht";
            this.matrix_size_widht.Size = new System.Drawing.Size(120, 20);
            this.matrix_size_widht.TabIndex = 0;
            this.matrix_size_widht.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "HEIGHT";
            // 
            // matrix_size_height
            // 
            this.matrix_size_height.Location = new System.Drawing.Point(64, 45);
            this.matrix_size_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.matrix_size_height.Name = "matrix_size_height";
            this.matrix_size_height.Size = new System.Drawing.Size(120, 20);
            this.matrix_size_height.TabIndex = 2;
            this.matrix_size_height.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // matrix_panel
            // 
            this.matrix_panel.Location = new System.Drawing.Point(230, 49);
            this.matrix_panel.Name = "matrix_panel";
            this.matrix_panel.Size = new System.Drawing.Size(512, 512);
            this.matrix_panel.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // exp_layer_cboxlist
            // 
            this.exp_layer_cboxlist.FormattingEnabled = true;
            this.exp_layer_cboxlist.Location = new System.Drawing.Point(17, 270);
            this.exp_layer_cboxlist.Name = "exp_layer_cboxlist";
            this.exp_layer_cboxlist.Size = new System.Drawing.Size(167, 214);
            this.exp_layer_cboxlist.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "EXPORT LAYERS";
            // 
            // layer_visible_up
            // 
            this.layer_visible_up.Location = new System.Drawing.Point(34, 255);
            this.layer_visible_up.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.layer_visible_up.Name = "layer_visible_up";
            this.layer_visible_up.Size = new System.Drawing.Size(120, 20);
            this.layer_visible_up.TabIndex = 9;
            this.layer_visible_up.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.layer_visible_up.ValueChanged += new System.EventHandler(this.layer_visible_up_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "LAYER VISIBILITY (0-255)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "LAYER_DELAY";
            // 
            // layer_delay_ud
            // 
            this.layer_delay_ud.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.layer_delay_ud.Location = new System.Drawing.Point(34, 302);
            this.layer_delay_ud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layer_delay_ud.Name = "layer_delay_ud";
            this.layer_delay_ud.Size = new System.Drawing.Size(120, 20);
            this.layer_delay_ud.TabIndex = 11;
            this.layer_delay_ud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.layer_delay_ud.ValueChanged += new System.EventHandler(this.layer_delay_ud_ValueChanged);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addColorToolStripMenuItem
            // 
            this.addColorToolStripMenuItem.Name = "addColorToolStripMenuItem";
            this.addColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addColorToolStripMenuItem.Text = "Add Color";
            this.addColorToolStripMenuItem.Click += new System.EventHandler(this.addColorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 573);
            this.Controls.Add(this.matrix_panel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(767, 612);
            this.MinimumSize = new System.Drawing.Size(767, 612);
            this.Name = "Form1";
            this.Text = "Matrix Frame Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrix_size_widht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrix_size_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer_visible_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer_delay_ud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.NumericUpDown matrix_size_height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown matrix_size_widht;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel matrix_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel color_chooser;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox layers_listbox;
        private System.Windows.Forms.CheckBox copy_frame_data_chbx;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem openBMPToLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMultiframeBitmapToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox exp_layer_cboxlist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown layer_visible_up;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown layer_delay_ud;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

