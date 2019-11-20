using System;
using System.Windows.Forms;
using Translator.Words;

namespace TranslatorGUI
{
    public partial class NewVerbWindow : Form
    {
        public NewVerbWindow()
        {
            InitializeComponent();
        }

        private void OnPressOfButtonClikcAddAddBruhButtonWordButtonClick3(object sender, EventArgs e)
        {
            var bruh = new string[1,9];
            bruh[0, 0] = EngPres.Text;
            bruh[0, 1] = EngCom.Text;
            bruh[0, 2] = EngPresPar.Text;
            bruh[0, 3] = EngPast.Text;
            bruh[1, 0] = SpanInfinBox.Text;
            bruh[1, 1] = $"{SpanIBox.Text}|{SpanIEndBox.Text}";
            bruh[1, 2] = $"{SpanYouBox.Text}|{SpanYouEndBox.Text}";
            bruh[1, 3] = $"{SpanHeBox.Text}|{SpanHeEndBox.Text}";
            bruh[1, 4] = $"{SpanWeBox.Text}|{SpanWeEndBox.Text}";
            bruh[1, 5] = $"{SpanTheyBox.Text}|{SpanTheyEndBox.Text}";
            bruh[1, 6] = $"{SpanYouComBox.Text}|{SpanYouComEndBox.Text}";
            bruh[1, 7] = $"{SpanHeComBox.Text}|{SpanHeComEndBox.Text}";
            bruh[1, 8] = $"{SpanWeComBox.Text}|{SpanWeComEndBox}";
            bruh[1, 9] = $"{SpanTheyComBox.Text}|{SpanTheyComEndBox.Text}";
            Translator.Translator.AddWord(new Verb(bruh));
        }
    }
}