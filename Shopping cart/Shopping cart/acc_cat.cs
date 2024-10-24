using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_cart
{
    public partial class acc_cat : Form
    {

        public event Action<string, decimal>? Onaccselected;
        public acc_cat()
        {
            InitializeComponent();

            listBox1.Items.Add(new { name = "Candle lighters", price = 2.00m });
            listBox1.Items.Add(new { name = "Candle covers", price = 2.50m });
            listBox1.Items.Add(new { name = "Candle labels", price = 2.70m });
            listBox1.Items.Add(new { name = "Candle trimmers", price = 3.50m });

            listBox1.DisplayMember = "name";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;  // Get selected item

            if (selectedItem != null)
            {
                // Get the 'Name' and 'Price' properties of the selected item
                var accessoryType = (string)selectedItem.GetType().GetProperty("name")?.GetValue(selectedItem, null);
                var accessoryPrice = (decimal)selectedItem.GetType().GetProperty("price")?.GetValue(selectedItem, null);

                // Trigger the event to pass the selected accessory back to Form2
                Onaccselected?.Invoke(accessoryType, accessoryPrice);

                this.Close();
            }
        }
    }
}
