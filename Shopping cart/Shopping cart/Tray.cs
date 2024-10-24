using System;
using System.Windows.Forms;

namespace Shopping_cart
{
    public partial class Tray : Form
    {
        // Declare an event to pass the selected tray data back
        public event Action<string, decimal> OnTraySelected;

        public Tray()
        {
            InitializeComponent();

            // Add tray items with their prices to the ListBox
            listBox1.Items.Add(new { Name = "Marble Trays", Price = 20.99m });
            listBox1.Items.Add(new { Name = "Wooden Trays", Price = 23.99m });
            listBox1.Items.Add(new { Name = "Glass Trays", Price = 30.99m });
            listBox1.Items.Add(new { Name = "Plastic Trays", Price = 15.99m });

            // Display only the name in the ListBox
            listBox1.DisplayMember = "Name";
        }

        // Event handler for when an item in the ListBox is selected
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                // Get the tray name and price
                var trayType = (string)selectedItem.GetType().GetProperty("Name").GetValue(selectedItem, null);
                var trayPrice = (decimal)selectedItem.GetType().GetProperty("Price").GetValue(selectedItem, null);

                // Trigger the event to pass the selected tray back to the main form
                OnTraySelected?.Invoke(trayType, trayPrice);

                // Close the tray form after the selection
                this.Close();
            }
        }
    }
}
