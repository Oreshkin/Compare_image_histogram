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
            this.panel1 = new System.Windows.Forms.Panel();
            this.СalculateHistogramStandardsButton = new System.Windows.Forms.Button();
            this.DeleteHistogramStandardsButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.loadingButton = new System.Windows.Forms.Button();
            this.trainingMode = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startCaptureButton = new System.Windows.Forms.Button();
            this.stopCameraButton = new System.Windows.Forms.Button();
            this.rezultLabel = new System.Windows.Forms.Label();
            this.Wbutton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.ConnecGgroupBox = new System.Windows.Forms.GroupBox();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Xbutton = new System.Windows.Forms.Button();
            this.Sbutton = new System.Windows.Forms.Button();
            this.Dbutton = new System.Windows.Forms.Button();
            this.Abutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cameraOnlineCheckBox = new System.Windows.Forms.CheckBox();
            this.captuerButton = new System.Windows.Forms.Button();
            this.cameraOnlineGroupBox = new System.Windows.Forms.GroupBox();
            this.rezultGroupBox = new System.Windows.Forms.GroupBox();
            this.transportLabel = new System.Windows.Forms.Label();
            this.histogramGroupBox = new System.Windows.Forms.GroupBox();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ConnecGgroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cameraOnlineGroupBox.SuspendLayout();
            this.rezultGroupBox.SuspendLayout();
            this.histogramGroupBox.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 350);
            this.panel1.TabIndex = 2;
            // 
            // СalculateHistogramStandardsButton
            // 
            this.СalculateHistogramStandardsButton.Location = new System.Drawing.Point(351, 601);
            this.СalculateHistogramStandardsButton.Name = "СalculateHistogramStandardsButton";
            this.СalculateHistogramStandardsButton.Size = new System.Drawing.Size(114, 52);
            this.СalculateHistogramStandardsButton.TabIndex = 3;
            this.СalculateHistogramStandardsButton.Text = "Вычислить \r\nгисторраммы";
            this.СalculateHistogramStandardsButton.UseVisualStyleBackColor = true;
            this.СalculateHistogramStandardsButton.Click += new System.EventHandler(this.СalculateHistogramStandardsButton_Click);
            // 
            // DeleteHistogramStandardsButton
            // 
            this.DeleteHistogramStandardsButton.Location = new System.Drawing.Point(484, 601);
            this.DeleteHistogramStandardsButton.Name = "DeleteHistogramStandardsButton";
            this.DeleteHistogramStandardsButton.Size = new System.Drawing.Size(122, 52);
            this.DeleteHistogramStandardsButton.TabIndex = 4;
            this.DeleteHistogramStandardsButton.Text = "Удалить из памяти \r\nгисторраммы";
            this.DeleteHistogramStandardsButton.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(7, 21);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(35, 13);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "label2";
            // 
            // loadingButton
            // 
            this.loadingButton.Location = new System.Drawing.Point(612, 601);
            this.loadingButton.Name = "loadingButton";
            this.loadingButton.Size = new System.Drawing.Size(243, 52);
            this.loadingButton.TabIndex = 6;
            this.loadingButton.Text = "Загрузить эталоны";
            this.loadingButton.UseVisualStyleBackColor = true;
            this.loadingButton.Click += new System.EventHandler(this.loadingButton_Click);
            // 
            // trainingMode
            // 
            this.trainingMode.AutoSize = true;
            this.trainingMode.Location = new System.Drawing.Point(31, 5);
            this.trainingMode.Name = "trainingMode";
            this.trainingMode.Size = new System.Drawing.Size(110, 17);
            this.trainingMode.TabIndex = 7;
            this.trainingMode.Text = "Режим обучения";
            this.trainingMode.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(242, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // startCaptureButton
            // 
            this.startCaptureButton.Location = new System.Drawing.Point(6, 45);
            this.startCaptureButton.Name = "startCaptureButton";
            this.startCaptureButton.Size = new System.Drawing.Size(116, 37);
            this.startCaptureButton.TabIndex = 10;
            this.startCaptureButton.Text = "Start";
            this.startCaptureButton.UseVisualStyleBackColor = true;
            this.startCaptureButton.Click += new System.EventHandler(this.startCaptureButton_Click);
            // 
            // stopCameraButton
            // 
            this.stopCameraButton.Location = new System.Drawing.Point(132, 45);
            this.stopCameraButton.Name = "stopCameraButton";
            this.stopCameraButton.Size = new System.Drawing.Size(116, 37);
            this.stopCameraButton.TabIndex = 11;
            this.stopCameraButton.Text = "STOP";
            this.stopCameraButton.UseVisualStyleBackColor = true;
            this.stopCameraButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // rezultLabel
            // 
            this.rezultLabel.AutoSize = true;
            this.rezultLabel.Location = new System.Drawing.Point(7, 18);
            this.rezultLabel.Name = "rezultLabel";
            this.rezultLabel.Size = new System.Drawing.Size(99, 13);
            this.rezultLabel.TabIndex = 12;
            this.rezultLabel.Text = "Объект не найден";
            // 
            // Wbutton
            // 
            this.Wbutton.Location = new System.Drawing.Point(87, 19);
            this.Wbutton.Name = "Wbutton";
            this.Wbutton.Size = new System.Drawing.Size(60, 40);
            this.Wbutton.TabIndex = 13;
            this.Wbutton.Text = "Вперёд";
            this.Wbutton.UseVisualStyleBackColor = true;
            this.Wbutton.Click += new System.EventHandler(this.Wbutton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(6, 19);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(144, 23);
            this.connectButton.TabIndex = 14;
            this.connectButton.Text = "Подключение";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ConnecGgroupBox
            // 
            this.ConnecGgroupBox.Controls.Add(this.portsComboBox);
            this.ConnecGgroupBox.Controls.Add(this.connectButton);
            this.ConnecGgroupBox.Location = new System.Drawing.Point(6, 134);
            this.ConnecGgroupBox.Name = "ConnecGgroupBox";
            this.ConnecGgroupBox.Size = new System.Drawing.Size(156, 75);
            this.ConnecGgroupBox.TabIndex = 17;
            this.ConnecGgroupBox.TabStop = false;
            this.ConnecGgroupBox.Text = "Подключение к ARDUINO";
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(6, 48);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(144, 21);
            this.portsComboBox.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Xbutton);
            this.groupBox2.Controls.Add(this.Abutton);
            this.groupBox2.Controls.Add(this.ConnecGgroupBox);
            this.groupBox2.Controls.Add(this.Sbutton);
            this.groupBox2.Controls.Add(this.Dbutton);
            this.groupBox2.Controls.Add(this.Wbutton);
            this.groupBox2.Location = new System.Drawing.Point(612, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 212);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Управление";
            // 
            // Xbutton
            // 
            this.Xbutton.Location = new System.Drawing.Point(173, 143);
            this.Xbutton.Name = "Xbutton";
            this.Xbutton.Size = new System.Drawing.Size(60, 60);
            this.Xbutton.TabIndex = 17;
            this.Xbutton.Text = "STOP";
            this.Xbutton.UseVisualStyleBackColor = true;
            this.Xbutton.Click += new System.EventHandler(this.Xbutton_Click);
            // 
            // Sbutton
            // 
            this.Sbutton.Location = new System.Drawing.Point(87, 88);
            this.Sbutton.Name = "Sbutton";
            this.Sbutton.Size = new System.Drawing.Size(60, 40);
            this.Sbutton.TabIndex = 16;
            this.Sbutton.Text = "Назад";
            this.Sbutton.UseVisualStyleBackColor = true;
            this.Sbutton.Click += new System.EventHandler(this.Sbutton_Click);
            // 
            // Dbutton
            // 
            this.Dbutton.Location = new System.Drawing.Point(163, 45);
            this.Dbutton.Name = "Dbutton";
            this.Dbutton.Size = new System.Drawing.Size(60, 60);
            this.Dbutton.TabIndex = 15;
            this.Dbutton.Text = "Вправо";
            this.Dbutton.UseVisualStyleBackColor = true;
            this.Dbutton.Click += new System.EventHandler(this.Dbutton_Click);
            // 
            // Abutton
            // 
            this.Abutton.Location = new System.Drawing.Point(12, 45);
            this.Abutton.Name = "Abutton";
            this.Abutton.Size = new System.Drawing.Size(60, 60);
            this.Abutton.TabIndex = 14;
            this.Abutton.Text = "Влево";
            this.Abutton.UseVisualStyleBackColor = true;
            this.Abutton.Click += new System.EventHandler(this.Abutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.captuerButton);
            this.groupBox1.Controls.Add(this.cameraOnlineCheckBox);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.startCaptureButton);
            this.groupBox1.Controls.Add(this.stopCameraButton);
            this.groupBox1.Location = new System.Drawing.Point(351, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 150);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение к камере";
            // 
            // cameraOnlineCheckBox
            // 
            this.cameraOnlineCheckBox.AutoSize = true;
            this.cameraOnlineCheckBox.Location = new System.Drawing.Point(49, 88);
            this.cameraOnlineCheckBox.Name = "cameraOnlineCheckBox";
            this.cameraOnlineCheckBox.Size = new System.Drawing.Size(146, 17);
            this.cameraOnlineCheckBox.TabIndex = 12;
            this.cameraOnlineCheckBox.Text = "Просмотр видео в окне";
            this.cameraOnlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // captuerButton
            // 
            this.captuerButton.Location = new System.Drawing.Point(6, 111);
            this.captuerButton.Name = "captuerButton";
            this.captuerButton.Size = new System.Drawing.Size(242, 34);
            this.captuerButton.TabIndex = 20;
            this.captuerButton.Text = "Снимок";
            this.captuerButton.UseVisualStyleBackColor = true;
            this.captuerButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cameraOnlineGroupBox
            // 
            this.cameraOnlineGroupBox.Controls.Add(this.pictureBox1);
            this.cameraOnlineGroupBox.Location = new System.Drawing.Point(12, 386);
            this.cameraOnlineGroupBox.Name = "cameraOnlineGroupBox";
            this.cameraOnlineGroupBox.Size = new System.Drawing.Size(333, 267);
            this.cameraOnlineGroupBox.TabIndex = 21;
            this.cameraOnlineGroupBox.TabStop = false;
            this.cameraOnlineGroupBox.Text = "Трансляция с камеры";
            // 
            // rezultGroupBox
            // 
            this.rezultGroupBox.Controls.Add(this.transportLabel);
            this.rezultGroupBox.Controls.Add(this.rezultLabel);
            this.rezultGroupBox.Location = new System.Drawing.Point(351, 542);
            this.rezultGroupBox.Name = "rezultGroupBox";
            this.rezultGroupBox.Size = new System.Drawing.Size(255, 56);
            this.rezultGroupBox.TabIndex = 22;
            this.rezultGroupBox.TabStop = false;
            this.rezultGroupBox.Text = "Результат";
            // 
            // transportLabel
            // 
            this.transportLabel.AutoSize = true;
            this.transportLabel.Location = new System.Drawing.Point(7, 37);
            this.transportLabel.Name = "transportLabel";
            this.transportLabel.Size = new System.Drawing.Size(107, 13);
            this.transportLabel.TabIndex = 13;
            this.transportLabel.Text = "Робот не двигается";
            // 
            // histogramGroupBox
            // 
            this.histogramGroupBox.Controls.Add(this.panel1);
            this.histogramGroupBox.Location = new System.Drawing.Point(164, 5);
            this.histogramGroupBox.Name = "histogramGroupBox";
            this.histogramGroupBox.Size = new System.Drawing.Size(691, 375);
            this.histogramGroupBox.TabIndex = 23;
            this.histogramGroupBox.TabStop = false;
            this.histogramGroupBox.Text = "Гистаграмма изображения";
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.infoLabel);
            this.infoGroupBox.Location = new System.Drawing.Point(12, 82);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(146, 298);
            this.infoGroupBox.TabIndex = 24;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Информация о эталонах";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 667);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.histogramGroupBox);
            this.Controls.Add(this.rezultGroupBox);
            this.Controls.Add(this.cameraOnlineGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.trainingMode);
            this.Controls.Add(this.loadingButton);
            this.Controls.Add(this.DeleteHistogramStandardsButton);
            this.Controls.Add(this.СalculateHistogramStandardsButton);
            this.Controls.Add(this.openImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сравнение изображений";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ConnecGgroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cameraOnlineGroupBox.ResumeLayout(false);
            this.rezultGroupBox.ResumeLayout(false);
            this.rezultGroupBox.PerformLayout();
            this.histogramGroupBox.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.Button openImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button СalculateHistogramStandardsButton;
        private System.Windows.Forms.Button DeleteHistogramStandardsButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button loadingButton;
        private System.Windows.Forms.CheckBox trainingMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button startCaptureButton;
        private System.Windows.Forms.Button stopCameraButton;
        private System.Windows.Forms.Label rezultLabel;
        private System.Windows.Forms.Button Wbutton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox ConnecGgroupBox;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Xbutton;
        private System.Windows.Forms.Button Sbutton;
        private System.Windows.Forms.Button Dbutton;
        private System.Windows.Forms.Button Abutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button captuerButton;
        private System.Windows.Forms.CheckBox cameraOnlineCheckBox;
        private System.Windows.Forms.GroupBox cameraOnlineGroupBox;
        private System.Windows.Forms.GroupBox rezultGroupBox;
        private System.Windows.Forms.GroupBox histogramGroupBox;
        private System.Windows.Forms.Label transportLabel;
        private System.Windows.Forms.GroupBox infoGroupBox;
    }
}

