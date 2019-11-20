using System;
using System.Windows.Forms;

namespace TranslatorGUI
{
    public partial class AddWordWindow : Form
    {
        public AddWordWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.comboBox1.Text)
            {
                case "Noun":
                    new NewNounWindow().ShowDialog();
                    Close();
                    break;
                case "Verb":
                    new NewVerbWindow().ShowDialog();
                    Close();
                    break;
            }
        }
    }
}