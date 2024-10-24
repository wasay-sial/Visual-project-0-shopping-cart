using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_cart
{
    public partial class Furn_cat : Form
    {
        public event Action<string, decimal>?onfurnselected;
        public Furn_cat()
        {
            InitializeComponent();
            listBox1.Items.Add(new { name = "Bed", price = 500.99m });
            listBox1.Items.Add(new { name = "Sofa", price = 350.99m });
            listBox1.Items.Add(new { name = "Armchair", price = 150.00m });
            listBox1.Items.Add(new { name = "Bed lamps", price = 110.99m });
            listBox1.Items.Add(new { name = "Table", price = 69.99m });

            listBox1.DisplayMember = "name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var furntype = (string)selectedItem.GetType().GetProperty("name").GetValue(selectedItem, null);
                var furnprice = (decimal)selectedItem.GetType().GetProperty("price").GetValue(selectedItem, null);

                // Trigger the event to pass the selected candle back to Form2
                onfurnselected?.Invoke(furntype, furnprice);

                this.Close();  // Close the candle form after selection
            }


        }
    }
}
