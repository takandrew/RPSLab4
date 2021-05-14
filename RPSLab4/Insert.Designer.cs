
namespace RPSLab4
{
    partial class InsertForm
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
            this.AddNameTextBox = new System.Windows.Forms.TextBox();
            this.AddOwnerTextBox = new System.Windows.Forms.TextBox();
            this.AddOrbitTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNameTextBox
            // 
            this.AddNameTextBox.Location = new System.Drawing.Point(49, 57);
            this.AddNameTextBox.Name = "AddNameTextBox";
            this.AddNameTextBox.Size = new System.Drawing.Size(229, 22);
            this.AddNameTextBox.TabIndex = 2;
            // 
            // AddOwnerTextBox
            // 
            this.AddOwnerTextBox.Location = new System.Drawing.Point(49, 111);
            this.AddOwnerTextBox.Name = "AddOwnerTextBox";
            this.AddOwnerTextBox.Size = new System.Drawing.Size(229, 22);
            this.AddOwnerTextBox.TabIndex = 3;
            // 
            // AddOrbitTextBox
            // 
            this.AddOrbitTextBox.Location = new System.Drawing.Point(49, 166);
            this.AddOrbitTextBox.Name = "AddOrbitTextBox";
            this.AddOrbitTextBox.Size = new System.Drawing.Size(229, 22);
            this.AddOrbitTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название объекта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Владелец";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Орбита";
            // 
            // AddingButton
            // 
            this.AddingButton.Location = new System.Drawing.Point(29, 217);
            this.AddingButton.Name = "AddingButton";
            this.AddingButton.Size = new System.Drawing.Size(283, 43);
            this.AddingButton.TabIndex = 8;
            this.AddingButton.Text = "Добавить";
            this.AddingButton.UseVisualStyleBackColor = true;
            this.AddingButton.Click += new System.EventHandler(this.AddingButton_Click);
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 269);
            this.Controls.Add(this.AddingButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddOrbitTextBox);
            this.Controls.Add(this.AddOwnerTextBox);
            this.Controls.Add(this.AddNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InsertForm";
            this.Text = "Добавление";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InsertForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AddNameTextBox;
        private System.Windows.Forms.TextBox AddOwnerTextBox;
        private System.Windows.Forms.TextBox AddOrbitTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddingButton;
    }
}