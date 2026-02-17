namespace BarnManagement.View.Pages
{
    partial class PurchasePage
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
            comboBoxAnimalSpecies = new ComboBox();
            textBoxName = new TextBox();
            labelAnimalSpecies = new Label();
            buttonAnimalPurchase = new Button();
            labelAnimalName = new Label();
            comboBoxAnimalGender = new ComboBox();
            labelAnimalGender = new Label();
            labelPrice = new Label();
            SuspendLayout();
            // 
            // comboBoxAnimalSpecies
            // 
            comboBoxAnimalSpecies.Font = new Font("Segoe UI", 14F);
            comboBoxAnimalSpecies.FormattingEnabled = true;
            comboBoxAnimalSpecies.Location = new Point(196, 95);
            comboBoxAnimalSpecies.Name = "comboBoxAnimalSpecies";
            comboBoxAnimalSpecies.Size = new Size(231, 33);
            comboBoxAnimalSpecies.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 14F);
            textBoxName.Location = new Point(196, 138);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(231, 32);
            textBoxName.TabIndex = 1;
            // 
            // labelAnimalSpecies
            // 
            labelAnimalSpecies.AutoSize = true;
            labelAnimalSpecies.Font = new Font("Segoe UI", 14F);
            labelAnimalSpecies.Location = new Point(111, 103);
            labelAnimalSpecies.Name = "labelAnimalSpecies";
            labelAnimalSpecies.Size = new Size(75, 25);
            labelAnimalSpecies.TabIndex = 2;
            labelAnimalSpecies.Text = "Species";
            // 
            // buttonAnimalPurchase
            // 
            buttonAnimalPurchase.Font = new Font("Segoe UI", 14F);
            buttonAnimalPurchase.Location = new Point(232, 288);
            buttonAnimalPurchase.Name = "buttonAnimalPurchase";
            buttonAnimalPurchase.Size = new Size(133, 42);
            buttonAnimalPurchase.TabIndex = 3;
            buttonAnimalPurchase.Text = "Purchase";
            buttonAnimalPurchase.UseVisualStyleBackColor = true;
            buttonAnimalPurchase.Click += buttonAnimalPurchase_Click;
            // 
            // labelAnimalName
            // 
            labelAnimalName.AutoSize = true;
            labelAnimalName.Font = new Font("Segoe UI", 14F);
            labelAnimalName.Location = new Point(124, 145);
            labelAnimalName.Name = "labelAnimalName";
            labelAnimalName.Size = new Size(62, 25);
            labelAnimalName.TabIndex = 4;
            labelAnimalName.Text = "Name";
            // 
            // comboBoxAnimalGender
            // 
            comboBoxAnimalGender.Font = new Font("Segoe UI", 14F);
            comboBoxAnimalGender.FormattingEnabled = true;
            comboBoxAnimalGender.Location = new Point(196, 186);
            comboBoxAnimalGender.Name = "comboBoxAnimalGender";
            comboBoxAnimalGender.Size = new Size(231, 33);
            comboBoxAnimalGender.TabIndex = 7;
            // 
            // labelAnimalGender
            // 
            labelAnimalGender.AutoSize = true;
            labelAnimalGender.Font = new Font("Segoe UI", 14F);
            labelAnimalGender.Location = new Point(112, 194);
            labelAnimalGender.Name = "labelAnimalGender";
            labelAnimalGender.Size = new Size(74, 25);
            labelAnimalGender.TabIndex = 8;
            labelAnimalGender.Text = "Gender";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 14F);
            labelPrice.Location = new Point(262, 242);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(74, 25);
            labelPrice.TabIndex = 9;
            labelPrice.Text = "Gender";
            // 
            // PurchasePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelPrice);
            Controls.Add(labelAnimalGender);
            Controls.Add(comboBoxAnimalGender);
            Controls.Add(labelAnimalName);
            Controls.Add(buttonAnimalPurchase);
            Controls.Add(labelAnimalSpecies);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxAnimalSpecies);
            Name = "PurchasePage";
            Size = new Size(570, 426);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxAnimalSpecies;
        private TextBox textBoxName;
        private Label labelAnimalSpecies;
        private Button buttonAnimalPurchase;
        private Label labelAnimalName;
        private ComboBox comboBoxAnimalGender;
        private Label labelAnimalGender;
        private Label labelPrice;
    }
}
