namespace Task6_CG
{
    partial class DrawForm
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
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.WorldPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 50;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // WorldPanel
            // 
            this.WorldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldPanel.Location = new System.Drawing.Point(0, 0);
            this.WorldPanel.Name = "WorldPanel";
            this.WorldPanel.Size = new System.Drawing.Size(1335, 611);
            this.WorldPanel.TabIndex = 0;
            this.WorldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldPanel_Paint);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 611);
            this.Controls.Add(this.WorldPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DrawForm";
            this.Text = "Rocket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.Panel WorldPanel;
    }
}

