using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Calc myCalc = new Calc();
        Dictionary<string, Func<double, double>> BinaryOperations;



        public Form1()
        {
            InitializeComponent();
            BinaryOperations = new Dictionary<string, Func<double, double>>();

            BinaryOperations.Add(minus.Name, x => myCalc.Subtract(x));
            BinaryOperations.Add(plus.Name, x => myCalc.Sum(x));
            BinaryOperations.Add(multiply.Name, x => myCalc.Multiply(x));
            BinaryOperations.Add(divided.Name, x => myCalc.Divided(x));
           
        }

        

        private void btn1_Click(object sender, EventArgs e)
        {
            input.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            input.Text += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            input.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            input.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            input.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            input.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            input.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            input.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            input.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            input.Text += "0";
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (input.Text.Equals(""))
                input.Text += "0,";

            else if (input.Text.IndexOf(",") == -1)
                input.Text += ",";  

        }


        private void clear_Click(object sender, EventArgs e)
        {
            myCalc.Clear();
            input.Text = "";

            plus.Enabled = true;
            minus.Enabled = true;
            multiply.Enabled = true;
            divided.Enabled = true;


        }

        private double GetCurrentNumber() {
            return Convert.ToDouble(input.Text);
        }

        private void plus_Click(object sender, EventArgs e)
        {
            Save();
            //plus.Enabled = false;
            //input.Text = plus.Tag.ToString();
            SetLastButton(plus);


        }

        private void minus_Click(object sender, EventArgs e)
        {
            //if (input.Text == "")
            //{
            //    input.Text += "-";
            //    myCalc.Multiply(-1);

            //}
            //else {
            //    Save();
            //    minus.Enabled = false;
            //}

            Save();
            SetLastButton(minus);
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            Save();
            //multiply.Enabled = false;
            SetLastButton(multiply);



        }

        private void divided_Click(object sender, EventArgs e)
        {
            Save();
            //divided.Enabled = false;
            SetLastButton(divided);


        }
        private void precent_Click(object sender, EventArgs e)
        {
            Save();
            input.Text = myCalc.Percent().ToString();
        }   


        private void sqrt_Click(object sender, EventArgs e)
        {
            Save();
            input.Text = (myCalc.num1 >= 0) ? myCalc.FindARooot().ToString() : "ERROR";
           
        }

        private void result_Click(object sender, EventArgs e)

        {
            if (GetLastButton() != null)
                input.Text = (BinaryOperations[GetLastButton().Name](GetCurrentNumber())).ToString();
             

            //input.Text = BinaryOperations[GetLastButton().Name]
            //double num2 = Convert.ToDouble(input.Text);
            //double result = num2;

            //if (!minus.Enabled)
            //{
            //    result = myCalc.Subtract(num2);
            //    minus.Enabled = true;
            //}
            //else if (!plus.Enabled) 
            //{
            //    result = myCalc.Sum(num2);
            //    plus.Enabled = true;

            //}
            //else if (!multiply.Enabled)
            //{
            //    result = myCalc.Multiply(num2);
            //    multiply.Enabled = true;

            //}
            //else if (!divided.Enabled)
            //{
            //    result = myCalc.Divided(num2);
            //    divided.Enabled = true;

            //}


            //input.Text = result.ToString();



        }
        private Button GetLastButton() {
            foreach (Button current in this.Controls.OfType<Button>())
            {
                    if (current.Tag != null)
                        if (current.Tag.ToString() == "1") return current;
            }
            return null;
        }
        private void SetLastButton(Button button) 
        {
            foreach (Button current in this.Controls.OfType<Button>()) 
            {
                if (current.Name != button.Name)
                    current.Tag = 0;
                else current.Tag = 1;
            }
        }

        private void Save() 
        {
            if (!input.Text.Equals("")) 
            {
                myCalc.Save(Convert.ToDouble(input.Text));
                input.Clear();

            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            bool flag = true;
            int index = -1;

            foreach (var simb in input.Text)
            {
                if (simb < '0' || simb > '9')
                {
                    flag = false;
                    index = input.Text.IndexOf(simb);
                    //input.Text = input.Text.Remove(input.Text.Length - 1);
                }

            }

            if (!flag)
                input.Text = input.Text.Remove(index);


        }
    }
}
