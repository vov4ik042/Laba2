using System;
using System.Windows.Forms;

namespace Laba2
{
    public partial class EntryWindow : Form
    {
        public EntryWindow()
        {
            InitializeComponent();
        }
        public EntryWindow(int yes) { }
        public void UpdateBasket()
        {
            MainView mainView = new MainView();
            if (MainView.MainUpdateView == true)
            {
                MainView.MainUpdateView = false;
                mainView.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainView mainView = new MainView();
            mainView.Show();
        }
    }
}
