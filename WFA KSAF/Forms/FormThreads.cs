using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WFA.KSAF.Forms
{
    public partial class Threads : Form
    {
        public Threads()
        {
            InitializeComponent();
        }
        StringBuilder sb1 = new StringBuilder(), sb2 = new StringBuilder(), sb3 = new StringBuilder(), sb4 = new StringBuilder(), sb5 = new StringBuilder();
        string separator = "------------------------------\r\n";

        private void button3_Click(object sender, EventArgs e)
        {

            for (int i=0;i<100;i++)
            {
                var str = random();
                richTextBox1.Text += str[0] + str[1] + str[2] + "\r\n";
                richTextBox2.Text += str[0] + str[1] + str[3] + "\r\n";
            }
        }
        Random rnd = new Random();
        private string[] random()
        {
            double ar = rnd.Next(0,100)*0.1 - 5;
            double lf = rnd.Next(0, 10) - 5;
            return new string[] { ar.ToString()+ " ^ ", lf.ToString() + " = ", Pow(ar, lf).ToString(), Math.Pow(ar, lf).ToString() };
        }
        private double Pow(double arg, double leaf)
        {
            if (arg > 0) return Math.Pow(arg, leaf);
            double result = 0;
            int floatlenght = 0;
            double tmp = arg;
            while ((int)tmp % 10 == 0 && tmp != 0)
            {
                tmp *= 10;
                floatlenght++;
            }
            bool negatArg = false;
            if ((leaf) % 2 != 0)
            {
                arg = arg * -1;
                negatArg = true;
            }
            result = Math.Pow(arg, leaf);
            if (negatArg == true) result = result * -1;
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sendParams sendParams1 = new sendParams
            {
                sb = sb1
            };
            sendParams sendParams2 = new sendParams
            {
                sb = sb2
            };
            sendParams sendParams3 = new sendParams
            {
                sb = sb3
            };
            sendParams sendParams4 = new sendParams
            {
                sb = sb4
            };
            sendParams sendParams5 = new sendParams
            {
                sb = sb5
            };
            Counter(sendParams1);
            Counter(sendParams2);
            Counter(sendParams3);
            Counter(sendParams4);
            Counter(sendParams5);

            richTextBox1.Text += sb1 + separator;
            richTextBox1.Text += sb2 + separator;
            richTextBox1.Text += sb3 + separator;
            richTextBox1.Text += sb4 + separator;
            richTextBox1.Text += sb5 + separator;
            TimeSpan ts = stopWatch.Elapsed;
            label1.Text = ts.ToString();
        }
        private void Counter(object sb)
        {
            sendParams param = sb as sendParams;
            for (int i=0;i<1000000;i++)
            {
                //var fhgf = 500/20;
                param.sb.Append(i.ToString());
                param.sb.Append("\r\n");
            }
        }
        static void sda()
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var thread = new Thread(Counter);
            thread.Name = "sda";
            thread.Start(sb1);

            var thread2 = new Thread(Counter);
            thread2.Name = "sda2";
            thread2.Start(sb2);

            var thread3 = new Thread(Counter);
            thread3.Name = "sda3";
            thread3.Start(sb3);

            var thread4 = new Thread(Counter);
            thread4.Name = "sda4";
            thread4.Start(sb4);

            var thread5 = new Thread(Counter);
            thread5.Name = "sda5";
            thread5.Start(sb5);

            while (thread.IsAlive) ;
            while (thread2.IsAlive) ;
            while (thread3.IsAlive) ;
            while (thread4.IsAlive) ;
            while (thread5.IsAlive) ;

            //richTextBox2.Text += sb1 + separator;
            //richTextBox2.Text += sb2 + separator;
            //richTextBox2.Text += sb3 + separator;
            //richTextBox2.Text += sb4 + separator;
            //richTextBox2.Text += sb5 + separator;
            TimeSpan ts = stopWatch.Elapsed;
            label2.Text = ts.ToString();
        }
    }
    class sendParams
    {
        public StringBuilder sb { get; set; }
    }
}
