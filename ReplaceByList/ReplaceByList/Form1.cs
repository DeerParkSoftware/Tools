using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceByList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"F:\youtube\code\HackWriteup\TonTu\replace.txt";
            textBox2.Text = @"F:\youtube\out";
            textBox3.Text = @"F:\youtube\out\replace.txt";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            var replaceFile = textBox1.Text;
            var list = new List<string> ();
            var listText = new List<ReplaceModel>();
            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(@replaceFile))
            {
                //System.Console.WriteLine(line);
                if (!string.IsNullOrEmpty(line))
                {
                    list.Add(line);
                }
                counter++;
            }

            for (int i = 0; i < list.Count; i = i + 2)
            {
                listText.Add(new ReplaceModel()
                {
                    originText = list[i],
                    replaceText = list[i+1],
                });
            }

            foreach (var item in listText)
            {
                if (item.originText.IndexOf(item.replaceText, StringComparison.CurrentCulture) < 0)
                {
                    //label4.Text = "File replace lỗi";
                    // gián
                }
            }

            var text = System.IO.File.ReadAllText(@textBox3.Text);
            foreach (var item in listText)
            {
                text = text.Replace(item.originText, item.replaceText);
            }

            var dateString = DateTime.Now.ToString("yyyyMMddHHmmss"); ;
            System.IO.File.WriteAllTextAsync(@textBox2.Text + "\\file" + dateString, text);

            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            //System.Console.ReadLine();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class ReplaceModel
    {
        public string originText;
        public string replaceText;
    }
}
