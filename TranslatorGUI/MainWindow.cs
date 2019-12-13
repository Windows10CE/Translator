using System;
using System.Windows.Forms;

namespace TranslatorGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SpanishToEnglish_Click(object sender, EventArgs e)
        {
            EnglishBox.Text = new Translator.Translator().SpanishToEnglish(SpanishBox.Text);
        }

        private void EnglishToSpanish_Click(object sender, EventArgs e)
        {
            SpanishBox.Text = new Translator.Translator().EnglishToSpanish(EnglishBox.Text);
            Application.Exit();
        }

        private void NewWord_Click(object sender, EventArgs e)
        {
            new AddWordWindow().ShowDialog();
        }
    }
}