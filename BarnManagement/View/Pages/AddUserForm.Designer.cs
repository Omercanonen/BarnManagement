namespace BarnManagement.View.Pages
{
    partial class AddUserForm
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
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            comboBoxRole = new ComboBox();
            buttonAddUser = new Button();
            dataGridViewUser = new DataGridView();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelRole = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUser).BeginInit();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 14F);
            labelUsername.Location = new Point(123, 35);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(97, 25);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Segoe UI", 14F);
            textBoxUsername.Location = new Point(226, 28);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(158, 32);
            textBoxUsername.TabIndex = 1;
            // 
            // comboBoxRole
            // 
            comboBoxRole.Font = new Font("Segoe UI", 14F);
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(226, 104);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(158, 33);
            comboBoxRole.TabIndex = 2;
            // 
            // buttonAddUser
            // 
            buttonAddUser.Font = new Font("Segoe UI", 14F);
            buttonAddUser.Location = new Point(253, 143);
            buttonAddUser.Name = "buttonAddUser";
            buttonAddUser.Size = new Size(90, 36);
            buttonAddUser.TabIndex = 3;
            buttonAddUser.Text = "Save";
            buttonAddUser.UseVisualStyleBackColor = true;
            buttonAddUser.Click += buttonAddUser_ClickAsync;
            // 
            // dataGridViewUser
            // 
            dataGridViewUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUser.Location = new Point(0, 234);
            dataGridViewUser.Name = "dataGridViewUser";
            dataGridViewUser.Size = new Size(570, 192);
            dataGridViewUser.TabIndex = 4;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14F);
            labelPassword.Location = new Point(129, 73);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(91, 25);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 14F);
            textBoxPassword.Location = new Point(226, 66);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(158, 32);
            textBoxPassword.TabIndex = 7;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 14F);
            labelRole.Location = new Point(172, 112);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(48, 25);
            labelRole.TabIndex = 9;
            labelRole.Text = "Role";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelRole);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(dataGridViewUser);
            Controls.Add(buttonAddUser);
            Controls.Add(comboBoxRole);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Name = "AddUserForm";
            Size = new Size(570, 426);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private TextBox textBoxUsername;
        private ComboBox comboBoxRole;
        private Button buttonAddUser;
        private DataGridView dataGridViewUser;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelRole;
    }
}
