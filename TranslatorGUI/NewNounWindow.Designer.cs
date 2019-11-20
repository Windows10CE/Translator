using System.ComponentModel;

namespace TranslatorGUI
{
    partial class NewNounWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.EngSing = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EngPlur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SpanSing = new System.Windows.Forms.TextBox();
            this.SpanPlur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EngSing
            // 
            this.EngSing.Location = new System.Drawing.Point(12, 27);
            this.EngSing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EngSing.Name = "EngSing";
            this.EngSing.Size = new System.Drawing.Size(171, 23);
            this.EngSing.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "English Singular";
            // 
            // EngPlur
            // 
            this.EngPlur.Location = new System.Drawing.Point(202, 27);
            this.EngPlur.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EngPlur.Name = "EngPlur";
            this.EngPlur.Size = new System.Drawing.Size(171, 23);
            this.EngPlur.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "English Plural";
            // 
            // SpanSing
            // 
            this.SpanSing.Location = new System.Drawing.Point(12, 69);
            this.SpanSing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SpanSing.Name = "SpanSing";
            this.SpanSing.Size = new System.Drawing.Size(171, 23);
            this.SpanSing.TabIndex = 4;
            // 
            // SpanPlur
            // 
            this.SpanPlur.Location = new System.Drawing.Point(202, 69);
            this.SpanPlur.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SpanPlur.Name = "SpanPlur";
            this.SpanPlur.Size = new System.Drawing.Size(170, 23);
            this.SpanPlur.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Spanish Singular";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(202, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Spanish Plural";
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Add.Location = new System.Drawing.Point(12, 100);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(360, 43);
            this.Add.TabIndex = 8;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // NewNounWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 148);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpanPlur);
            this.Controls.Add(this.SpanSing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EngPlur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EngSing);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NewNounWindow";
            this.Text = "New Nown";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EngSing;
        private System.Windows.Forms.TextBox SpanSing;
        private System.Windows.Forms.TextBox SpanPlur;
        private System.Windows.Forms.TextBox EngPlur;
    }
}