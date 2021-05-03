
namespace RPSLab4
{
    partial class DeleteForm
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
            this.DeleteIDUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeletingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteIDUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteIDUpDown
            // 
            this.DeleteIDUpDown.Location = new System.Drawing.Point(105, 43);
            this.DeleteIDUpDown.Name = "DeleteIDUpDown";
            this.DeleteIDUpDown.Size = new System.Drawing.Size(170, 22);
            this.DeleteIDUpDown.TabIndex = 0;
            // 
            // DeletingButton
            // 
            this.DeletingButton.Location = new System.Drawing.Point(12, 81);
            this.DeletingButton.Name = "DeletingButton";
            this.DeletingButton.Size = new System.Drawing.Size(354, 48);
            this.DeletingButton.TabIndex = 1;
            this.DeletingButton.Text = "Удалить";
            this.DeletingButton.UseVisualStyleBackColor = true;
            this.DeletingButton.Click += new System.EventHandler(this.DeletingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Идентификатор объекта";
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 148);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeletingButton);
            this.Controls.Add(this.DeleteIDUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeleteForm";
            this.Text = "Удаление";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteIDUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DeleteIDUpDown;
        private System.Windows.Forms.Button DeletingButton;
        private System.Windows.Forms.Label label1;
    }
}