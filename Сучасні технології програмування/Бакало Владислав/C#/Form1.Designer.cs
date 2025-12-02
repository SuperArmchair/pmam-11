namespace BookstoreApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
           
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblBook1 = new System.Windows.Forms.Label();
            this.lblBook2 = new System.Windows.Forms.Label();
            this.lblBook3 = new System.Windows.Forms.Label();
            this.lblBook4 = new System.Windows.Forms.Label();
            this.lblBook5 = new System.Windows.Forms.Label();
            this.nudBook1 = new System.Windows.Forms.NumericUpDown();
            this.nudBook2 = new System.Windows.Forms.NumericUpDown();
            this.nudBook3 = new System.Windows.Forms.NumericUpDown();
            this.nudBook4 = new System.Windows.Forms.NumericUpDown();
            this.nudBook5 = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBook1
            // 
            this.lblBook1.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblBook1.Font = new System.Drawing.Font("Merriweather", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBook1.ForeColor = System.Drawing.Color.Snow;
            this.lblBook1.Location = new System.Drawing.Point(30, 408);
            this.lblBook1.Name = "lblBook1";
            this.lblBook1.Size = new System.Drawing.Size(80, 20);
            this.lblBook1.TabIndex = 0;
            this.lblBook1.Text = "Книга 1:";
            this.lblBook1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBook2
            // 
            this.lblBook2.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblBook2.Font = new System.Drawing.Font("Merriweather", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBook2.ForeColor = System.Drawing.Color.Snow;
            this.lblBook2.Location = new System.Drawing.Point(30, 441);
            this.lblBook2.Name = "lblBook2";
            this.lblBook2.Size = new System.Drawing.Size(80, 20);
            this.lblBook2.TabIndex = 1;
            this.lblBook2.Text = "Книга 2:";
            // 
            // lblBook3
            // 
            this.lblBook3.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblBook3.Font = new System.Drawing.Font("Merriweather", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBook3.ForeColor = System.Drawing.Color.Snow;
            this.lblBook3.Location = new System.Drawing.Point(30, 470);
            this.lblBook3.Name = "lblBook3";
            this.lblBook3.Size = new System.Drawing.Size(80, 20);
            this.lblBook3.TabIndex = 2;
            this.lblBook3.Text = "Книга 3:";
            // 
            // lblBook4
            // 
            this.lblBook4.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblBook4.Font = new System.Drawing.Font("Merriweather", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBook4.ForeColor = System.Drawing.Color.Snow;
            this.lblBook4.Location = new System.Drawing.Point(30, 502);
            this.lblBook4.Name = "lblBook4";
            this.lblBook4.Size = new System.Drawing.Size(80, 20);
            this.lblBook4.TabIndex = 3;
            this.lblBook4.Text = "Книга 4:";
            // 
            // lblBook5
            // 
            this.lblBook5.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblBook5.Font = new System.Drawing.Font("Merriweather", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBook5.ForeColor = System.Drawing.Color.Snow;
            this.lblBook5.Location = new System.Drawing.Point(30, 536);
            this.lblBook5.Name = "lblBook5";
            this.lblBook5.Size = new System.Drawing.Size(80, 20);
            this.lblBook5.TabIndex = 4;
            this.lblBook5.Text = "Книга 5:";
            // 
            // nudBook1
            // 
            this.nudBook1.AutoSize = true;
            this.nudBook1.BackColor = System.Drawing.SystemColors.Window;
            this.nudBook1.Font = new System.Drawing.Font("Merriweather", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBook1.ForeColor = System.Drawing.Color.Sienna;
            this.nudBook1.Location = new System.Drawing.Point(123, 407);
            this.nudBook1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBook1.Name = "nudBook1";
            this.nudBook1.Size = new System.Drawing.Size(50, 26);
            this.nudBook1.TabIndex = 5;
            // 
            // nudBook2
            // 
            this.nudBook2.Font = new System.Drawing.Font("Merriweather", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBook2.ForeColor = System.Drawing.Color.Sienna;
            this.nudBook2.Location = new System.Drawing.Point(123, 534);
            this.nudBook2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBook2.Name = "nudBook2";
            this.nudBook2.Size = new System.Drawing.Size(50, 26);
            this.nudBook2.TabIndex = 6;
            // 
            // nudBook3
            // 
            this.nudBook3.Font = new System.Drawing.Font("Merriweather", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBook3.ForeColor = System.Drawing.Color.Sienna;
            this.nudBook3.Location = new System.Drawing.Point(123, 439);
            this.nudBook3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBook3.Name = "nudBook3";
            this.nudBook3.Size = new System.Drawing.Size(50, 26);
            this.nudBook3.TabIndex = 7;
            // 
            // nudBook4
            // 
            this.nudBook4.Font = new System.Drawing.Font("Merriweather", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBook4.ForeColor = System.Drawing.Color.Sienna;
            this.nudBook4.Location = new System.Drawing.Point(123, 470);
            this.nudBook4.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBook4.Name = "nudBook4";
            this.nudBook4.Size = new System.Drawing.Size(50, 26);
            this.nudBook4.TabIndex = 8;
            // 
            // nudBook5
            // 
            this.nudBook5.Font = new System.Drawing.Font("Merriweather", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBook5.ForeColor = System.Drawing.Color.Sienna;
            this.nudBook5.Location = new System.Drawing.Point(123, 502);
            this.nudBook5.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBook5.Name = "nudBook5";
            this.nudBook5.Size = new System.Drawing.Size(50, 26);
            this.nudBook5.TabIndex = 9;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Sienna;
            this.btnCalculate.Font = new System.Drawing.Font("Merriweather Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.ForeColor = System.Drawing.Color.Snow;
            this.btnCalculate.Location = new System.Drawing.Point(203, 508);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(185, 48);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Обчислити ціну";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Sienna;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Merriweather Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Snow;
            this.textBox2.Location = new System.Drawing.Point(12, 382);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(362, 19);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Оберіть кількість кожної книги серії:";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtOutput.Font = new System.Drawing.Font("Merriweather", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOutput.ForeColor = System.Drawing.Color.Maroon;
            this.txtOutput.Location = new System.Drawing.Point(405, 167);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(468, 412);
            this.txtOutput.TabIndex = 14;
            this.txtOutput.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox1.Font = new System.Drawing.Font("Merriweather", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(3, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBox1.Size = new System.Drawing.Size(385, 317);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.SaddleBrown;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Merriweather Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Snow;
            this.textBox3.Location = new System.Drawing.Point(3, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(385, 24);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "Обрахунок ціни покупки:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.SaddleBrown;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Merriweather Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.Snow;
            this.textBox4.Location = new System.Drawing.Point(405, 137);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(139, 24);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Результати:";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(932, 603);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblBook1);
            this.Controls.Add(this.lblBook2);
            this.Controls.Add(this.lblBook3);
            this.Controls.Add(this.lblBook4);
            this.Controls.Add(this.lblBook5);
            this.Controls.Add(this.nudBook1);
            this.Controls.Add(this.nudBook2);
            this.Controls.Add(this.nudBook3);
            this.Controls.Add(this.nudBook4);
            this.Controls.Add(this.nudBook5);
            this.Controls.Add(this.btnCalculate);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Книжковий магазин - Обрахунок ціни покупки";
            ((System.ComponentModel.ISupportInitialize)(this.nudBook1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBook5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblBook1;
        private System.Windows.Forms.Label lblBook2;
        private System.Windows.Forms.Label lblBook3;
        private System.Windows.Forms.Label lblBook4;
        private System.Windows.Forms.Label lblBook5;
        private System.Windows.Forms.NumericUpDown nudBook1;
        private System.Windows.Forms.NumericUpDown nudBook2;
        private System.Windows.Forms.NumericUpDown nudBook3;
        private System.Windows.Forms.NumericUpDown nudBook4;
        private System.Windows.Forms.NumericUpDown nudBook5;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}