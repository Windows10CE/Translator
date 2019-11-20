using System;
using System.Windows.Forms;

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
            bruh[1, 3] = $"";
        }
    }
}