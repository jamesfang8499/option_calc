using System;
using System.Windows.Forms;
using option_main;

namespace bsmethod
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string s1= textBox1.Text.Trim();
            string s5 = textBox5.Text.Trim();
            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();

            double temp2 = 0, temp3 = 0, temp4 = 0, temp1 = 0, temp5 = 0;

            if (!double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3) || !double.TryParse(s4, out temp4)|| !double.TryParse(s1, out temp1) || !double.TryParse(s5, out temp5))
            {
                MessageBox.Show("输入的内容只能包含数字和小数点!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp1 <= 0 || temp2 <= 0 || temp3 <= 0 || temp4 <= 0 || temp5 <= 0)
            {
                MessageBox.Show("输入有误！输入的内容必须为正值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp3 > 1)
            {
                MessageBox.Show("输入有误！无风险利率r 必须在[0,1]内取值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            double S, K, r, T, sig;
            double d1, d2;
            double C, P;
            S = Convert.ToDouble(textBox1.Text);
            K = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            T = Convert.ToDouble(textBox4.Text);
            sig = Convert.ToDouble(textBox5.Text);

            d1 = (Math.Log(S / K) + (r + 0.5 * sig * sig) * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);

            C = S * Form1.CND(d1) - K * Math.Exp(-r * T) * Form1.CND(d2);
            P = K * Math.Exp(-r * T) * Form1.CND(-d2) - S * Form1.CND(-d1);
            textBox6.Text = Convert.ToString(C);
            textBox7.Text = Convert.ToString(P);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string s8 = textBox8.Text.Trim();
            string s5 = textBox5.Text.Trim();
            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();

            double temp2 = 0, temp3 = 0, temp4 = 0, temp8 = 0, temp5 = 0;

            if (!double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3) || !double.TryParse(s4, out temp4) || !double.TryParse(s8, out temp8) || !double.TryParse(s5, out temp5))
            {
                MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            double F, K, r, T, sig;
            double d1, d2;
            double C, P;
            F = Convert.ToDouble(textBox8.Text);
            K = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            T = Convert.ToDouble(textBox4.Text);
            sig = Convert.ToDouble(textBox5.Text);

            d1 = (Math.Log(F / K) + 0.5 * sig * sig * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);

            C = (F * Form1.CND(d1) - K  * Form1.CND(d2))* Math.Exp(-r * T);
            P = (K * Form1.CND(-d2) - F * Form1.CND(-d1) )* Math.Exp(-r * T);
            textBox9.Text = Convert.ToString(C);
            textBox10.Text = Convert.ToString(P);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
                  textBox10.Text ="";
        }
    }
}
