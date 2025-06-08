namespace Project_3D_model
{
    partial class Form3DModel
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.buttonResetView = new System.Windows.Forms.Button();
            this.buttonCompute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(-2, -1);
            this.canvas.Margin = new System.Windows.Forms.Padding(4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1499, 707);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // buttonResetView
            // 
            this.buttonResetView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetView.Location = new System.Drawing.Point(13, 714);
            this.buttonResetView.Margin = new System.Windows.Forms.Padding(4);
            this.buttonResetView.Name = "buttonResetView";
            this.buttonResetView.Size = new System.Drawing.Size(720, 35);
            this.buttonResetView.TabIndex = 1;
            this.buttonResetView.Text = "Reset View";
            this.buttonResetView.UseVisualStyleBackColor = true;
            this.buttonResetView.Click += new System.EventHandler(this.buttonResetView_Click);
            // 
            // buttonCompute
            // 
            this.buttonCompute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompute.Location = new System.Drawing.Point(764, 714);
            this.buttonCompute.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCompute.Name = "buttonCompute";
            this.buttonCompute.Size = new System.Drawing.Size(720, 35);
            this.buttonCompute.TabIndex = 2;
            this.buttonCompute.Text = "Compute";
            this.buttonCompute.UseVisualStyleBackColor = true;
            this.buttonCompute.Click += new System.EventHandler(this.buttonCompute_Click);
            // 
            // Form3DModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1497, 762);
            this.Controls.Add(this.buttonCompute);
            this.Controls.Add(this.buttonResetView);
            this.Controls.Add(this.canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(78)))), ((int)(((byte)(149)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3DModel";
            this.Text = "3D calculation grid";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button buttonResetView;
        private System.Windows.Forms.Button buttonCompute;
    }
}

