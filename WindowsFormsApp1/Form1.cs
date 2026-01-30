using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Configuration; // Ensure this is included
using System.Collections.Specialized; // Add this for NameValueCollection support

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        HttpClient client = new HttpClient();
        BindingList<Adat> items = new BindingList<Adat>();

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("szerintem szép :p \nAPI URL: " + ApiUrl); // Display the API URL for verification
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           

  

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //display all names in listbox from Adat class


        




        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Create button POST request to ApiUrl
            var values = new Dictionary<string, string>
            {
                { "Name", "New Name" },
                { "cvv", "123" },
                { "Alive", "true" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(ApiUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            MessageBox.Show("Response: " + responseString);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create button UPDATE request to ApiUrl
            if (listBox1.SelectedItem is Adat selectedItem)
            {
                var values = new Dictionary<string, string>
                {
                    { "id", selectedItem.Id.ToString() },
                    { "Name", "Updated Name" },
                    { "cvv", "456" },
                    { "Alive", "false" }
                };
                var content = new FormUrlEncodedContent(values);
                var response = client.PutAsync(ApiUrl + "/" + selectedItem.Id, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show("Response: " + responseString);
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Create button READ request to ApiUrl
            var response = client.GetAsync(ApiUrl).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            var adatArray = Adat.FromJson(responseString);
            items = new BindingList<Adat>(adatArray.ToList());
            listBox1.DataSource = items;
            listBox1.DisplayMember = "Name";
            listBox1.SelectedIndex = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Create button DELETE request to ApiUrl
            if (listBox1.SelectedItem is Adat selectedItem)
            {
                var response = client.DeleteAsync(ApiUrl + "/" + selectedItem.Id).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show("Response: " + responseString);
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }

        }
    }
}
