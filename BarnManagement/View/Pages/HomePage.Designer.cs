namespace BarnManagement.View.Pages
{
    partial class HomePage
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
            buttonPurchaseAnimal = new Button();
            dataGridViewHome = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHome).BeginInit();
            SuspendLayout();
            // 
            // buttonPurchaseAnimal
            // 
            buttonPurchaseAnimal.Font = new Font("Segoe UI", 12F);
            buttonPurchaseAnimal.Location = new Point(410, 17);
            buttonPurchaseAnimal.Name = "buttonPurchaseAnimal";
            buttonPurchaseAnimal.Size = new Size(136, 35);
            buttonPurchaseAnimal.TabIndex = 2;
            buttonPurchaseAnimal.Text = "Purchase Animal";
            buttonPurchaseAnimal.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHome
            // 
            dataGridViewHome.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHome.Location = new Point(16, 58);
            dataGridViewHome.Name = "dataGridViewHome";
            dataGridViewHome.Size = new Size(530, 355);
            dataGridViewHome.TabIndex = 3;
            dataGridViewHome.Visible = false;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewHome);
            Controls.Add(buttonPurchaseAnimal);
            Name = "HomePage";
            Size = new Size(570, 426);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHome).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonPurchaseAnimal;
        private DataGridView dataGridViewHome;
    }
}
