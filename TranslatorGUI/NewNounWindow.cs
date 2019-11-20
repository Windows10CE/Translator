using System;
using System.Windows.Forms;
using Translator.Words;

namespace TranslatorGUI
{
    public partial class NewNounWindow : Form
    {
        public NewNounWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var bruh = new string[1,1];
            bruh[0, 0] = EngSing.Text;
            bruh[0, 1] = EngPlur.Text;
            bruh[1, 0] = SpanSing.Text;
            bruh[1, 1] = SpanPlur.Text;
            Translator.Translator.AddWord(new Noun(bruh));
        }
    }
}