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
    public partial class Candle_categoeries : Form
    {
         public event Action<string, decimal> OnCandleSelected;
        public Candle_categoeries()
        {
            InitializeComponent();

            // Add items with prices
            listBox1.Items.Add(new { Name = "Wax Candles", Price = 10.99m });
            listBox1.Items.Add(new { Name = "Luxury Candles", Price = 19.99m });
            listBox1.Items.Add(new { Name = "Seasonal Candles", Price = 15.99m });
            listBox1.Items.Add(new { Name = "Beewax candles", Price = 17.99m });

            listBox1.DisplayMember = "Name";  // Display only the name in the ListBox
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var candleType = (string)selectedItem.GetType().GetProperty("Name").GetValue(selectedItem, null);
                var candlePrice = (decimal)selectedItem.GetType().GetProperty("Price").GetValue(selectedItem, null);

                // Trigger the event to pass the selected candle back to Form2
                OnCandleSelected?.Invoke(candleType, candlePrice);

                this.Close();  // Close the candle form after selection
            }
        }
    }
}
