using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPFTest1.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine("Thread.CurrentThread.IsBackground=" + Thread.CurrentThread.IsBackground);
                    Thread.Sleep(1000);
                }
            });
            //Thread thread = new Thread(() =>
            //{
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        Console.WriteLine("Thread.CurrentThread.IsBackground=" + Thread.CurrentThread.IsBackground);
            //        Thread.Sleep(1000);
            //    }
            //});
            //thread.Start();
        }
    }
}
