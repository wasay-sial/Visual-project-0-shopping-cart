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
    public partial class Flower_cat : Form
    {
        public event Action<string, decimal> OnFlowerSelected;
        public Flower_cat()
        {
            InitializeComponent();

            listBox1.Items.Add(new { Name = "Roses", Price = 2.99m });
            listBox1.Items.Add(new { Name = "Sunflowers", Price = 3.99m });
            listBox1.Items.Add(new { Name = "Jasmines", Price = 1.99m });
            listBox1.Items.Add(new { Name = "Lillies", Price = 4.99m });

            listBox1.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var flowerType = (string)selectedItem.GetType().GetProperty("Name").GetValue(selectedItem, null);
                var flowerPrice = (decimal)selectedItem.GetType().GetProperty("Price").GetValue(selectedItem, null);

                // Trigger the event to pass the selected flower back to Form2
                OnFlowerSelected?.Invoke(flowerType, flowerPrice);

                this.Close();  // Close the flower form after selection
            }
        }
    }
}
