using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba2
{
    public partial class MainView : Form
    {
        private BindingSource _bs;
        public static bool MainUpdateView { get; set; }
        private double PriceForThing { get; set; }
        private int AmountOfThings { get; set; }
        private double SumPay { get; set; }
        private int selectedRowIndex { get; set; }

        //private string AdressOfLocation = "St. New Yorker 41";
        private DateTime date;
        public bool PossiblePaymentCard { get; set; }
        public bool PossibleOnlineBuying { get; set; }
        public bool PossibleOnlineBuyingAndCourier { get; set; }
        public bool PossibleOnlineBuyingAndCourierCASH { get; set; }
        public bool AdressOfLocation { get; set; }

        private bool[] mas = new bool[1];

        public MainView(int yes)
        {

        }

        public MainView()
        {
            InitializeComponent();
            if (Products.ProductsListClient.Count > 0)
            {
                Products products = new Products();
                _bs = new BindingSource();
                _bs.DataSource = Products.ProductsListClient;
                _bs.ResetBindings(true);
                Font myFont = new Font("Arial", 12, FontStyle.Regular);
                dataGridView1.DefaultCellStyle.Font = myFont;
                dataGridView1.DataSource = _bs;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            date = DateTime.Now;
            label1.Text = date.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddWindow AddProducts = new AddWindow();
            AddProducts.Show();
        }

        private void MainView_Activated(object sender, EventArgs e)
        {
            for (int i = 0; i < Products.ProductsListClient.Count; i++)
            {
                PriceForThing = Products.ProductsListClient[i].PriceOfProduct;
                AmountOfThings = Products.ProductsListClient[i].NumberOfProducts;
                SumPay += PriceForThing * AmountOfThings;
            }
            label3.Text = $"{SumPay} UAH";
            if (MainUpdateView == true)
            {
                mas[0] = MainUpdateView;
                EntryWindow entryWindow = new EntryWindow(1);
                entryWindow.UpdateBasket();
                this.Close();
            }
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mas[0] == false)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                SumPay -= Products.ProductsListClient[selectedRowIndex].NumberOfProducts * Products.ProductsListClient[selectedRowIndex].PriceOfProduct;
                Products.ProductsListClient.RemoveAt(selectedRowIndex);
                MainUpdateView = true;
                MainView_Activated(sender, e);
            }
            else
            {
                MessageBox.Show("Click on an item's row to remove it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRowIndex = dataGridView1.SelectedRows[0].Index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete all?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                SumPay = 0;
                Products.ProductsListClient.Clear();
                MainUpdateView = true;
                MainView_Activated(sender, e);
            }
        }
    }
}
