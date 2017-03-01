namespace Gevand_Balayan____Cryptography____HW_2
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lstOuput = new System.Windows.Forms.ListBox();
            this.lblPrimitive = new System.Windows.Forms.Label();
            this.lblIrreducible = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(82, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(82, 11);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(75, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "5";
            // 
            // lstOuput
            // 
            this.lstOuput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstOuput.FormattingEnabled = true;
            this.lstOuput.Location = new System.Drawing.Point(163, 11);
            this.lstOuput.Name = "lstOuput";
            this.lstOuput.Size = new System.Drawing.Size(429, 329);
            this.lstOuput.TabIndex = 2;
            this.lstOuput.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstOuput_DrawItem);
            // 
            // lblPrimitive
            // 
            this.lblPrimitive.AutoSize = true;
            this.lblPrimitive.Location = new System.Drawing.Point(12, 102);
            this.lblPrimitive.Name = "lblPrimitive";
            this.lblPrimitive.Size = new System.Drawing.Size(61, 13);
            this.lblPrimitive.TabIndex = 3;
            this.lblPrimitive.Text = "PRIMITIVE";
            // 
            // lblIrreducible
            // 
            this.lblIrreducible.AutoSize = true;
            this.lblIrreducible.Location = new System.Drawing.Point(12, 76);
            this.lblIrreducible.Name = "lblIrreducible";
            this.lblIrreducible.Size = new System.Drawing.Size(79, 13);
            this.lblIrreducible.TabIndex = 4;
            this.lblIrreducible.Text = "IRREDUCIBLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Degree";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIrreducible);
            this.Controls.Add(this.lblPrimitive);
            this.Controls.Add(this.lstOuput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Homework 2 -- Gevand Balayan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ListBox lstOuput;
        private System.Windows.Forms.Label lblPrimitive;
        private System.Windows.Forms.Label lblIrreducible;
        private System.Windows.Forms.Label label1;
    }
}

