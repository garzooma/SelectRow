using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFSelectRow;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        class TestObject
        {
            public int OneValue { get; set; }
            public int TwoValue { get; set; }
        }

        UserControl1 dataGridUC;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridUC = new UserControl1();
            dataGridUC.InitializeComponent();

            elementHost1.Child = dataGridUC;
        }


        private void InitDataGridView()
        {
            TestObject test1 = new TestObject()
            {
                OneValue = 2,
                TwoValue = 3
            };
            TestObject test2 = new TestObject()
            {
                OneValue = 12,
                TwoValue = 13
            };
            TestObject test3 = new TestObject()
            {
                OneValue = 32,
                TwoValue = 17
            };
            List<TestObject> list = new List<TestObject>();
            list.Add(test1);
            list.Add(test2); // Not shown in code
            list.Add(test3); // Not shown in code
            dataGridView1.DataSource = list;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.Focus();
        //    int index = 0;
        //    dataGridView1.Rows[index].Selected = true;
        //    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
        //}


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.Focus();
        //    int index = 1;
        //    dataGridView1.Rows[index].Selected = true;
        //    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridUC.SetRow(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridUC.SetRow(1);
        }
    }
}
