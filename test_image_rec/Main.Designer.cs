namespace test_image_rec
{
    partial class Main
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
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.openImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.СalculateHistogramStandardsButton = new System.Windows.Forms.Button();
            this.DeleteHistogramStandardsButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileImage
            // 
            this.openFileImage.FileName = "openImage";
            // 
            // openImage
            // 
            this.openImage.Location = new System.Drawing.Point(12, 26);
            this.openImage.Name = "openImage";
            this.openImage.Size = new System.Drawing.Size(146, 50);
            this.openImage.TabIndex = 0;
            this.openImage.Text = "Открыть\r\nизображение";
            this.openImage.UseVisualStyleBackColor = true;
            this.openImage.Click += new System.EventHandler(this.openImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Гистограмма изображения";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(164, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 350);
            this.panel1.TabIndex = 2;
            // 
            // СalculateHistogramStandardsButton
            // 
            this.СalculateHistogramStandardsButton.Location = new System.Drawing.Point(859, 26);
            this.СalculateHistogramStandardsButton.Name = "СalculateHistogramStandardsButton";
            this.СalculateHistogramStandardsButton.Size = new System.Drawing.Size(130, 50);
            this.СalculateHistogramStandardsButton.TabIndex = 3;
            this.СalculateHistogramStandardsButton.Text = "Вычислить \r\nгисторраммы эталонов";
            this.СalculateHistogramStandardsButton.UseVisualStyleBackColor = true;
            this.СalculateHistogramStandardsButton.Click += new System.EventHandler(this.СalculateHistogramStandardsButton_Click);
            // 
            // DeleteHistogramStandardsButton
            // 
            this.DeleteHistogramStandardsButton.Location = new System.Drawing.Point(859, 82);
            this.DeleteHistogramStandardsButton.Name = "DeleteHistogramStandardsButton";
            this.DeleteHistogramStandardsButton.Size = new System.Drawing.Size(130, 50);
            this.DeleteHistogramStandardsButton.TabIndex = 4;
            this.DeleteHistogramStandardsButton.Text = "Удалить из памяти \r\nгисторраммы эталонов";
            this.DeleteHistogramStandardsButton.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 83);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(35, 13);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "label2";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 384);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.DeleteHistogramStandardsButton);
            this.Controls.Add(this.СalculateHistogramStandardsButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Comparison of images";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.Button openImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button СalculateHistogramStandardsButton;
        private System.Windows.Forms.Button DeleteHistogramStandardsButton;
        private System.Windows.Forms.Label infoLabel;
    }
}

