using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Shopping_cart
{
    public partial class Form2 : Form
    {

        private int totalCandles = 0;
        private int totalFlowers = 0;
        private int totalTrays = 0;
        private int totalacc = 0;
        private int totalcur = 0;
        private int totalfur = 0;

        private decimal candleBill = 0;
        private decimal flowerBill = 0;
        private decimal trayBill = 0;
        private decimal accBill = 0;
        private decimal curBill = 0;
        private decimal furBill = 0;


        public Form2()
        {
            InitializeComponent();
            AddHoverEffects();
        }

        private void AddHoverEffects()
        {
            // Add hover effects to the buttons
            AddButtonHoverEffect(candle_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(Flower_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(tray_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(acc_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(bill_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(rem_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(cur_btn, Color.LightBlue, Color.LightSkyBlue);
            AddButtonHoverEffect(Furniture_btn, Color.LightBlue, Color.LightSkyBlue);
        }

        // Method to add hover effect for a button
        private void AddButtonHoverEffect(Button button, Color hoverColor, Color defaultColor)
        {
            // Event for mouse entering the button (hover effect)
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = hoverColor;  // Change color on hover
            };

            // Event for mouse leaving the button (reverting effect)
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = defaultColor;  // Revert to default color
            };
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void candle_btn_Click(object sender, EventArgs e)
        {
            Candle_categoeries c1 = new Candle_categoeries();
            c1.OnCandleSelected += CandleCategoriesForm_OnCandleSelected;  // Event handling
            c1.Show();
        }

        // Update total candles and bill when a candle is selected
        private void CandleCategoriesForm_OnCandleSelected(string candleType, decimal candlePrice)
        {
            totalCandles++;  // Increment candle count
            candleBill += candlePrice;  // Add the price of the selected candle
            MessageBox.Show($"You selected: {candleType}. Total candles: {totalCandles}, Total Candle Bill: ${candleBill}");

            l1.Items.Add(candleType + "-" + candlePrice);
        }

        private void Flower_btn_Click(object sender, EventArgs e)
        {
            Flower_cat f = new Flower_cat();
            f.OnFlowerSelected += FlowerCategoriesForm_OnFlowerSelected;
            f.Show();
        }

        private void FlowerCategoriesForm_OnFlowerSelected(string flowerType, decimal flowerPrice)
        {
            totalFlowers++;  // Increment flower count
            flowerBill += flowerPrice;  // Add the price of the selected flower
            MessageBox.Show($"You selected: {flowerType}. Total flowers: {totalFlowers}, Total Flower Bill: ${flowerBill}");

            l1.Items.Add(flowerType + "-" + flowerPrice);

        }

        private void tray_btn_Click(object sender, EventArgs e)
        {
            Tray t = new Tray();
            t.OnTraySelected += TrayForm_OnTraySelected;  // Event handling for tray selection
            t.Show();
        }

        // Update total trays and bill when a tray is selected
        private void TrayForm_OnTraySelected(string trayType, decimal trayPrice)
        {
            totalTrays++;  // Increment tray count
            trayBill += trayPrice;  // Add the price of the selected tray
            MessageBox.Show($"You selected: {trayType}. Total trays: {totalTrays}, Total Tray Bill: ${trayBill}");

            l1.Items.Add(trayType + "-" + trayPrice);
        }


        private void acc_btn_Click(object sender, EventArgs e)
        {
            acc_cat a = new acc_cat();
            a.Onaccselected += accform_onaccselected;
            a.Show();
        }

        private void accform_onaccselected(string acctype, decimal accprice)
        {
            totalacc++;
            accBill += accprice;
            MessageBox.Show($"You selected: {acctype}. Total accessories: {totalacc}, Total Accessories Bill: ${accBill}");

            l1.Items.Add(acctype + "-" + accprice);
        }

        private void cur_btn_Click(object sender, EventArgs e)
        {
            Curtain_cat c = new Curtain_cat();
            c.oncurtainselected += curtainform_oncurselected;
            c.Show();
        }


        private void curtainform_oncurselected(string curtype, decimal currprice)
        {
            totalcur++;
            curBill += currprice;
            MessageBox.Show($"You selected: {curtype}. Total Curtains: {totalcur}, Total Curtains Bill: ${curBill}");

            l1.Items.Add(curtype + "-" + currprice);
        }

        private void Furniture_btn_Click(object sender, EventArgs e)
        {
            Furn_cat f = new Furn_cat();
            f.onfurnselected+= furnform_onfurnselected;
            f.Show();
        }

        private void furnform_onfurnselected(string furtype, decimal furprice)
        {
            totalfur++;
            furBill += furprice;
            MessageBox.Show($"You selected: {furtype}. Total Curtains: {totalfur}, Total Curtains Bill: ${furBill}");

            l1.Items.Add(furtype + "-" + furprice);
        }



        private void rem_btn_Click(object sender, EventArgs e)
        {
            if (l1.SelectedItem != null)  // Check if an item is selected
            {
                var selectedItem = l1.SelectedItem.ToString();

                // Remove the selected item from listBox1
                l1.Items.Remove(l1.SelectedItem);

                // Now, subtract from the total bill and decrement the count accordingly
                if (selectedItem.Contains("Wax Candles"))
                {
                    // Parse price from the string and update totals
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalCandles--;
                    candleBill -= price;
                }
                else if (selectedItem.Contains("Luxury Candles"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalCandles--;
                    candleBill -= price;
                }
                else if (selectedItem.Contains("Seasonal Candles"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalCandles--;
                    candleBill -= price;
                }
                else if (selectedItem.Contains("Beewax candles"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalCandles--;
                    candleBill -= price;
                }
                else if (selectedItem.Contains("Roses"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalFlowers--;
                    flowerBill -= price;
                }
                else if (selectedItem.Contains("Sunflowers"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalFlowers--;
                    flowerBill -= price;
                }
                else if (selectedItem.Contains("Jasmines"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalFlowers--;
                    flowerBill -= price;
                }
                else if (selectedItem.Contains("Lillies"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalFlowers--;
                    flowerBill -= price;
                }
                else if (selectedItem.Contains("Marble Trays"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalTrays--;
                    trayBill -= price;
                }
                else if (selectedItem.Contains("Wooden Trays"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalTrays--;
                    trayBill -= price;
                }
                else if (selectedItem.Contains("Glass Trays"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalTrays--;
                    trayBill -= price;
                }
                else if (selectedItem.Contains("Plastic Trays"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalTrays--;
                    trayBill -= price;
                }
                else if (selectedItem.Contains("Candle lighters"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalacc--;
                    accBill -= price;
                }
                else if (selectedItem.Contains("Candle covers"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalacc--;
                    accBill -= price;
                }
                else if (selectedItem.Contains("Candle labels"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalacc--;
                    accBill -= price;
                }
                else if (selectedItem.Contains("Candle trimmers"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalacc--;
                    accBill -= price;
                }
                else if (selectedItem.Contains("Single panel curtains"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Pair panel curtains"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Blackout curtains"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Windows sill curtains"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if(selectedItem.Contains("Bed"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Sofa"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Armchair"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Bed lamps"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                else if (selectedItem.Contains("Table"))
                {
                    decimal price = ParsePriceFromItem(selectedItem);
                    totalcur--;
                    curBill -= price;
                }
                MessageBox.Show("Item removed successfully.");
                DisplayTotalBill();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }


        private decimal ParsePriceFromItem(string selectedItem)
        {
            // Extract price from the format "ItemName - $Price"
            string[] parts = selectedItem.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string pricePart = parts[1].Trim().Replace("$", "");
                return decimal.Parse(pricePart);
            }
            return 0;
        }


        private void bill_btn_Click(object sender, EventArgs e)
        {
            DisplayTotalBill();
        }


        private void DisplayTotalBill()
        {
            // Calculate grand total for all items
            decimal grandTotal = candleBill + flowerBill + trayBill + accBill + curBill + furBill;

            // Prepare the bill details string with precise spacing and alignment
            string billDetails = "";

            // Title
            billDetails += "SHOPPING CART BILL\n";
            billDetails += "--------------------------------------------------------------\n";

            // Column headers with wider spacing for better alignment
            billDetails += String.Format("{0,-20} {1,-10} {2,-15} {3,-15}\n", "Item", "Quantity", "Unit Price", "Total");
            billDetails += "--------------------------------------------------------------\n";

            // Display each item category if it has a non-zero count
            if (totalCandles > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Candles", totalCandles, candleBill / totalCandles, candleBill);
            }
            if (totalFlowers > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Flowers", totalFlowers, flowerBill / totalFlowers, flowerBill);
            }
            if (totalTrays > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Trays", totalTrays, trayBill / totalTrays, trayBill);
            }
            if (totalacc > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Accessories", totalacc, accBill / totalacc, accBill);
            }
            if (totalcur > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Curtains", totalcur, curBill / totalcur, curBill);
            }
            if (totalfur > 0)
            {
                billDetails += String.Format("{0,-20} {1,-10} {2,-15:C} {3,-15:C}\n", "Furniture", totalfur, furBill / totalfur, furBill);
            }

            // Separator line before grand total
            billDetails += "--------------------------------------------------------------\n";

            // Display Grand Total
            billDetails += String.Format("{0,-40} {1,-15:C}\n", "Grand Total", grandTotal);

            // Show the bill in a new Bill form
            Bill_form b = new Bill_form(billDetails);
            b.ShowDialog();
        }



    }
}
