namespace BarnManagement.View.Pages
{
    partial class InventoryPage
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
            listBoxInventory = new ListBox();
            labelUnitPrice = new Label();
            labelStock = new Label();
            labelTotalPrice = new Label();
            numericUpDownSellQuantity = new NumericUpDown();
            buttonSell = new Button();
            label1 = new Label();
            buttonSellAll = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSellQuantity).BeginInit();
            SuspendLayout();
            // 
            // listBoxInventory
            // 
            listBoxInventory.FormattingEnabled = true;
            listBoxInventory.Location = new Point(3, 3);
            listBoxInventory.Name = "listBoxInventory";
            listBoxInventory.Size = new Size(165, 424);
            listBoxInventory.TabIndex = 0;
            // 
            // labelUnitPrice
            // 
            labelUnitPrice.AutoSize = true;
            labelUnitPrice.Font = new Font("Segoe UI", 14F);
            labelUnitPrice.Location = new Point(300, 50);
            labelUnitPrice.Name = "labelUnitPrice";
            labelUnitPrice.Size = new Size(94, 25);
            labelUnitPrice.TabIndex = 1;
            labelUnitPrice.Text = "Unit Price";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Font = new Font("Segoe UI", 14F);
            labelStock.Location = new Point(300, 106);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(133, 25);
            labelStock.TabIndex = 2;
            labelStock.Text = "Stock Quantity";
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Font = new Font("Segoe UI", 14F);
            labelTotalPrice.Location = new Point(300, 226);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(99, 25);
            labelTotalPrice.TabIndex = 3;
            labelTotalPrice.Text = "Total Price";
            // 
            // numericUpDownSellQuantity
            // 
            numericUpDownSellQuantity.Font = new Font("Segoe UI", 14F);
            numericUpDownSellQuantity.Location = new Point(318, 171);
            numericUpDownSellQuantity.Name = "numericUpDownSellQuantity";
            numericUpDownSellQuantity.Size = new Size(153, 32);
            numericUpDownSellQuantity.TabIndex = 4;
            // 
            // buttonSell
            // 
            buttonSell.Font = new Font("Segoe UI", 14F);
            buttonSell.Location = new Point(228, 304);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(106, 47);
            buttonSell.TabIndex = 5;
            buttonSell.Text = "Sell";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += buttonSell_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(228, 173);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 6;
            label1.Text = "Quantity";
            // 
            // buttonSellAll
            // 
            buttonSellAll.Font = new Font("Segoe UI", 14F);
            buttonSellAll.Location = new Point(365, 304);
            buttonSellAll.Name = "buttonSellAll";
            buttonSellAll.Size = new Size(106, 47);
            buttonSellAll.TabIndex = 7;
            buttonSellAll.Text = "Sell All";
            buttonSellAll.UseVisualStyleBackColor = true;
            buttonSellAll.Click += buttonSellAll_Click;
            // 
            // InventoryPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSellAll);
            Controls.Add(label1);
            Controls.Add(buttonSell);
            Controls.Add(numericUpDownSellQuantity);
            Controls.Add(labelTotalPrice);
            Controls.Add(labelStock);
            Controls.Add(labelUnitPrice);
            Controls.Add(listBoxInventory);
            Name = "InventoryPage";
            Size = new Size(570, 426);
            ((System.ComponentModel.ISupportInitialize)numericUpDownSellQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxInventory;
        private Label labelUnitPrice;
        private Label labelStock;
        private Label labelTotalPrice;
        private NumericUpDown numericUpDownSellQuantity;
        private Button buttonSell;
        private Label label1;
        private Button buttonSellAll;
    }
}
