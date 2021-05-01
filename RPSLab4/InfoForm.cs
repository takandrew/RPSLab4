using System;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }
        private void CloseInfoFormButton_Click(object sender, EventArgs e) //Кнопка "Вернуться"
        {
            this.Close();
        }
    }
}
