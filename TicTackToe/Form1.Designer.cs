namespace TicTackToe
{
    partial class TicTakToeMainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxTicTakToe = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTicTakToe)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTicTakToe
            // 
            this.pictureBoxTicTakToe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTicTakToe.Location = new System.Drawing.Point(21, 9);
            this.pictureBoxTicTakToe.Name = "pictureBoxTicTakToe";
            this.pictureBoxTicTakToe.Size = new System.Drawing.Size(282, 281);
            this.pictureBoxTicTakToe.TabIndex = 0;
            this.pictureBoxTicTakToe.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.Location = new System.Drawing.Point(21, 296);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(282, 53);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // TicTakToeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxTicTakToe);
            this.Name = "TicTakToeMainForm";
            this.Text = "TicTakToe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTicTakToe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTicTakToe;
        private System.Windows.Forms.Button buttonStart;
    }
}

