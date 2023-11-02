using System;
using System.Windows.Forms;

namespace Laba2
{
    public partial class AmountWindow : Form
    {
        private DataGridViewRow selectedRow { get; set; }
        private string NameOfProduct { get; set; }
        private int ArticleOfProduct { get; set; }
        private double PriceOfProduct { get; set; }
        private string TypeOfProduct { get; set; }
        private double AmountOfThings { get; set; }
        private double _operation { get; set; }
        private bool CountForNewAmount { get; set; }
        public AmountWindow(DataGridViewRow selectedRow)
        {
            NameOfProduct = selectedRow.Cells["NameOfProduct"].Value.ToString();
            ArticleOfProduct = (int)selectedRow.Cells["ArticleOfProduct"].Value;
            PriceOfProduct = (double)selectedRow.Cells["PriceOfProduct"].Value;
            TypeOfProduct = selectedRow.Cells["TypeOfProduct"].Value.ToString();
            this.selectedRow = selectedRow;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _operation = double.Parse(comboBox1.Text);
            _operation++;
            comboBox1.Text = _operation.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _operation = double.Parse(comboBox1.Text);
            if (_operation > 0)
            {
                _operation--;
                comboBox1.Text = _operation.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AmountOfThings = double.Parse(comboBox1.Text);
            CountForNewAmount = false;
            if (AmountOfThings != default)
            {
                for (int i = 0; i < Products.ProductsListClient.Count; i++)
                {
                    if (NameOfProduct == Products.ProductsListClient[i].NameOfProduct)
                    {
                        Products.ProductsListClient[i].NumberOfProducts += AmountOfThings;
                        CountForNewAmount = true;
                        break;
                    }
                }

                if (CountForNewAmount != true)
                    Products.ProductsListClient.Add(new Products(NameOfProduct, ArticleOfProduct, PriceOfProduct, TypeOfProduct, AmountOfThings));
            }
            this.Close();
        }
    }
}
