
namespace RPSLab4
{
    partial class UpdateForm
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
            this.UpdatingButton = new System.Windows.Forms.Button();
            this.UpdateNameTextBox = new System.Windows.Forms.TextBox();
            this.UpdateOwnerTextBox = new System.Windows.Forms.TextBox();
            this.UpdateOrbitTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateIDUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIDUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdatingButton
            // 
            this.UpdatingButton.Location = new System.Drawing.Point(12, 275);
            this.UpdatingButton.Name = "UpdatingButton";
            this.UpdatingButton.Size = new System.Drawing.Size(358, 48);
            this.UpdatingButton.TabIndex = 0;
            this.UpdatingButton.Text = "Изменить";
            this.UpdatingButton.UseVisualStyleBackColor = true;
            this.UpdatingButton.Click += new System.EventHandler(this.UpdatingButton_Click);
            // 
            // UpdateNameTextBox
            // 
            this.UpdateNameTextBox.Location = new System.Drawing.Point(24, 111);
            this.UpdateNameTextBox.Name = "UpdateNameTextBox";
            this.UpdateNameTextBox.Size = new System.Drawing.Size(325, 22);
            this.UpdateNameTextBox.TabIndex = 1;
            // 
            // UpdateOwnerTextBox
            // 
            this.UpdateOwnerTextBox.Location = new System.Drawing.Point(24, 169);
            this.UpdateOwnerTextBox.Name = "UpdateOwnerTextBox";
            this.UpdateOwnerTextBox.Size = new System.Drawing.Size(325, 22);
            this.UpdateOwnerTextBox.TabIndex = 2;
            // 
            // UpdateOrbitTextBox
            // 
            this.UpdateOrbitTextBox.Location = new System.Drawing.Point(24, 228);
            this.UpdateOrbitTextBox.Name = "UpdateOrbitTextBox";
            this.UpdateOrbitTextBox.Size = new System.Drawing.Size(325, 22);
            this.UpdateOrbitTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя объекта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Владелец объекта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Орбита объекта";
            // 
            // UpdateIDUpDown
            // 
            this.UpdateIDUpDown.Location = new System.Drawing.Point(135, 46);
            this.UpdateIDUpDown.Name = "UpdateIDUpDown";
            this.UpdateIDUpDown.Size = new System.Drawing.Size(114, 22);
            this.UpdateIDUpDown.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Идентификатор объекта";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 337);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpdateIDUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateOrbitTextBox);
            this.Controls.Add(this.UpdateOwnerTextBox);
            this.Controls.Add(this.UpdateNameTextBox);
            this.Controls.Add(this.UpdatingButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateForm";
            this.Text = "Изменение";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIDUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdatingButton;
        private System.Windows.Forms.TextBox UpdateNameTextBox;
        private System.Windows.Forms.TextBox UpdateOwnerTextBox;
        private System.Windows.Forms.TextBox UpdateOrbitTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UpdateIDUpDown;
        private System.Windows.Forms.Label label4;
    }
}