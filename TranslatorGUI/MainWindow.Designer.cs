namespace TranslatorGUI
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnglishBox = new System.Windows.Forms.TextBox();
            this.SpanishBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnglishToSpanish = new System.Windows.Forms.Button();
            this.SpanishToEnglish = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnglishBox
            // 
            this.EnglishBox.Location = new System.Drawing.Point(41, 29);
            this.EnglishBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnglishBox.Multiline = true;
            this.EnglishBox.Name = "EnglishBox";
            this.EnglishBox.Size = new System.Drawing.Size(406, 130);
            this.EnglishBox.TabIndex = 0;
            // 
            // SpanishBox
            // 
            this.SpanishBox.Location = new System.Drawing.Point(41, 197);
            this.SpanishBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SpanishBox.Multiline = true;
            this.SpanishBox.Name = "SpanishBox";
            this.SpanishBox.Size = new System.Drawing.Size(405, 136);
            this.SpanishBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "English";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Spanish";
            // 
            // EnglishToSpanish
            // 
            this.EnglishToSpanish.Enabled = false;
            this.EnglishToSpanish.Location = new System.Drawing.Point(513, 44);
            this.EnglishToSpanish.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnglishToSpanish.Name = "EnglishToSpanish";
            this.EnglishToSpanish.Size = new System.Drawing.Size(209, 85);
            this.EnglishToSpanish.TabIndex = 4;
            this.EnglishToSpanish.Text = "English to Spanish";
            this.EnglishToSpanish.UseVisualStyleBackColor = true;
            this.EnglishToSpanish.Click += new System.EventHandler(this.EnglishToSpanish_Click);
            // 
            // SpanishToEnglish
            // 
            this.SpanishToEnglish.Location = new System.Drawing.Point(513, 224);
            this.SpanishToEnglish.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SpanishToEnglish.Name = "SpanishToEnglish";
            this.SpanishToEnglish.Size = new System.Drawing.Size(208, 85);
            this.SpanishToEnglish.TabIndex = 5;
            this.SpanishToEnglish.Text = "Spanish to English";
            this.SpanishToEnglish.UseVisualStyleBackColor = true;
            this.SpanishToEnglish.Click += new System.EventHandler(this.SpanishToEnglish_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(738, 147);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 57);
            this.button3.TabIndex = 6;
            this.button3.Text = "New Word";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.NewWord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 378);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SpanishToEnglish);
            this.Controls.Add(this.EnglishToSpanish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpanishBox);
            this.Controls.Add(this.EnglishBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Translator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox SpanishBox;
        private System.Windows.Forms.TextBox EnglishBox;
        private System.Windows.Forms.Button EnglishToSpanish;
        private System.Windows.Forms.Button SpanishToEnglish;
    }
}