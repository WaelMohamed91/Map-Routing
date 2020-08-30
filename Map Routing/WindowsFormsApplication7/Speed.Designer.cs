namespace WindowsFormsApplication7
{
    partial class Speed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Speed));
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.draw_panal = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.executionTimeL = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totaltimeL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totaldisL = new System.Windows.Forms.Label();
            this.vehdL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.walkingdL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Qery_text = new Bunifu.Framework.UI.BunifuTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.Map = new System.Windows.Forms.ComboBox();
            this.Short_Path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Draw = new System.Windows.Forms.Button();
            this.draw_panal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Castellar", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(682, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(361, 50);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Map Routing";
            // 
            // draw_panal
            // 
            this.draw_panal.BackColor = System.Drawing.Color.DarkSlateGray;
            this.draw_panal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.draw_panal.Controls.Add(this.pictureBox1);
            this.draw_panal.Controls.Add(this.bunifuCustomLabel1);
            this.draw_panal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draw_panal.Location = new System.Drawing.Point(0, 0);
            this.draw_panal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.draw_panal.Name = "draw_panal";
            this.draw_panal.Size = new System.Drawing.Size(1129, 780);
            this.draw_panal.TabIndex = 13;
            this.draw_panal.Click += new System.EventHandler(this.draw_panal_Click);
            this.draw_panal.Paint += new System.Windows.Forms.PaintEventHandler(this.draw_panal_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(641, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 50);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Qery_text);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Map);
            this.panel1.Controls.Add(this.Short_Path);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Draw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(829, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 780);
            this.panel1.TabIndex = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(206, 170);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 32);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(25, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "Test Specific Query";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(0, 100);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(300, 43);
            this.button3.TabIndex = 31;
            this.button3.Text = "Check All Queries";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.executionTimeL);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.totaltimeL);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.totaldisL);
            this.panel2.Controls.Add(this.vehdL);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.walkingdL);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(13, 385);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 369);
            this.panel2.TabIndex = 30;
            this.panel2.Visible = false;
            // 
            // executionTimeL
            // 
            this.executionTimeL.AutoSize = true;
            this.executionTimeL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executionTimeL.ForeColor = System.Drawing.Color.White;
            this.executionTimeL.Location = new System.Drawing.Point(19, 322);
            this.executionTimeL.Name = "executionTimeL";
            this.executionTimeL.Size = new System.Drawing.Size(23, 24);
            this.executionTimeL.TabIndex = 9;
            this.executionTimeL.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(9, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "Execution Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Time";
            // 
            // totaltimeL
            // 
            this.totaltimeL.AutoSize = true;
            this.totaltimeL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaltimeL.ForeColor = System.Drawing.Color.White;
            this.totaltimeL.Location = new System.Drawing.Point(19, 40);
            this.totaltimeL.Name = "totaltimeL";
            this.totaltimeL.Size = new System.Drawing.Size(23, 24);
            this.totaltimeL.TabIndex = 1;
            this.totaltimeL.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total Distance";
            // 
            // totaldisL
            // 
            this.totaldisL.AutoSize = true;
            this.totaldisL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldisL.ForeColor = System.Drawing.Color.White;
            this.totaldisL.Location = new System.Drawing.Point(19, 105);
            this.totaldisL.Name = "totaldisL";
            this.totaldisL.Size = new System.Drawing.Size(23, 24);
            this.totaldisL.TabIndex = 3;
            this.totaldisL.Text = "0";
            // 
            // vehdL
            // 
            this.vehdL.AutoSize = true;
            this.vehdL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehdL.ForeColor = System.Drawing.Color.White;
            this.vehdL.Location = new System.Drawing.Point(19, 252);
            this.vehdL.Name = "vehdL";
            this.vehdL.Size = new System.Drawing.Size(23, 24);
            this.vehdL.TabIndex = 7;
            this.vehdL.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Walking Distance";
            // 
            // walkingdL
            // 
            this.walkingdL.AutoSize = true;
            this.walkingdL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walkingdL.ForeColor = System.Drawing.Color.White;
            this.walkingdL.Location = new System.Drawing.Point(19, 180);
            this.walkingdL.Name = "walkingdL";
            this.walkingdL.Size = new System.Drawing.Size(23, 24);
            this.walkingdL.TabIndex = 5;
            this.walkingdL.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Vehcile Distance";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 331);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 43);
            this.button2.TabIndex = 27;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(153, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "queryno";
            this.label3.Visible = false;
            // 
            // Qery_text
            // 
            this.Qery_text.BackColor = System.Drawing.Color.White;
            this.Qery_text.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Qery_text.BackgroundImage")));
            this.Qery_text.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Qery_text.ForeColor = System.Drawing.Color.Black;
            this.Qery_text.Icon = ((System.Drawing.Image)(resources.GetObject("Qery_text.Icon")));
            this.Qery_text.Location = new System.Drawing.Point(153, 211);
            this.Qery_text.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Qery_text.Name = "Qery_text";
            this.Qery_text.Size = new System.Drawing.Size(138, 31);
            this.Qery_text.TabIndex = 23;
            this.Qery_text.text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 21;
            this.label1.Text = "Select a Map";
            // 
            // Map
            // 
            this.Map.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Map.FormattingEnabled = true;
            this.Map.Items.AddRange(new object[] {
            "map1",
            "map2",
            "map3",
            "map4",
            "map5",
            "OLMap",
            "SFMap"});
            this.Map.Location = new System.Drawing.Point(82, 54);
            this.Map.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(137, 30);
            this.Map.TabIndex = 20;
            this.Map.SelectedIndexChanged += new System.EventHandler(this.Map_SelectedIndexChanged);
            // 
            // Short_Path
            // 
            this.Short_Path.BackColor = System.Drawing.Color.CadetBlue;
            this.Short_Path.Enabled = false;
            this.Short_Path.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Short_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Short_Path.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Short_Path.Location = new System.Drawing.Point(48, 331);
            this.Short_Path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Short_Path.Name = "Short_Path";
            this.Short_Path.Size = new System.Drawing.Size(252, 43);
            this.Short_Path.TabIndex = 26;
            this.Short_Path.Text = "Shortest Path";
            this.Short_Path.UseVisualStyleBackColor = false;
            this.Short_Path.Click += new System.EventHandler(this.Short_Path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 22;
            this.label2.Text = "Query No";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 280);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 43);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Draw
            // 
            this.Draw.BackColor = System.Drawing.Color.CadetBlue;
            this.Draw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Draw.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Draw.Location = new System.Drawing.Point(48, 280);
            this.Draw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(252, 43);
            this.Draw.TabIndex = 24;
            this.Draw.Text = "Draw";
            this.Draw.UseVisualStyleBackColor = false;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Speed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1129, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.draw_panal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Speed";
            this.Text = "Speed";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.draw_panal.ResumeLayout(false);
            this.draw_panal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel draw_panal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label executionTimeL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totaltimeL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totaldisL;
        private System.Windows.Forms.Label vehdL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label walkingdL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuTextbox Qery_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Map;
        private System.Windows.Forms.Button Short_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
    }
}