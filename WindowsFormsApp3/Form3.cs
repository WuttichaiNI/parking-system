using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        const String connectionString = @"Server=localhost;Database=user;Uid=root;Pwd=";
        String uuid = "";
        String fname = "";
        String lname = "";
        String rank = "";
        String grop = "";
        String image = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into user(id, fname, lname, rank, grop, image) values(?, ?, ?, ?, ?, ?)";

            cmd.Parameters.Add("id", MySqlDbType.VarChar).Value = uuid;
            cmd.Parameters.Add("fname", MySqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("lname", MySqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("rank", MySqlDbType.VarChar).Value = rank;
            cmd.Parameters.Add("grop", MySqlDbType.VarChar).Value = grop;
            cmd.Parameters.Add("image", MySqlDbType.VarChar).Value = "jav.png";

            cmd.ExecuteNonQuery();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox3.Items.Clear();
            foreach (string comport in ports)
            {
                comboBox3.Items.Add(comport);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fname = textBox1.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            lname = textBox5.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            uuid = textBox4.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
