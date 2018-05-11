namespace TurkeySpanningTree
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.map = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DrawRoute = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.map.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("map.BackgroundImage")));
            this.map.Controls.Add(this.comboBox1);
            this.map.Controls.Add(this.DrawRoute);
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(1200, 556);
            this.map.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(701, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "CITIES";
            // 
            // DrawRoute
            // 
            this.DrawRoute.BackColor = System.Drawing.Color.LightPink;
            this.DrawRoute.ForeColor = System.Drawing.SystemColors.Info;
            this.DrawRoute.Location = new System.Drawing.Point(828, 15);
            this.DrawRoute.Name = "DrawRoute";
            this.DrawRoute.Size = new System.Drawing.Size(124, 54);
            this.DrawRoute.TabIndex = 0;
            this.DrawRoute.Text = "Draw Route";
            this.DrawRoute.UseVisualStyleBackColor = false;
            this.DrawRoute.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1187, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 524);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 525);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.map.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.Button DrawRoute;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

