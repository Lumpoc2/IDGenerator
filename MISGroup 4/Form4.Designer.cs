
namespace MISGroup_4
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelFront = new System.Windows.Forms.Panel();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.Program = new System.Windows.Forms.Label();
            this.Fullname = new System.Windows.Forms.Label();
            this.StudentId = new System.Windows.Forms.Label();
            this.Signature = new System.Windows.Forms.PictureBox();
            this.GuardianName = new System.Windows.Forms.Label();
            this.Contact = new System.Windows.Forms.Label();
            this.panelBack = new System.Windows.Forms.Panel();
            this.Address = new System.Windows.Forms.Label();
            this.Print_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Signature)).BeginInit();
            this.panelBack.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(510, 424);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelFront
            // 
            this.panelFront.BackColor = System.Drawing.Color.White;
            this.panelFront.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFront.BackgroundImage")));
            this.panelFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFront.Controls.Add(this.ProfilePicture);
            this.panelFront.Controls.Add(this.Program);
            this.panelFront.Controls.Add(this.Fullname);
            this.panelFront.Controls.Add(this.StudentId);
            this.panelFront.Location = new System.Drawing.Point(23, 38);
            this.panelFront.Margin = new System.Windows.Forms.Padding(4);
            this.panelFront.Name = "panelFront";
            this.panelFront.Size = new System.Drawing.Size(234, 332);
            this.panelFront.TabIndex = 10;
            this.panelFront.Tag = "front-background";
            this.panelFront.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.ProfilePicture.BackColor = System.Drawing.Color.Silver;
            this.ProfilePicture.Location = new System.Drawing.Point(54, 102);
            this.ProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(120, 119);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePicture.TabIndex = 9;
            this.ProfilePicture.TabStop = false;
            this.ProfilePicture.Tag = "front";
            this.ProfilePicture.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // Program
            // 
            this.Program.AutoSize = true;
            this.Program.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Program.Location = new System.Drawing.Point(84, 240);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(53, 18);
            this.Program.TabIndex = 13;
            this.Program.Tag = "front";
            this.Program.Text = "BSCS";
            this.Program.Click += new System.EventHandler(this.label17_Click);
            // 
            // Fullname
            // 
            this.Fullname.AutoSize = true;
            this.Fullname.BackColor = System.Drawing.Color.Transparent;
            this.Fullname.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Fullname.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Fullname.Location = new System.Drawing.Point(63, 264);
            this.Fullname.Name = "Fullname";
            this.Fullname.Size = new System.Drawing.Size(99, 25);
            this.Fullname.TabIndex = 13;
            this.Fullname.Tag = "front";
            this.Fullname.Text = "Fullaname";
            this.Fullname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fullname.Click += new System.EventHandler(this.label17_Click);
            // 
            // StudentId
            // 
            this.StudentId.AutoSize = true;
            this.StudentId.Location = new System.Drawing.Point(75, 225);
            this.StudentId.Name = "StudentId";
            this.StudentId.Size = new System.Drawing.Size(62, 15);
            this.StudentId.TabIndex = 12;
            this.StudentId.Tag = "front";
            this.StudentId.Text = "Student ID";
            this.StudentId.Click += new System.EventHandler(this.label3_Click);
            // 
            // Signature
            // 
            this.Signature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Signature.Location = new System.Drawing.Point(43, 254);
            this.Signature.Name = "Signature";
            this.Signature.Size = new System.Drawing.Size(141, 44);
            this.Signature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Signature.TabIndex = 15;
            this.Signature.TabStop = false;
            this.Signature.Tag = "back";
            this.Signature.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // GuardianName
            // 
            this.GuardianName.AutoSize = true;
            this.GuardianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GuardianName.Location = new System.Drawing.Point(68, 101);
            this.GuardianName.Name = "GuardianName";
            this.GuardianName.Size = new System.Drawing.Size(116, 20);
            this.GuardianName.TabIndex = 16;
            this.GuardianName.Tag = "back";
            this.GuardianName.Text = "Angel Llocsin";
            this.GuardianName.Click += new System.EventHandler(this.label22_Click);
            // 
            // Contact
            // 
            this.Contact.AutoSize = true;
            this.Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Contact.Location = new System.Drawing.Point(84, 141);
            this.Contact.Name = "Contact";
            this.Contact.Size = new System.Drawing.Size(71, 15);
            this.Contact.TabIndex = 16;
            this.Contact.Tag = "back";
            this.Contact.Text = "09318719";
            this.Contact.Click += new System.EventHandler(this.label22_Click);
            // 
            // panelBack
            // 
            this.panelBack.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.panelBack.BackColor = System.Drawing.Color.White;
            this.panelBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBack.BackgroundImage")));
            this.panelBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBack.Controls.Add(this.Contact);
            this.panelBack.Controls.Add(this.Address);
            this.panelBack.Controls.Add(this.GuardianName);
            this.panelBack.Controls.Add(this.Signature);
            this.panelBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelBack.Location = new System.Drawing.Point(299, 38);
            this.panelBack.Margin = new System.Windows.Forms.Padding(4);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(234, 332);
            this.panelBack.TabIndex = 11;
            this.panelBack.Tag = "back-background";
            this.panelBack.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Address.Location = new System.Drawing.Point(43, 121);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(169, 15);
            this.Address.TabIndex = 16;
            this.Address.Tag = "back";
            this.Address.Text = "Prk. Talong Sta.lucia Dist";
            this.Address.Click += new System.EventHandler(this.label22_Click);
            // 
            // Print_button
            // 
            this.Print_button.Location = new System.Drawing.Point(510, 453);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(75, 23);
            this.Print_button.TabIndex = 6;
            this.Print_button.Text = "Print";
            this.Print_button.UseVisualStyleBackColor = true;
            this.Print_button.Click += new System.EventHandler(this.Print_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelFront);
            this.panel1.Controls.Add(this.panelBack);
            this.panel1.Location = new System.Drawing.Point(31, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 396);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Print_button);
            this.Controls.Add(this.btnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form4";
            this.Text = "StudentID";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panelFront.ResumeLayout(false);
            this.panelFront.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Signature)).EndInit();
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panelFront;
        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.PictureBox Signature;
        private System.Windows.Forms.Label GuardianName;
        private System.Windows.Forms.Label Contact;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Label StudentId;
        private System.Windows.Forms.Label Program;
        private System.Windows.Forms.Label Fullname;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Button Print_button;
        private System.Windows.Forms.Panel panel1;
    }
}