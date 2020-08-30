namespace WindowsFormsApplication7
{
    partial class Fixedspeed
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fixedspeed));
            this.fixed_speed = new Bunifu.Framework.UI.BunifuFlatButton();
            this.var_speed = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // fixed_speed
            // 
            this.fixed_speed.Activecolor = System.Drawing.Color.DarkCyan;
            this.fixed_speed.BackColor = System.Drawing.Color.DarkCyan;
            this.fixed_speed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fixed_speed.BorderRadius = 20;
            this.fixed_speed.ButtonText = "Fixed Speed";
            this.fixed_speed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fixed_speed.Iconcolor = System.Drawing.Color.Transparent;
            this.fixed_speed.Iconimage = ((System.Drawing.Image)(resources.GetObject("fixed_speed.Iconimage")));
            this.fixed_speed.Iconimage_right = null;
            this.fixed_speed.Iconimage_right_Selected = null;
            this.fixed_speed.Iconimage_Selected = null;
            this.fixed_speed.IconZoom = 87D;
            this.fixed_speed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fixed_speed.IsTab = false;
            this.fixed_speed.Location = new System.Drawing.Point(193, 98);
            this.fixed_speed.Name = "fixed_speed";
            this.fixed_speed.Normalcolor = System.Drawing.Color.DarkCyan;
            this.fixed_speed.OnHovercolor = System.Drawing.Color.LightSeaGreen;
            this.fixed_speed.OnHoverTextColor = System.Drawing.Color.White;
            this.fixed_speed.selected = false;
            this.fixed_speed.Size = new System.Drawing.Size(171, 42);
            this.fixed_speed.TabIndex = 4;
            this.fixed_speed.Textcolor = System.Drawing.Color.White;
            this.fixed_speed.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixed_speed.Click += new System.EventHandler(this.fixed_speed_Click);
            // 
            // var_speed
            // 
            this.var_speed.Activecolor = System.Drawing.Color.DarkCyan;
            this.var_speed.BackColor = System.Drawing.Color.DarkCyan;
            this.var_speed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.var_speed.BorderRadius = 20;
            this.var_speed.ButtonText = "Variable Speed";
            this.var_speed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.var_speed.Iconcolor = System.Drawing.Color.Transparent;
            this.var_speed.Iconimage = ((System.Drawing.Image)(resources.GetObject("var_speed.Iconimage")));
            this.var_speed.Iconimage_right = null;
            this.var_speed.Iconimage_right_Selected = null;
            this.var_speed.Iconimage_Selected = null;
            this.var_speed.IconZoom = 87D;
            this.var_speed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.var_speed.IsTab = false;
            this.var_speed.Location = new System.Drawing.Point(193, 171);
            this.var_speed.Name = "var_speed";
            this.var_speed.Normalcolor = System.Drawing.Color.DarkCyan;
            this.var_speed.OnHovercolor = System.Drawing.Color.LightSeaGreen;
            this.var_speed.OnHoverTextColor = System.Drawing.Color.White;
            this.var_speed.selected = false;
            this.var_speed.Size = new System.Drawing.Size(171, 42);
            this.var_speed.TabIndex = 3;
            this.var_speed.Textcolor = System.Drawing.Color.White;
            this.var_speed.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(139, 25);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(225, 28);
            this.bunifuCustomLabel2.TabIndex = 5;
            this.bunifuCustomLabel2.Text = "Start Your Journey";
            // 
            // Fixedspeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.fixed_speed);
            this.Controls.Add(this.var_speed);
            this.Name = "Fixedspeed";
            this.Size = new System.Drawing.Size(439, 391);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton fixed_speed;
        private Bunifu.Framework.UI.BunifuFlatButton var_speed;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;

    }
}
