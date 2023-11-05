using System;
using System.Windows.Forms;

namespace Laba2
{
    public partial class EntryWindow : Form
    {
        private bool Online { get; set; }
        private bool PossibleOnlineBuying { get; set; }
        private bool PossibleOnlineBuyingViaCourier { get; set; }
        private bool PossibleOnlineBuyingViaCourierCASH { get; set; }
        private string AddressOfLocation { get; set; }
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
            if (radioButton1.Checked) Online = true;
            else Online = false;
            this.Hide();
            MainView mainView = new MainView();
            mainView.OnlineUpdateValue(Online);
            mainView.Show();
        }

        private void EntryWindow_Activated(object sender, EventArgs e)
        {
            PossibleOnlineBuying = true;
            PossibleOnlineBuyingViaCourier = true;
            PossibleOnlineBuyingViaCourierCASH = true;
            AddressOfLocation = "St. New Yorker 41";
            label2.Text = AddressOfLocation;
            if (PossibleOnlineBuying == false || PossibleOnlineBuyingViaCourier == false || PossibleOnlineBuyingViaCourierCASH == false)
            {
                radioButton1.Enabled = false;
                radioButton1.Visible = false;
                radioButton2.Enabled = false;
                radioButton2.Visible = false;
            }
        }
    }
}
