namespace Esp32IfTest
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelOperation = new System.Windows.Forms.Panel();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.buttonRollMultiStart = new System.Windows.Forms.Button();
			this.buttonRollMultiStop = new System.Windows.Forms.Button();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.buttonLedStart = new System.Windows.Forms.Button();
			this.buttonLedStop = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.trackBarServo2 = new System.Windows.Forms.TrackBar();
			this.trackBarServo1 = new System.Windows.Forms.TrackBar();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.buttonRollStart = new System.Windows.Forms.Button();
			this.buttonRollStop = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.buttonSpiLibStop = new System.Windows.Forms.Button();
			this.buttonSpiLibStart = new System.Windows.Forms.Button();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.buttonSpiStop = new System.Windows.Forms.Button();
			this.buttonSpiStart = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.buttonI2cLibStop = new System.Windows.Forms.Button();
			this.buttonI2cLibStart = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.buttonI2cStop = new System.Windows.Forms.Button();
			this.buttonI2cStart = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButton3v = new System.Windows.Forms.RadioButton();
			this.radioButton1v = new System.Windows.Forms.RadioButton();
			this.buttonFastStop = new System.Windows.Forms.Button();
			this.buttonFastStart = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.trackBarDac2 = new System.Windows.Forms.TrackBar();
			this.trackBarDac1 = new System.Windows.Forms.TrackBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonTouchStop = new System.Windows.Forms.Button();
			this.buttonTouchStart = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.loggingTextBox1 = new Rapidnack.Common.LoggingTextBox();
			this.plotView1 = new OxyPlot.WindowsForms.PlotView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1.SuspendLayout();
			this.panelOperation.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarServo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarServo1)).BeginInit();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarDac2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarDac1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panelOperation);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Controls.Add(this.buttonOpen);
			this.panel1.Controls.Add(this.textBoxAddress);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(314, 441);
			this.panel1.TabIndex = 0;
			// 
			// panelOperation
			// 
			this.panelOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOperation.Controls.Add(this.groupBox12);
			this.panelOperation.Controls.Add(this.groupBox11);
			this.panelOperation.Controls.Add(this.groupBox1);
			this.panelOperation.Controls.Add(this.groupBox5);
			this.panelOperation.Controls.Add(this.groupBox10);
			this.panelOperation.Controls.Add(this.groupBox9);
			this.panelOperation.Controls.Add(this.groupBox8);
			this.panelOperation.Controls.Add(this.groupBox7);
			this.panelOperation.Controls.Add(this.groupBox6);
			this.panelOperation.Controls.Add(this.groupBox4);
			this.panelOperation.Controls.Add(this.groupBox2);
			this.panelOperation.Location = new System.Drawing.Point(0, 41);
			this.panelOperation.Name = "panelOperation";
			this.panelOperation.Size = new System.Drawing.Size(314, 400);
			this.panelOperation.TabIndex = 3;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.buttonRollMultiStart);
			this.groupBox12.Controls.Add(this.buttonRollMultiStop);
			this.groupBox12.Location = new System.Drawing.Point(161, 3);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(147, 59);
			this.groupBox12.TabIndex = 5;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "ADC4-7 (Roll)";
			// 
			// buttonRollMultiStart
			// 
			this.buttonRollMultiStart.Location = new System.Drawing.Point(5, 22);
			this.buttonRollMultiStart.Name = "buttonRollMultiStart";
			this.buttonRollMultiStart.Size = new System.Drawing.Size(65, 27);
			this.buttonRollMultiStart.TabIndex = 0;
			this.buttonRollMultiStart.Text = "Start";
			this.buttonRollMultiStart.UseVisualStyleBackColor = true;
			this.buttonRollMultiStart.Click += new System.EventHandler(this.buttonRollMultiStart_Click);
			// 
			// buttonRollMultiStop
			// 
			this.buttonRollMultiStop.Location = new System.Drawing.Point(76, 22);
			this.buttonRollMultiStop.Name = "buttonRollMultiStop";
			this.buttonRollMultiStop.Size = new System.Drawing.Size(65, 27);
			this.buttonRollMultiStop.TabIndex = 1;
			this.buttonRollMultiStop.Text = "Stop";
			this.buttonRollMultiStop.UseVisualStyleBackColor = true;
			this.buttonRollMultiStop.Click += new System.EventHandler(this.buttonRollMultiStop_Click);
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.buttonLedStart);
			this.groupBox11.Controls.Add(this.buttonLedStop);
			this.groupBox11.Location = new System.Drawing.Point(8, 68);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(147, 59);
			this.groupBox11.TabIndex = 1;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "LED (pin 16)";
			// 
			// buttonLedStart
			// 
			this.buttonLedStart.Location = new System.Drawing.Point(5, 22);
			this.buttonLedStart.Name = "buttonLedStart";
			this.buttonLedStart.Size = new System.Drawing.Size(65, 27);
			this.buttonLedStart.TabIndex = 0;
			this.buttonLedStart.Text = "Start";
			this.buttonLedStart.UseVisualStyleBackColor = true;
			this.buttonLedStart.Click += new System.EventHandler(this.buttonLedStart_Click);
			// 
			// buttonLedStop
			// 
			this.buttonLedStop.Location = new System.Drawing.Point(76, 22);
			this.buttonLedStop.Name = "buttonLedStop";
			this.buttonLedStop.Size = new System.Drawing.Size(65, 27);
			this.buttonLedStop.TabIndex = 1;
			this.buttonLedStop.Text = "Stop";
			this.buttonLedStop.UseVisualStyleBackColor = true;
			this.buttonLedStop.Click += new System.EventHandler(this.buttonLedStop_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.trackBarServo2);
			this.groupBox5.Controls.Add(this.trackBarServo1);
			this.groupBox5.Location = new System.Drawing.Point(8, 299);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(147, 95);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "LEDC (pin 27,17)";
			// 
			// trackBarServo2
			// 
			this.trackBarServo2.AutoSize = false;
			this.trackBarServo2.LargeChange = 200;
			this.trackBarServo2.Location = new System.Drawing.Point(6, 56);
			this.trackBarServo2.Maximum = 2500;
			this.trackBarServo2.Minimum = 500;
			this.trackBarServo2.Name = "trackBarServo2";
			this.trackBarServo2.Size = new System.Drawing.Size(136, 28);
			this.trackBarServo2.SmallChange = 50;
			this.trackBarServo2.TabIndex = 1;
			this.trackBarServo2.TickFrequency = 500;
			this.trackBarServo2.Value = 1500;
			this.trackBarServo2.Scroll += new System.EventHandler(this.trackBarServo2_Scroll);
			// 
			// trackBarServo1
			// 
			this.trackBarServo1.AutoSize = false;
			this.trackBarServo1.LargeChange = 200;
			this.trackBarServo1.Location = new System.Drawing.Point(5, 22);
			this.trackBarServo1.Maximum = 2500;
			this.trackBarServo1.Minimum = 500;
			this.trackBarServo1.Name = "trackBarServo1";
			this.trackBarServo1.Size = new System.Drawing.Size(136, 28);
			this.trackBarServo1.SmallChange = 50;
			this.trackBarServo1.TabIndex = 0;
			this.trackBarServo1.TickFrequency = 500;
			this.trackBarServo1.Value = 1500;
			this.trackBarServo1.Scroll += new System.EventHandler(this.trackBarServo1_Scroll);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.buttonRollStart);
			this.groupBox10.Controls.Add(this.buttonRollStop);
			this.groupBox10.Location = new System.Drawing.Point(8, 133);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(147, 59);
			this.groupBox10.TabIndex = 2;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "ADC3 (Roll)";
			// 
			// buttonRollStart
			// 
			this.buttonRollStart.Location = new System.Drawing.Point(5, 22);
			this.buttonRollStart.Name = "buttonRollStart";
			this.buttonRollStart.Size = new System.Drawing.Size(65, 27);
			this.buttonRollStart.TabIndex = 0;
			this.buttonRollStart.Text = "Start";
			this.buttonRollStart.UseVisualStyleBackColor = true;
			this.buttonRollStart.Click += new System.EventHandler(this.buttonRollStart_Click);
			// 
			// buttonRollStop
			// 
			this.buttonRollStop.Location = new System.Drawing.Point(76, 22);
			this.buttonRollStop.Name = "buttonRollStop";
			this.buttonRollStop.Size = new System.Drawing.Size(65, 27);
			this.buttonRollStop.TabIndex = 1;
			this.buttonRollStop.Text = "Stop";
			this.buttonRollStop.UseVisualStyleBackColor = true;
			this.buttonRollStop.Click += new System.EventHandler(this.buttonRollStop_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.buttonSpiLibStop);
			this.groupBox9.Controls.Add(this.buttonSpiLibStart);
			this.groupBox9.Location = new System.Drawing.Point(161, 341);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(147, 56);
			this.groupBox9.TabIndex = 10;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "AD9833 (Lib)";
			// 
			// buttonSpiLibStop
			// 
			this.buttonSpiLibStop.Location = new System.Drawing.Point(77, 22);
			this.buttonSpiLibStop.Name = "buttonSpiLibStop";
			this.buttonSpiLibStop.Size = new System.Drawing.Size(65, 27);
			this.buttonSpiLibStop.TabIndex = 1;
			this.buttonSpiLibStop.Text = "Stop";
			this.buttonSpiLibStop.UseVisualStyleBackColor = true;
			this.buttonSpiLibStop.Click += new System.EventHandler(this.buttonSpiLibStop_Click);
			// 
			// buttonSpiLibStart
			// 
			this.buttonSpiLibStart.Location = new System.Drawing.Point(6, 22);
			this.buttonSpiLibStart.Name = "buttonSpiLibStart";
			this.buttonSpiLibStart.Size = new System.Drawing.Size(65, 27);
			this.buttonSpiLibStart.TabIndex = 0;
			this.buttonSpiLibStart.Text = "Start";
			this.buttonSpiLibStart.UseVisualStyleBackColor = true;
			this.buttonSpiLibStart.Click += new System.EventHandler(this.buttonSpiLibStart_Click);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.buttonSpiStop);
			this.groupBox8.Controls.Add(this.buttonSpiStart);
			this.groupBox8.Location = new System.Drawing.Point(161, 279);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(147, 56);
			this.groupBox8.TabIndex = 9;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "AD9833 (SPI)";
			// 
			// buttonSpiStop
			// 
			this.buttonSpiStop.Location = new System.Drawing.Point(77, 22);
			this.buttonSpiStop.Name = "buttonSpiStop";
			this.buttonSpiStop.Size = new System.Drawing.Size(65, 27);
			this.buttonSpiStop.TabIndex = 1;
			this.buttonSpiStop.Text = "Stop";
			this.buttonSpiStop.UseVisualStyleBackColor = true;
			this.buttonSpiStop.Click += new System.EventHandler(this.buttonSpiStop_Click);
			// 
			// buttonSpiStart
			// 
			this.buttonSpiStart.Location = new System.Drawing.Point(6, 22);
			this.buttonSpiStart.Name = "buttonSpiStart";
			this.buttonSpiStart.Size = new System.Drawing.Size(65, 27);
			this.buttonSpiStart.TabIndex = 0;
			this.buttonSpiStart.Text = "Start";
			this.buttonSpiStart.UseVisualStyleBackColor = true;
			this.buttonSpiStart.Click += new System.EventHandler(this.buttonSpiStart_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.buttonI2cLibStop);
			this.groupBox7.Controls.Add(this.buttonI2cLibStart);
			this.groupBox7.Location = new System.Drawing.Point(161, 217);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(147, 56);
			this.groupBox7.TabIndex = 8;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "ADXL345 (Lib)";
			// 
			// buttonI2cLibStop
			// 
			this.buttonI2cLibStop.Location = new System.Drawing.Point(77, 22);
			this.buttonI2cLibStop.Name = "buttonI2cLibStop";
			this.buttonI2cLibStop.Size = new System.Drawing.Size(65, 27);
			this.buttonI2cLibStop.TabIndex = 1;
			this.buttonI2cLibStop.Text = "Stop";
			this.buttonI2cLibStop.UseVisualStyleBackColor = true;
			this.buttonI2cLibStop.Click += new System.EventHandler(this.buttonI2cLibStop_Click);
			// 
			// buttonI2cLibStart
			// 
			this.buttonI2cLibStart.Location = new System.Drawing.Point(6, 22);
			this.buttonI2cLibStart.Name = "buttonI2cLibStart";
			this.buttonI2cLibStart.Size = new System.Drawing.Size(65, 27);
			this.buttonI2cLibStart.TabIndex = 0;
			this.buttonI2cLibStart.Text = "Start";
			this.buttonI2cLibStart.UseVisualStyleBackColor = true;
			this.buttonI2cLibStart.Click += new System.EventHandler(this.buttonI2cLibStart_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.buttonI2cStop);
			this.groupBox6.Controls.Add(this.buttonI2cStart);
			this.groupBox6.Location = new System.Drawing.Point(161, 155);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(147, 56);
			this.groupBox6.TabIndex = 7;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "ADXL345 (I2C)";
			// 
			// buttonI2cStop
			// 
			this.buttonI2cStop.Location = new System.Drawing.Point(77, 22);
			this.buttonI2cStop.Name = "buttonI2cStop";
			this.buttonI2cStop.Size = new System.Drawing.Size(65, 27);
			this.buttonI2cStop.TabIndex = 1;
			this.buttonI2cStop.Text = "Stop";
			this.buttonI2cStop.UseVisualStyleBackColor = true;
			this.buttonI2cStop.Click += new System.EventHandler(this.buttonI2cStop_Click);
			// 
			// buttonI2cStart
			// 
			this.buttonI2cStart.Location = new System.Drawing.Point(6, 22);
			this.buttonI2cStart.Name = "buttonI2cStart";
			this.buttonI2cStart.Size = new System.Drawing.Size(65, 27);
			this.buttonI2cStart.TabIndex = 0;
			this.buttonI2cStart.Text = "Start";
			this.buttonI2cStart.UseVisualStyleBackColor = true;
			this.buttonI2cStart.Click += new System.EventHandler(this.buttonI2cStart_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButton3v);
			this.groupBox4.Controls.Add(this.radioButton1v);
			this.groupBox4.Controls.Add(this.buttonFastStop);
			this.groupBox4.Controls.Add(this.buttonFastStart);
			this.groupBox4.Location = new System.Drawing.Point(161, 68);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(147, 81);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "ADC0 (Fast)";
			// 
			// radioButton3v
			// 
			this.radioButton3v.AutoSize = true;
			this.radioButton3v.Checked = true;
			this.radioButton3v.Location = new System.Drawing.Point(82, 25);
			this.radioButton3v.Name = "radioButton3v";
			this.radioButton3v.Size = new System.Drawing.Size(55, 20);
			this.radioButton3v.TabIndex = 3;
			this.radioButton3v.TabStop = true;
			this.radioButton3v.Text = "3.3V";
			this.radioButton3v.UseVisualStyleBackColor = true;
			// 
			// radioButton1v
			// 
			this.radioButton1v.AutoSize = true;
			this.radioButton1v.Location = new System.Drawing.Point(11, 25);
			this.radioButton1v.Name = "radioButton1v";
			this.radioButton1v.Size = new System.Drawing.Size(55, 20);
			this.radioButton1v.TabIndex = 2;
			this.radioButton1v.Text = "1.1V";
			this.radioButton1v.UseVisualStyleBackColor = true;
			this.radioButton1v.CheckedChanged += new System.EventHandler(this.radioButton1v_CheckedChanged);
			// 
			// buttonFastStop
			// 
			this.buttonFastStop.Location = new System.Drawing.Point(77, 48);
			this.buttonFastStop.Name = "buttonFastStop";
			this.buttonFastStop.Size = new System.Drawing.Size(65, 27);
			this.buttonFastStop.TabIndex = 1;
			this.buttonFastStop.Text = "Stop";
			this.buttonFastStop.UseVisualStyleBackColor = true;
			this.buttonFastStop.Click += new System.EventHandler(this.buttonFastStop_Click);
			// 
			// buttonFastStart
			// 
			this.buttonFastStart.Location = new System.Drawing.Point(6, 48);
			this.buttonFastStart.Name = "buttonFastStart";
			this.buttonFastStart.Size = new System.Drawing.Size(65, 27);
			this.buttonFastStart.TabIndex = 0;
			this.buttonFastStart.Text = "Start";
			this.buttonFastStart.UseVisualStyleBackColor = true;
			this.buttonFastStart.Click += new System.EventHandler(this.buttonFastStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.trackBarDac2);
			this.groupBox2.Controls.Add(this.trackBarDac1);
			this.groupBox2.Location = new System.Drawing.Point(8, 198);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(147, 95);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "DAC (pin 25,26)";
			// 
			// trackBarDac2
			// 
			this.trackBarDac2.AutoSize = false;
			this.trackBarDac2.LargeChange = 10;
			this.trackBarDac2.Location = new System.Drawing.Point(6, 55);
			this.trackBarDac2.Maximum = 255;
			this.trackBarDac2.Name = "trackBarDac2";
			this.trackBarDac2.Size = new System.Drawing.Size(136, 30);
			this.trackBarDac2.TabIndex = 1;
			this.trackBarDac2.Scroll += new System.EventHandler(this.trackBarDac2_Scroll);
			// 
			// trackBarDac1
			// 
			this.trackBarDac1.AutoSize = false;
			this.trackBarDac1.LargeChange = 10;
			this.trackBarDac1.Location = new System.Drawing.Point(6, 19);
			this.trackBarDac1.Maximum = 255;
			this.trackBarDac1.Name = "trackBarDac1";
			this.trackBarDac1.Size = new System.Drawing.Size(135, 30);
			this.trackBarDac1.TabIndex = 0;
			this.trackBarDac1.Scroll += new System.EventHandler(this.trackBarDac1_Scroll);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonTouchStop);
			this.groupBox1.Controls.Add(this.buttonTouchStart);
			this.groupBox1.Location = new System.Drawing.Point(8, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(147, 59);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Touch (pin 12-15)";
			// 
			// buttonTouchStop
			// 
			this.buttonTouchStop.Location = new System.Drawing.Point(77, 22);
			this.buttonTouchStop.Name = "buttonTouchStop";
			this.buttonTouchStop.Size = new System.Drawing.Size(65, 27);
			this.buttonTouchStop.TabIndex = 1;
			this.buttonTouchStop.Text = "Stop";
			this.buttonTouchStop.UseVisualStyleBackColor = true;
			this.buttonTouchStop.Click += new System.EventHandler(this.buttonTouchStop_Click);
			// 
			// buttonTouchStart
			// 
			this.buttonTouchStart.Location = new System.Drawing.Point(6, 22);
			this.buttonTouchStart.Name = "buttonTouchStart";
			this.buttonTouchStart.Size = new System.Drawing.Size(65, 27);
			this.buttonTouchStart.TabIndex = 0;
			this.buttonTouchStart.Text = "Start";
			this.buttonTouchStart.UseVisualStyleBackColor = true;
			this.buttonTouchStart.Click += new System.EventHandler(this.buttonTouchStart_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(238, 8);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(65, 27);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(167, 8);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(65, 27);
			this.buttonOpen.TabIndex = 1;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Location = new System.Drawing.Point(14, 10);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(136, 23);
			this.textBoxAddress.TabIndex = 0;
			// 
			// loggingTextBox1
			// 
			this.loggingTextBox1.BackColor = System.Drawing.SystemColors.Window;
			this.loggingTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loggingTextBox1.Location = new System.Drawing.Point(0, 0);
			this.loggingTextBox1.Multiline = true;
			this.loggingTextBox1.Name = "loggingTextBox1";
			this.loggingTextBox1.ReadOnly = true;
			this.loggingTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.loggingTextBox1.Size = new System.Drawing.Size(310, 217);
			this.loggingTextBox1.TabIndex = 0;
			// 
			// plotView1
			// 
			this.plotView1.BackColor = System.Drawing.SystemColors.Window;
			this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotView1.Location = new System.Drawing.Point(0, 0);
			this.plotView1.Name = "plotView1";
			this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			this.plotView1.Size = new System.Drawing.Size(310, 220);
			this.plotView1.TabIndex = 0;
			this.plotView1.Text = "plotView1";
			this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(314, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.plotView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.loggingTextBox1);
			this.splitContainer1.Size = new System.Drawing.Size(310, 441);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "Form1";
			this.Text = "Esp32IfTest";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelOperation.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBarServo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarServo1)).EndInit();
			this.groupBox10.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBarDac2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarDac1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private Rapidnack.Common.LoggingTextBox loggingTextBox1;
		private System.Windows.Forms.Panel panelOperation;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.Button buttonLedStart;
		private System.Windows.Forms.Button buttonLedStop;
		private OxyPlot.WindowsForms.PlotView plotView1;
		private System.Windows.Forms.Button buttonRollStart;
		private System.Windows.Forms.Button buttonRollStop;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonTouchStop;
		private System.Windows.Forms.Button buttonTouchStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TrackBar trackBarDac2;
		private System.Windows.Forms.TrackBar trackBarDac1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonFastStop;
		private System.Windows.Forms.Button buttonFastStart;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TrackBar trackBarServo1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button buttonI2cStop;
		private System.Windows.Forms.Button buttonI2cStart;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button buttonI2cLibStop;
		private System.Windows.Forms.Button buttonI2cLibStart;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button buttonSpiStop;
		private System.Windows.Forms.Button buttonSpiStart;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Button buttonSpiLibStop;
		private System.Windows.Forms.Button buttonSpiLibStart;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Button buttonRollMultiStart;
		private System.Windows.Forms.Button buttonRollMultiStop;
		private System.Windows.Forms.TrackBar trackBarServo2;
		private System.Windows.Forms.RadioButton radioButton3v;
		private System.Windows.Forms.RadioButton radioButton1v;
	}
}

