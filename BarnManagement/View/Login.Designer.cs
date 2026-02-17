
namespace BarnManagement
{
    partial class Login
    {
        /// <summary>
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
            groupBox1 = new GroupBox();
            buttonLogin = new Button();
            textBoxPassword = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxUsername = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(buttonLogin);
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxUsername);
            groupBox1.Location = new Point(177, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 319);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Segoe UI", 16F);
            buttonLogin.Location = new Point(175, 223);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(126, 45);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 14F);
            textBoxPassword.Location = new Point(151, 174);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(232, 32);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(54, 177);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(54, 133);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(102, 43);
            label1.Name = "label1";
            label1.Size = new Size(281, 45);
            label1.TabIndex = 1;
            label1.Text = "Barn Management";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Segoe UI", 14F);
            textBoxUsername.Location = new Point(151, 130);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(232, 32);
            textBoxUsername.TabIndex = 0;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Login";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private GroupBox groupBox1;
        private Button buttonLogin;
        private TextBox textBoxPassword;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxUsername;
    }
}
