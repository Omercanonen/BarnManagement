namespace BarnManagement.View
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            panelMenu = new Panel();
            buttonAddUser = new Button();
            buttonInventory = new Button();
            buttonProduction = new Button();
            buttonPurchase = new Button();
            buttonHome = new Button();
            labelUserName = new Label();
            panelContent = new Panel();
            labelBalance = new Label();
            labelBarnName = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ActiveCaption;
            panelMenu.Controls.Add(buttonAddUser);
            panelMenu.Controls.Add(buttonInventory);
            panelMenu.Controls.Add(buttonProduction);
            panelMenu.Controls.Add(buttonPurchase);
            panelMenu.Controls.Add(buttonHome);
            panelMenu.Controls.Add(labelUserName);
            panelMenu.Location = new Point(12, 12);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 426);
            panelMenu.TabIndex = 0;
            // 
            // buttonAddUser
            // 
            buttonAddUser.Font = new Font("Segoe UI", 16F);
            buttonAddUser.Location = new Point(10, 328);
            buttonAddUser.Name = "buttonAddUser";
            buttonAddUser.Size = new Size(174, 60);
            buttonAddUser.TabIndex = 5;
            buttonAddUser.Text = "Add User";
            buttonAddUser.UseVisualStyleBackColor = true;
            buttonAddUser.Click += buttonAddUser_Click;
            // 
            // buttonInventory
            // 
            buttonInventory.Font = new Font("Segoe UI", 16F);
            buttonInventory.Location = new Point(10, 262);
            buttonInventory.Name = "buttonInventory";
            buttonInventory.Size = new Size(174, 60);
            buttonInventory.TabIndex = 4;
            buttonInventory.Text = "Inventory";
            buttonInventory.UseVisualStyleBackColor = true;
            buttonInventory.Click += buttonInventory_Click_1;
            // 
            // buttonProduction
            // 
            buttonProduction.Font = new Font("Segoe UI", 16F);
            buttonProduction.Location = new Point(10, 196);
            buttonProduction.Name = "buttonProduction";
            buttonProduction.Size = new Size(174, 60);
            buttonProduction.TabIndex = 3;
            buttonProduction.Text = "Production";
            buttonProduction.UseVisualStyleBackColor = true;
            buttonProduction.Click += buttonProduction_Click_1;
            // 
            // buttonPurchase
            // 
            buttonPurchase.Font = new Font("Segoe UI", 16F);
            buttonPurchase.Location = new Point(10, 130);
            buttonPurchase.Name = "buttonPurchase";
            buttonPurchase.Size = new Size(174, 60);
            buttonPurchase.TabIndex = 2;
            buttonPurchase.Text = "Purchase";
            buttonPurchase.UseVisualStyleBackColor = true;
            buttonPurchase.Click += buttonPurchase_Click_1;
            // 
            // buttonHome
            // 
            buttonHome.Font = new Font("Segoe UI", 16F);
            buttonHome.Location = new Point(10, 64);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(174, 60);
            buttonHome.TabIndex = 1;
            buttonHome.Text = "Home";
            buttonHome.UseVisualStyleBackColor = true;
            buttonHome.Click += buttonHome_Click_1;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 14F);
            labelUserName.Location = new Point(10, 12);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(63, 25);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "label1";
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.ImeMode = ImeMode.AlphaFull;
            panelContent.Location = new Point(218, 35);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(570, 403);
            panelContent.TabIndex = 1;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Segoe UI", 14F);
            labelBalance.Location = new Point(705, 7);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(63, 25);
            labelBalance.TabIndex = 2;
            labelBalance.Text = "label1";
            // 
            // labelBarnName
            // 
            labelBarnName.AutoSize = true;
            labelBarnName.Font = new Font("Segoe UI", 14F);
            labelBarnName.Location = new Point(218, 7);
            labelBarnName.Name = "labelBarnName";
            labelBarnName.Size = new Size(63, 25);
            labelBarnName.TabIndex = 3;
            labelBarnName.Text = "label1";
            // 
            // GameTimer
            // 
            GameTimer.Interval = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelBarnName);
            Controls.Add(labelBalance);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "MainForm";
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMenu;
        private Button buttonHome;
        private Label labelUserName;
        private Panel panelContent;
        private Button buttonInventory;
        private Button buttonProduction;
        private Button buttonPurchase;
        private Label labelBalance;
        private Label labelBarnName;
        private Button buttonAddUser;
        private System.Windows.Forms.Timer GameTimer;
    }
}