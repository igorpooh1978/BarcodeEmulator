using System.Windows.Forms;


namespace BarcodeEmulator
{
    partial class BarcodeEmulatorForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.delayNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 61);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(247, 20);
            this.textBox2.TabIndex = 2;
            // 
            // delayNumeric
            // 
            this.delayNumeric.Location = new System.Drawing.Point(263, 78);
            this.delayNumeric.Name = "delayNumeric";
            this.delayNumeric.Size = new System.Drawing.Size(68, 20);
            this.delayNumeric.TabIndex = 3;
            this.delayNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // BarcodeEmulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 104);
            this.Controls.Add(this.delayNumeric);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeEmulatorForm";
            this.Text = "BarcodeEmulator";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private NumericUpDown delayNumeric;
    }
}