using System;
using System.Windows.Forms;
using option_main;

namespace greeks
{
    public partial class Form44 : Form
    {
        public Form44()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();
            string s1 = textBox1.Text.Trim();
            string s5 = textBox5.Text.Trim();

            double temp2 = 0, temp3 = 0, temp4 = 0, temp1 = 0, temp5 = 0;

            if (!double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3) || !double.TryParse(s4, out temp4) || !double.TryParse(s1, out temp1) || !double.TryParse(s5, out temp5) )
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

            double S, X, r, T, sig;
            S = Convert.ToDouble(textBox1.Text);
            X = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            T = Convert.ToDouble(textBox4.Text);
            sig = Convert.ToDouble(textBox5.Text);

            
            double d1, d2;
            d1 = (Math.Log(S / X) + (r + 0.5 * sig * sig) * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            double NPRIME = 1 / Math.Sqrt(2*Math.PI) * Math.Exp(-0.5 * d1 * d1);

            double deltac, deltap;
            deltac = Form1.CND(d1); deltap = deltac-1;


            double call = S * Form1.CND(d1) - X * Math.Exp(-r * T) * Form1.CND(d2);
            double put = -S * Form1.CND(-d1) + X * Math.Exp(-r * T) * Form1.CND(-d2);
            

            double gamma=NPRIME/(S*sig*Math.Sqrt(T));


            double vega=S*Math.Sqrt(T)*NPRIME;

            double thetac, thetap;
            thetac = -(S * sig * NPRIME) / (2 * Math.Sqrt(T)) - r * X * Math.Exp(-r * T) * Form1.CND(d2);
            thetap = -(S * sig * NPRIME) / (2 * Math.Sqrt(T)) + r * X * Math.Exp(-r * T) * Form1.CND(-d2);



            double rhoc = T*X*Math.Exp(-r*T)* Form1.CND(d2);
            double rhop = -T * X * Math.Exp(-r * T) * Form1.CND(-d2);


            double vanna =vega/S *(1-d1/(sig*Math.Sqrt(T)));
            double vomma = vega * d1 * d2 / sig;

            double charm = - (NPRIME * (r / (sig * Math.Sqrt(T)) - d2 / (2 * T)));

            double speed = -gamma / S * (1 + d1 / (sig * Math.Sqrt(T)));
            double zomma = gamma * ((d1 * d2 - 1) / sig);
            double ultima = -vega / (sig * sig)*(d1 * d2*(1 - d1 * d2) + d1 * d1 + d2 * d2);

            double clambda = deltac * S / call;
            double plambda = deltap * S / put;

            double COLOR = -0.5*gamma /T* (1-d1*d2+(2*r*d1*Math.Sqrt(T))/(sig));
            double veta = -S * NPRIME * (r * d1 / sig - (1 + d1 * d2) / (2 * Math.Sqrt(T)));
            double vera = -vega * d1 * Math.Sqrt(T) / sig;




            textBox6.Text = Convert.ToString(deltac);
            textBox7.Text = Convert.ToString(thetac);
            textBox8.Text = Convert.ToString(rhoc);
            textBox9.Text = Convert.ToString(deltap);
            textBox10.Text = Convert.ToString(thetap);
            textBox11.Text = Convert.ToString(rhop);
            textBox12.Text = Convert.ToString(vega);
            textBox13.Text = Convert.ToString(gamma);
            textBox14.Text = Convert.ToString(vomma);
            textBox15.Text = Convert.ToString(vanna);
            textBox16.Text = Convert.ToString(charm);
            textBox17.Text = Convert.ToString(zomma);
            textBox18.Text = Convert.ToString(ultima);
            textBox19.Text = Convert.ToString(speed);
            textBox20.Text = Convert.ToString(plambda);
            textBox21.Text = Convert.ToString(clambda);
            textBox22.Text = Convert.ToString(COLOR);
           textBox23.Text = Convert.ToString(vera);
            textBox24.Text = Convert.ToString(veta);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
            textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = "";
            textBox11.Text = ""; textBox12.Text = ""; textBox13.Text = ""; textBox14.Text = ""; textBox15.Text = "";
            textBox16.Text = ""; textBox17.Text = ""; textBox18.Text = ""; textBox19.Text = ""; textBox20.Text = "";
            textBox21.Text = ""; textBox22.Text = ""; textBox23.Text = ""; textBox24.Text = ""; 
        }
    }
}
