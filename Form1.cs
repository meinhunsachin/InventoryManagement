using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager
{
    public partial class InventoryMangementStudio : Form
    {
        DataTable inventory = new DataTable();
        public InventoryMangementStudio()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text = "";
            descriptionTextBox.Text = "Description";
            quantityTextBox.Text = "";
            categoryBox.SelectedIndex = -1;
                                                                                                                               
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //save all the values from our fields into variables
            String sku=skuTextBox.Text; 
            String name=nameTextBox.Text;
            String price=priceTextBox.Text; 
            String quantity =quantityTextBox.Text;
            String description =descriptionTextBox.Text;    
            String category =(string)categoryBox.SelectedItem;

            // add these values to the datatable
            inventory.Rows.Add(sku,name,category,price,description,quantity); 
            // clear fields after save 
            newButton_Click(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            { 
                Console.WriteLine("Error " +err);
            }

        }

        private void InventoryMangementStudio_Load(object sender, EventArgs e)
        {
            try
            {
                skuTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                descriptionTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();
                //skuTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();

                String itemToLookFor= inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryBox.SelectedIndex=categoryBox.Items.IndexOf(itemToLookFor);
            }
            catch(Exception err) 
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void inventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            inventory.Columns.Add("SkU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventory;

        }
    }
}
