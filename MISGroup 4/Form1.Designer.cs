namespace MISGroup_4
{
    partial class Form1
    {
        /// <summary>s
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveTempalte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.panelFront = new System.Windows.Forms.Panel();
            this.panelBack = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Picture 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Picture 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.btnSaveTempalte);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(3, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(104, 447);
            this.panel3.TabIndex = 2;
            // 
            // btnSaveTempalte
            // 
            this.btnSaveTempalte.Location = new System.Drawing.Point(9, 400);
            this.btnSaveTempalte.Name = "btnSaveTempalte";
            this.btnSaveTempalte.Size = new System.Drawing.Size(84, 23);
            this.btnSaveTempalte.TabIndex = 11;
            this.btnSaveTempalte.Text = "Save";
            this.btnSaveTempalte.UseVisualStyleBackColor = true;
            this.btnSaveTempalte.Click += new System.EventHandler(this.btnSaveTempalte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Properties";
            // 
            // panelFront
            // 
            this.panelFront.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFront.BackgroundImage")));
            this.panelFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFront.Location = new System.Drawing.Point(23, 38);
            this.panelFront.Name = "panelFront";
            this.panelFront.Size = new System.Drawing.Size(234, 332);
            this.panelFront.TabIndex = 4;
            this.panelFront.Tag = "front-background";
            this.panelFront.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFront_Paint);
            // 
            // panelBack
            // 
            this.panelBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBack.BackgroundImage")));
            this.panelBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBack.Location = new System.Drawing.Point(299, 38);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(228, 332);
            this.panelBack.TabIndex = 5;
            this.panelBack.Tag = "back-background";
            this.panelBack.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelFront);
            this.panel2.Controls.Add(this.panelBack);
            this.panel2.Location = new System.Drawing.Point(161, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 396);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveTempalte;
        private System.Windows.Forms.Panel panelFront;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Panel panel2;
    }
}

