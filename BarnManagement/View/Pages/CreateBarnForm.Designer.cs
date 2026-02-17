namespace BarnManagement.View.Pages
{
    partial class CreateBarnForm
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
            groupBox1 = new GroupBox();
            buttonSaveBarn = new Button();
            numericUpDownMaxCapacity = new NumericUpDown();
            textBoxPerson = new TextBox();
            textBoxBarnLocation = new TextBox();
            textBoxBarnName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            labelBarnLocation = new Label();
            labelBarnName = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxCapacity).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSaveBarn);
            groupBox1.Controls.Add(numericUpDownMaxCapacity);
            groupBox1.Controls.Add(textBoxPerson);
            groupBox1.Controls.Add(textBoxBarnLocation);
            groupBox1.Controls.Add(textBoxBarnName);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(labelBarnLocation);
            groupBox1.Controls.Add(labelBarnName);
            groupBox1.Location = new Point(14, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 393);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonSaveBarn
            // 
            buttonSaveBarn.Font = new Font("Segoe UI", 16F);
            buttonSaveBarn.Location = new Point(218, 294);
            buttonSaveBarn.Name = "buttonSaveBarn";
            buttonSaveBarn.Size = new Size(119, 40);
            buttonSaveBarn.TabIndex = 8;
            buttonSaveBarn.Text = "Save";
            buttonSaveBarn.UseVisualStyleBackColor = true;
            buttonSaveBarn.Click += buttonSaveBarn_Click;
            // 
            // numericUpDownMaxCapacity
            // 
            numericUpDownMaxCapacity.Font = new Font("Segoe UI", 16F);
            numericUpDownMaxCapacity.Location = new Point(218, 235);
            numericUpDownMaxCapacity.Name = "numericUpDownMaxCapacity";
            numericUpDownMaxCapacity.Size = new Size(215, 36);
            numericUpDownMaxCapacity.TabIndex = 7;
            // 
            // textBoxPerson
            // 
            textBoxPerson.Font = new Font("Segoe UI", 16F);
            textBoxPerson.Location = new Point(218, 183);
            textBoxPerson.Name = "textBoxPerson";
            textBoxPerson.Size = new Size(215, 36);
            textBoxPerson.TabIndex = 6;
            // 
            // textBoxBarnLocation
            // 
            textBoxBarnLocation.Font = new Font("Segoe UI", 16F);
            textBoxBarnLocation.Location = new Point(218, 131);
            textBoxBarnLocation.Name = "textBoxBarnLocation";
            textBoxBarnLocation.Size = new Size(215, 36);
            textBoxBarnLocation.TabIndex = 5;
            // 
            // textBoxBarnName
            // 
            textBoxBarnName.Font = new Font("Segoe UI", 16F);
            textBoxBarnName.Location = new Point(218, 79);
            textBoxBarnName.Name = "textBoxBarnName";
            textBoxBarnName.Size = new Size(215, 36);
            textBoxBarnName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(70, 241);
            label4.Name = "label4";
            label4.Size = new Size(142, 30);
            label4.TabIndex = 3;
            label4.Text = "Max Capacity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(134, 189);
            label3.Name = "label3";
            label3.Size = new Size(78, 30);
            label3.TabIndex = 2;
            label3.Text = "Person";
            // 
            // labelBarnLocation
            // 
            labelBarnLocation.AutoSize = true;
            labelBarnLocation.Font = new Font("Segoe UI", 16F);
            labelBarnLocation.Location = new Point(118, 137);
            labelBarnLocation.Name = "labelBarnLocation";
            labelBarnLocation.Size = new Size(94, 30);
            labelBarnLocation.TabIndex = 1;
            labelBarnLocation.Text = "Location";
            // 
            // labelBarnName
            // 
            labelBarnName.AutoSize = true;
            labelBarnName.Font = new Font("Segoe UI", 16F);
            labelBarnName.Location = new Point(134, 85);
            labelBarnName.Name = "labelBarnName";
            labelBarnName.Size = new Size(71, 30);
            labelBarnName.TabIndex = 0;
            labelBarnName.Text = "Name";
            // 
            // CreateBarnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "CreateBarnForm";
            Size = new Size(570, 426);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxCapacity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonSaveBarn;
        private NumericUpDown numericUpDownMaxCapacity;
        private TextBox textBoxPerson;
        private TextBox textBoxBarnLocation;
        private TextBox textBoxBarnName;
        private Label label4;
        private Label label3;
        private Label labelBarnLocation;
        private Label labelBarnName;
    }
}
