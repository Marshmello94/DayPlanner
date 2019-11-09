using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DayPlanner
{
    public partial class Form1 : Form
    {
        string userName = Environment.UserName;
        public Form1()
        {
            InitializeComponent();
            CheckFile();
            Appearance();
        }
        void CheckFile()
        {
            if (!File.Exists($@"C:\Users\{userName}\Documents\Task.txt"))
            {
                File.CreateText($@"C:\Users\{userName}\Documents\Task.txt");
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            NewTask();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var s = File.ReadAllLines($@"C:\Users\{userName}\Documents\Task.txt");
            foreach (var st in s)
                if (st.Contains(dateTimePicker2.Value.ToShortDateString()))
                    dataGridView1.Rows.Add(st);

        }
        void GetAllTask()
        {
            foreach (string line in File.ReadLines($@"C:\Users\{userName}\Documents\Task.txt"))
            {
                var array = line.Split(':');
                dataGridView1.Rows.Add(array);
            }
        }
        void NewTask()
        {
            string str = dateTimePicker1.Value.ToShortDateString() + ":" + textBox1.Text;
            File.AppendAllText($@"C:\Users\{userName}\Documents\Task.txt", str + Environment.NewLine);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetAllTask();
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
        async void Appearance()
        {
            
            for(int i=0;i<95;i++)
            {
                await Task.Delay(50);
                Opacity += 0.01;
            }
        }
    }
}
