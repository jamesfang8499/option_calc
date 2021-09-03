using System;
using System.Windows.Forms;
using option_main;


namespace delta_gamma
{
    public partial class Form55 : Form
    {
        public Form55()
        {
            InitializeComponent();
        }


        // BS call spot
        static double blsC(double S, double K, double r, double T, double sig)
        {
            double d1, d2, C;
            d1 = (Math.Log(S / K) + (r + 0.5 * sig * sig) * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            C = S * Form1.CND(d1) - K * Math.Exp(-r * T) * Form1.CND(d2);
            return C;
        }

        //BS put spot 
        static double blsP(double S, double K, double r, double T, double sig)
        {
            double d1, d2, P;
            d1 = (Math.Log(S / K) + (r + 0.5 * sig * sig) * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            P = K * Math.Exp(-r * T) * Form1.CND(-d2) - S * Form1.CND(-d1);
            return P;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();
            string s1 = textBox1.Text.Trim();
            string s5 = textBox5.Text.Trim();
            string s6 = textBox6.Text.Trim();

            double temp2 = 0, temp3 = 0, temp4 = 0, temp1 = 0, temp5 = 0, temp6 = 0;

            if (!double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3) || !double.TryParse(s4, out temp4) || !double.TryParse(s1, out temp1) || !double.TryParse(s5, out temp5) || !double.TryParse(s6, out temp6))
            {
                MessageBox.Show("输入的内容只能包含数字和小数点!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp1 <= 0 || temp2 <= 0 || temp3 <= 0 || temp4 <= 0 || temp5 <= 0 || temp6 <= 0)
            {
                MessageBox.Show("输入有误！输入的内容必须为正值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp3 > 1)
            {
                MessageBox.Show("输入有误！无风险利率r 必须在[0,1]内取值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            double S, X, r, T, sig, DS;
            S = Convert.ToDouble(textBox1.Text);
            X = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            T = Convert.ToDouble(textBox4.Text);
            sig = Convert.ToDouble(textBox5.Text);
            DS= Convert.ToDouble(textBox6.Text);

            if (DS > S)
            {
                MessageBox.Show("输入的标的资产价格变动ΔS过大，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox10.Text = Convert.ToString(S + DS);
            textBox11.Text = Convert.ToString(S - DS);

            double d1, d2;
            d1 = (Math.Log(S / X) + (r + 0.5 * sig * sig) * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            double NPRIME = 1 / Math.Sqrt(2 * Math.PI) * Math.Exp(-0.5 * d1 * d1);

            double deltac, deltap;
            deltac = Form1.CND(d1); deltap = deltac - 1;

            double gamma = NPRIME / (S * sig * Math.Sqrt(T));

            textBox7.Text = Convert.ToString(deltac);
            textBox8.Text = Convert.ToString(deltap);
            textBox9.Text = Convert.ToString(gamma);
            textBox26.Text = Convert.ToString(gamma);

 


            double C1 = blsC( S,  X,  r,  T,  sig);
            double P1 = blsP( S,  X,  r,  T,  sig);
            textBox24.Text = Convert.ToString(C1);
            textBox25.Text = Convert.ToString(P1);

            double C11 = blsC(S+DS, X, r, T, sig);
            double P11 = blsP(S + DS, X, r, T, sig);
            textBox12.Text = Convert.ToString(C11);
            textBox18.Text = Convert.ToString(P11);

            double C12 = blsC(S-DS, X, r, T, sig);
            double P12 = blsP(S - DS, X, r, T, sig);
            textBox15.Text = Convert.ToString(C12);
            textBox21.Text = Convert.ToString(P12);

            double C21=C1+DS*deltac;
            double C22 = C1 - DS * deltac;
            textBox13.Text = Convert.ToString(C21);
            textBox16.Text = Convert.ToString(C22);

            double C31 = C1 + DS * deltac + 0.5 * gamma * DS * DS;
            double C32 = C1 - DS * deltac + 0.5 * gamma * DS * DS;
            textBox14.Text = Convert.ToString(C31);
            textBox17.Text = Convert.ToString(C32);

            double P21 = P1 + DS * deltap;
            double P22 = P1 - DS * deltap;
            textBox19.Text = Convert.ToString(P21);
            textBox22.Text = Convert.ToString(P22);

            double P31 = P1 + DS * deltap + 0.5 * gamma * DS * DS;
            double P32 = P1 - DS * deltap + 0.5 * gamma * DS * DS;
            textBox20.Text = Convert.ToString(P31);
            textBox23.Text = Convert.ToString(P32);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";

        }
    }
}
