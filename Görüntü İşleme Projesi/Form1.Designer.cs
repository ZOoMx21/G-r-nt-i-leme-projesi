namespace Görüntü_İşleme_Projesi
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.secBtn = new System.Windows.Forms.Button();
            this.pathLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kontrastTxt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.parlaklikTxt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.X11txt = new System.Windows.Forms.TextBox();
            this.Y11txt = new System.Windows.Forms.TextBox();
            this.X22txt = new System.Windows.Forms.TextBox();
            this.Y22txt = new System.Windows.Forms.TextBox();
            this.X33txt = new System.Windows.Forms.TextBox();
            this.Y33txt = new System.Windows.Forms.TextBox();
            this.X44txt = new System.Windows.Forms.TextBox();
            this.Y44txt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.x1txt = new System.Windows.Forms.TextBox();
            this.x2txt = new System.Windows.Forms.TextBox();
            this.x3txt = new System.Windows.Forms.TextBox();
            this.x4txt = new System.Windows.Forms.TextBox();
            this.y1txt = new System.Windows.Forms.TextBox();
            this.y2txt = new System.Windows.Forms.TextBox();
            this.y3txt = new System.Windows.Forms.TextBox();
            this.y4txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.otelemeY = new System.Windows.Forms.TextBox();
            this.otelemeX = new System.Windows.Forms.TextBox();
            this.aciLbl = new System.Windows.Forms.Label();
            this.aci_Box = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sonucBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // secBtn
            // 
            this.secBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secBtn.Location = new System.Drawing.Point(411, 15);
            this.secBtn.Name = "secBtn";
            this.secBtn.Size = new System.Drawing.Size(75, 23);
            this.secBtn.TabIndex = 0;
            this.secBtn.Text = "Seç";
            this.secBtn.UseVisualStyleBackColor = true;
            this.secBtn.Click += new System.EventHandler(this.secBtn_Click);
            // 
            // pathLbl
            // 
            this.pathLbl.AutoSize = true;
            this.pathLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathLbl.Location = new System.Drawing.Point(6, 19);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(107, 15);
            this.pathLbl.TabIndex = 1;
            this.pathLbl.Text = "Dosya seçmediniz..";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pathLbl);
            this.groupBox1.Controls.Add(this.secBtn);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(367, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 46);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Görüntü Seçmek";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(879, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 199);
            this.listBox1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kontrastTxt);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.parlaklikTxt);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.X11txt);
            this.groupBox3.Controls.Add(this.Y11txt);
            this.groupBox3.Controls.Add(this.X22txt);
            this.groupBox3.Controls.Add(this.Y22txt);
            this.groupBox3.Controls.Add(this.X33txt);
            this.groupBox3.Controls.Add(this.Y33txt);
            this.groupBox3.Controls.Add(this.X44txt);
            this.groupBox3.Controls.Add(this.Y44txt);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.x1txt);
            this.groupBox3.Controls.Add(this.x2txt);
            this.groupBox3.Controls.Add(this.x3txt);
            this.groupBox3.Controls.Add(this.x4txt);
            this.groupBox3.Controls.Add(this.y1txt);
            this.groupBox3.Controls.Add(this.y2txt);
            this.groupBox3.Controls.Add(this.y3txt);
            this.groupBox3.Controls.Add(this.y4txt);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.otelemeY);
            this.groupBox3.Controls.Add(this.otelemeX);
            this.groupBox3.Controls.Add(this.aciLbl);
            this.groupBox3.Controls.Add(this.aci_Box);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.sonucBtn);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(367, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 203);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sonuç";
            // 
            // kontrastTxt
            // 
            this.kontrastTxt.Location = new System.Drawing.Point(245, 64);
            this.kontrastTxt.Name = "kontrastTxt";
            this.kontrastTxt.Size = new System.Drawing.Size(38, 23);
            this.kontrastTxt.TabIndex = 51;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(191, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 50;
            this.label20.Text = "Kontrast";
            // 
            // parlaklikTxt
            // 
            this.parlaklikTxt.Location = new System.Drawing.Point(324, 34);
            this.parlaklikTxt.Name = "parlaklikTxt";
            this.parlaklikTxt.Size = new System.Drawing.Size(38, 23);
            this.parlaklikTxt.TabIndex = 49;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(268, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 15);
            this.label19.TabIndex = 48;
            this.label19.Text = "Parlaklık:";
            // 
            // X11txt
            // 
            this.X11txt.Location = new System.Drawing.Point(25, 174);
            this.X11txt.Name = "X11txt";
            this.X11txt.Size = new System.Drawing.Size(38, 23);
            this.X11txt.TabIndex = 47;
            // 
            // Y11txt
            // 
            this.Y11txt.Location = new System.Drawing.Point(81, 174);
            this.Y11txt.Name = "Y11txt";
            this.Y11txt.Size = new System.Drawing.Size(38, 23);
            this.Y11txt.TabIndex = 46;
            // 
            // X22txt
            // 
            this.X22txt.Location = new System.Drawing.Point(140, 174);
            this.X22txt.Name = "X22txt";
            this.X22txt.Size = new System.Drawing.Size(38, 23);
            this.X22txt.TabIndex = 45;
            // 
            // Y22txt
            // 
            this.Y22txt.Location = new System.Drawing.Point(200, 174);
            this.Y22txt.Name = "Y22txt";
            this.Y22txt.Size = new System.Drawing.Size(38, 23);
            this.Y22txt.TabIndex = 44;
            // 
            // X33txt
            // 
            this.X33txt.Location = new System.Drawing.Point(263, 174);
            this.X33txt.Name = "X33txt";
            this.X33txt.Size = new System.Drawing.Size(38, 23);
            this.X33txt.TabIndex = 43;
            // 
            // Y33txt
            // 
            this.Y33txt.Location = new System.Drawing.Point(324, 174);
            this.Y33txt.Name = "Y33txt";
            this.Y33txt.Size = new System.Drawing.Size(38, 23);
            this.Y33txt.TabIndex = 42;
            // 
            // X44txt
            // 
            this.X44txt.Location = new System.Drawing.Point(386, 174);
            this.X44txt.Name = "X44txt";
            this.X44txt.Size = new System.Drawing.Size(38, 23);
            this.X44txt.TabIndex = 41;
            // 
            // Y44txt
            // 
            this.Y44txt.Location = new System.Drawing.Point(448, 174);
            this.Y44txt.Name = "Y44txt";
            this.Y44txt.Size = new System.Drawing.Size(38, 23);
            this.Y44txt.TabIndex = 40;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(366, 177);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 15);
            this.label18.TabIndex = 39;
            this.label18.Text = "X4";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(243, 177);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 38;
            this.label17.Text = "X3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(304, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 15);
            this.label16.TabIndex = 37;
            this.label16.Text = "Y3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "X1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 15);
            this.label14.TabIndex = 35;
            this.label14.Text = "Y1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(120, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 15);
            this.label13.TabIndex = 34;
            this.label13.Text = "X2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(180, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 15);
            this.label12.TabIndex = 33;
            this.label12.Text = "Y2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(430, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Y4";
            // 
            // x1txt
            // 
            this.x1txt.Location = new System.Drawing.Point(89, 105);
            this.x1txt.Name = "x1txt";
            this.x1txt.Size = new System.Drawing.Size(38, 23);
            this.x1txt.TabIndex = 31;
            // 
            // x2txt
            // 
            this.x2txt.Location = new System.Drawing.Point(156, 105);
            this.x2txt.Name = "x2txt";
            this.x2txt.Size = new System.Drawing.Size(38, 23);
            this.x2txt.TabIndex = 30;
            // 
            // x3txt
            // 
            this.x3txt.Location = new System.Drawing.Point(222, 105);
            this.x3txt.Name = "x3txt";
            this.x3txt.Size = new System.Drawing.Size(38, 23);
            this.x3txt.TabIndex = 29;
            // 
            // x4txt
            // 
            this.x4txt.Location = new System.Drawing.Point(289, 105);
            this.x4txt.Name = "x4txt";
            this.x4txt.Size = new System.Drawing.Size(38, 23);
            this.x4txt.TabIndex = 28;
            // 
            // y1txt
            // 
            this.y1txt.Location = new System.Drawing.Point(89, 140);
            this.y1txt.Name = "y1txt";
            this.y1txt.Size = new System.Drawing.Size(38, 23);
            this.y1txt.TabIndex = 27;
            // 
            // y2txt
            // 
            this.y2txt.Location = new System.Drawing.Point(156, 140);
            this.y2txt.Name = "y2txt";
            this.y2txt.Size = new System.Drawing.Size(38, 23);
            this.y2txt.TabIndex = 26;
            // 
            // y3txt
            // 
            this.y3txt.Location = new System.Drawing.Point(222, 140);
            this.y3txt.Name = "y3txt";
            this.y3txt.Size = new System.Drawing.Size(38, 23);
            this.y3txt.TabIndex = 25;
            // 
            // y4txt
            // 
            this.y4txt.Location = new System.Drawing.Point(289, 140);
            this.y4txt.Name = "y4txt";
            this.y4txt.Size = new System.Drawing.Size(38, 23);
            this.y4txt.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "x4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "y4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "y3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "y1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "y2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "x3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "x2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Prespektif x1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Öteleme X";
            // 
            // otelemeY
            // 
            this.otelemeY.Location = new System.Drawing.Point(147, 64);
            this.otelemeY.Name = "otelemeY";
            this.otelemeY.Size = new System.Drawing.Size(38, 23);
            this.otelemeY.TabIndex = 13;
            // 
            // otelemeX
            // 
            this.otelemeX.Location = new System.Drawing.Point(75, 64);
            this.otelemeX.Name = "otelemeX";
            this.otelemeX.Size = new System.Drawing.Size(38, 23);
            this.otelemeX.TabIndex = 12;
            // 
            // aciLbl
            // 
            this.aciLbl.AutoSize = true;
            this.aciLbl.Location = new System.Drawing.Point(133, 37);
            this.aciLbl.Name = "aciLbl";
            this.aciLbl.Size = new System.Drawing.Size(90, 15);
            this.aciLbl.TabIndex = 11;
            this.aciLbl.Text = "Döndürme Açı:";
            // 
            // aci_Box
            // 
            this.aci_Box.Location = new System.Drawing.Point(223, 34);
            this.aci_Box.Name = "aci_Box";
            this.aci_Box.Size = new System.Drawing.Size(38, 23);
            this.aci_Box.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Grayscale",
            "Parlaklık",
            "Kontrast",
            "Threshold",
            "Negative",
            "Gray Negative",
            "Kontrast Germe",
            "Gaussian",
            "Laplas",
            "Ortalama",
            "Medyan",
            "Sobel",
            "Prewitt",
            "Döndür",
            "Aynalama Dikey",
            "Aynalama Yatay",
            "Öteleme",
            "Zoom Out",
            "Zoom In",
            "Netleştirme",
            "Prespektif"});
            this.comboBox1.Location = new System.Drawing.Point(6, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 9;
            // 
            // sonucBtn
            // 
            this.sonucBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sonucBtn.Location = new System.Drawing.Point(411, 34);
            this.sonucBtn.Name = "sonucBtn";
            this.sonucBtn.Size = new System.Drawing.Size(75, 23);
            this.sonucBtn.TabIndex = 0;
            this.sonucBtn.Text = "Göster";
            this.sonucBtn.UseVisualStyleBackColor = true;
            this.sonucBtn.Click += new System.EventHandler(this.sonucBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 279);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 650);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(724, 279);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(650, 650);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1023, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(349, 260);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(879, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Max.Pixel sayısı";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(12, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(343, 260);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 941);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button secBtn;
        private Label pathLbl;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button sonucBtn;
        private ListBox listBox1;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox textBox1;
        private PictureBox pictureBox4;
        private Label aciLbl;
        private TextBox aci_Box;
        private Label label2;
        private Label label1;
        private TextBox otelemeY;
        private TextBox otelemeX;
        private TextBox X11txt;
        private TextBox Y11txt;
        private TextBox X22txt;
        private TextBox Y22txt;
        private TextBox X33txt;
        private TextBox Y33txt;
        private TextBox X44txt;
        private TextBox Y44txt;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private TextBox x1txt;
        private TextBox x2txt;
        private TextBox x3txt;
        private TextBox x4txt;
        private TextBox y1txt;
        private TextBox y2txt;
        private TextBox y3txt;
        private TextBox y4txt;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox parlaklikTxt;
        private Label label19;
        private TextBox kontrastTxt;
        private Label label20;
    }
}