using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Компонувальник
{
    public partial class Form1 : Form
    {

        private LayoutDesigner.PizzaBuilder builder;

        private LayoutDesigner.PizzaComponent component;
        public Form1()
        {
            InitializeComponent();

            builder = new LayoutDesigner.PizzaBuilder();
            LayoutDesigner.PizzaComponent component = new LayoutDesigner.PizzaComponent("MyComponent", 10.0);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                double wheelDecoratorPrice = Convert.ToDouble(textBox5.Text);
                builder.AddWheelDecorator(textBox5.Text, wheelDecoratorPrice);
            }

            if (checkBox2.Checked)
            {
                double seatDecoratorPrice = Convert.ToDouble(textBox6.Text);
                builder.AddSeatDecorator(textBox6.Text, seatDecoratorPrice);
            }

            if (checkBox3.Checked)
            {
                double handlebarDecoratorPrice = Convert.ToDouble(textBox7.Text);
                builder.AddHandlebarDecorator(textBox7.Text, handlebarDecoratorPrice);
            }

            if (checkBox4.Checked)
            {
                double framePrice = Convert.ToDouble(textBox1.Text);
                builder.BuildFrame(textBox1.Text, framePrice);
            }
           
            if (checkBox5.Checked)
            {
                double wheelPrice = Convert.ToDouble(textBox2.Text);
                builder.BuildWheel(textBox2.Text, wheelPrice);
            }

            if (checkBox6.Checked)
            {
                double seatPrice = Convert.ToDouble(textBox3.Text);
                builder.BuildSeat(textBox3.Text, seatPrice);
            }

            if(checkBox7.Checked)
            {
                double handlebarPrice = Convert.ToDouble(textBox4.Text);
                builder.BuildHandlebar(textBox4.Text, handlebarPrice);
            }

             label1.Text = textBox8.Text;

            double sum = 0;
            if (checkBox1.Checked)
            {
                double s = 25;
                sum += s * Convert.ToDouble(textBox5.Text);
            }
            if (checkBox2.Checked)
            {
                double n = 25;
                sum += n * Convert.ToDouble(textBox6.Text);
            }
            if (checkBox3.Checked)
            {
                double ch = 30;
                sum += ch * Convert.ToDouble(textBox7.Text);
            }
            if (checkBox4.Checked)
            {
                double m = 200;
                sum += m * Convert.ToDouble(textBox1.Text);
            }
            if (checkBox5.Checked)
            {
                double ml = 210;
                sum += ml* Convert.ToDouble(textBox2.Text);
            }
            if (checkBox6.Checked)
            {
                double br = 215;
                sum += br * Convert.ToDouble(textBox3.Text);
            }
            if (checkBox7.Checked)
            {
                double si = 175;
                sum += si * Convert.ToDouble(textBox4.Text);
            }
            label2.Text = sum.ToString(); 
        }
    }
}

