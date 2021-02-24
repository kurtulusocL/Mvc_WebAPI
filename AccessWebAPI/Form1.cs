using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessWebAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAccess_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58480/");
            HttpResponseMessage response = await client.GetAsync("api/lessons");
            string result = await response.Content.ReadAsStringAsync();
            if (result.Length > 0)
            {
                label1.Text = "It done";
                rText.Text = result;
            }
            else
            {
                MessageBox.Show("There is an error, please check to your code or system.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
