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
            MessageBox.Show("API URL: " + ApiUrl); // Display the API URL for verification
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
