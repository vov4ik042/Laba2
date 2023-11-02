using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class MainView : Form
    {
        private BindingSource _bs;

        //private string AdressOfLocation = "St. New Yorker 41";
        private DateTime date;
        public bool PossiblePaymentCard { get; set; }
        public bool PossibleOnlineBuying { get; set; }
        public bool PossibleOnlineBuyingAndCourier { get; set; }
        public bool PossibleOnlineBuyingAndCourierCASH { get; set; }
        public bool AdressOfLocation { get; set; }

        public MainView()
        {
            InitializeComponent();
            Products products = new Products(1);
            _bs = new BindingSource();
            _bs.DataSource = products.ProductsListBase;
            _bs.ResetBindings(true);
            Font myFont = new Font("Arial", 12, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = myFont;
            dataGridView1.DataSource = _bs;
        }

        public MainView(int example)
        {
            if (Products.ProductsListClient.Count > 0)
            {
                Products products = new Products();
                InitializeComponent();
                dataGridView1.Enabled = true;
                dataGridView1.Visible = true;
                _bs = new BindingSource();
                _bs.DataSource = products.ProductsListBase;
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

        /*public void UpdateGridMain()
        {
            InitializeComponent();
            if (Products.ProductsListClient.Count > 0)
            {
                _bs = new BindingSource();
                _bs.DataSource = Products.ProductsListClient;
                _bs.ResetBindings(true);
                Font myFont = new Font("Arial", 13, FontStyle.Regular);
                dataGridView1.DefaultCellStyle.Font = myFont;
                dataGridView1.DataSource = _bs;
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            AddWindow AddProducts = new AddWindow();
            AddProducts.Show();
        }
    }
}
