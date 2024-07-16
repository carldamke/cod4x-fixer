using System;
using System.Windows.Forms;

namespace cod4x_fixer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxCodKey;
        private Label labelCodKey;
        private ComboBox comboBoxValues;
        private Label labelAvKey;
        private Button buttonUpdate;

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
            this.textBoxCodKey = new System.Windows.Forms.TextBox();
            this.labelCodKey = new System.Windows.Forms.Label();
            this.comboBoxValues = new System.Windows.Forms.ComboBox();
            this.labelAvKey = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCodKey
            // 
            this.textBoxCodKey.Location = new System.Drawing.Point(12, 29);
            this.textBoxCodKey.Name = "textBoxCodKey";
            this.textBoxCodKey.ReadOnly = true;
            this.textBoxCodKey.Size = new System.Drawing.Size(400, 20);
            this.textBoxCodKey.TabIndex = 0;
            // 
            // labelCodKey
            // 
            this.labelCodKey.AutoSize = true;
            this.labelCodKey.Location = new System.Drawing.Point(12, 9);
            this.labelCodKey.Name = "labelCodKey";
            this.labelCodKey.Size = new System.Drawing.Size(48, 13);
            this.labelCodKey.TabIndex = 1;
            this.labelCodKey.Text = "Aktueller Key";
            // 
            // comboBoxValues
            // 
            this.comboBoxValues.FormattingEnabled = true;
            this.comboBoxValues.Location = new System.Drawing.Point(12, 84);
            this.comboBoxValues.Name = "comboBoxValues";
            this.comboBoxValues.Size = new System.Drawing.Size(400, 21);
            this.comboBoxValues.TabIndex = 3;
            // 
            // labelAvKey
            // 
            this.labelAvKey.AutoSize = true;
            this.labelAvKey.Location = new System.Drawing.Point(12, 68);
            this.labelAvKey.Name = "labelAvKey";
            this.labelAvKey.Size = new System.Drawing.Size(146, 13);
            this.labelAvKey.TabIndex = 2;
            this.labelAvKey.Text = "Aus Liste der verfügbaren Keys wählen:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(183, 111);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(424, 146);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxValues);
            this.Controls.Add(this.labelAvKey);
            this.Controls.Add(this.labelCodKey);
            this.Controls.Add(this.textBoxCodKey);
            this.Name = "Form1";
            this.Text = "CoD4 Key Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
