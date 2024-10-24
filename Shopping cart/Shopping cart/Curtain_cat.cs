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
    public partial class Curtain_cat : Form
    {
        public event Action<string, decimal>oncurtainselected;

        public Curtain_cat()
        {
            InitializeComponent();

            listBox1.Items.Add(new { Name = "Single panel curtains", Price = 10.99m });
            listBox1.Items.Add(new { Name = "Pair panel curtains", Price = 19.99m });
            listBox1.Items.Add(new { Name = "Blackout curtains", Price = 15.99m });
            listBox1.Items.Add(new { Name = "Windows sill curtains", Price = 17.99m });

            listBox1.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var curtaintype = (string)selectedItem.GetType().GetProperty("Name").GetValue(selectedItem, null);
                var curtainprice = (decimal)selectedItem.GetType().GetProperty("Price").GetValue(selectedItem, null);

                // Trigger the event to pass the selected candle back to Form2
                oncurtainselected?.Invoke(curtaintype,curtainprice);

                this.Close();  // Close the candle form after selection
            }
        }
    }
}
