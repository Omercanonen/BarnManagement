namespace BarnManagement.View.Pages
{
    partial class ProductionPage
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
            listBoxAnimals = new ListBox();
            listBoxReadyToCollect = new ListBox();
            buttonCollect = new Button();
            progressBarProduction = new ProgressBar();
            SuspendLayout();
            // 
            // listBoxAnimals
            // 
            listBoxAnimals.FormattingEnabled = true;
            listBoxAnimals.Location = new Point(20, 35);
            listBoxAnimals.Name = "listBoxAnimals";
            listBoxAnimals.Size = new Size(120, 304);
            listBoxAnimals.TabIndex = 0;
            // 
            // listBoxReadyToCollect
            // 
            listBoxReadyToCollect.FormattingEnabled = true;
            listBoxReadyToCollect.Location = new Point(437, 35);
            listBoxReadyToCollect.Name = "listBoxReadyToCollect";
            listBoxReadyToCollect.Size = new Size(120, 304);
            listBoxReadyToCollect.TabIndex = 1;
            // 
            // buttonCollect
            // 
            buttonCollect.Font = new Font("Segoe UI", 14F);
            buttonCollect.Location = new Point(427, 367);
            buttonCollect.Name = "buttonCollect";
            buttonCollect.Size = new Size(120, 40);
            buttonCollect.TabIndex = 2;
            buttonCollect.Text = "Collect";
            buttonCollect.UseVisualStyleBackColor = true;
            buttonCollect.Click += buttonCollect_Click;
            // 
            // progressBarProduction
            // 
            progressBarProduction.Location = new Point(160, 182);
            progressBarProduction.Name = "progressBarProduction";
            progressBarProduction.Size = new Size(262, 23);
            progressBarProduction.TabIndex = 3;
            // 
            // ProductionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(progressBarProduction);
            Controls.Add(buttonCollect);
            Controls.Add(listBoxReadyToCollect);
            Controls.Add(listBoxAnimals);
            Name = "ProductionPage";
            Size = new Size(570, 426);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxAnimals;
        private ListBox listBoxReadyToCollect;
        private Button buttonCollect;
        private ProgressBar progressBarProduction;
    }
}
