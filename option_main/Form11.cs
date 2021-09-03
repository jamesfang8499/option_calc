using System;
using System.Windows.Forms;
using option_main;


namespace impvol
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            radioButton1.Checked = true;
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


        // BS call FUTURE
        static double blkC(double F, double K, double r, double T, double sig)
        {
            double d1, d2, c;
            d1 = (Math.Log(F / K) + 0.5 * sig * sig * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            c = (F * Form1.CND(d1) - K * Form1.CND(d2)) * Math.Exp(-r * T);
            return c;
        }

        //BS put FUTURE 
        static double blkP(double F, double K, double r, double T, double sig)
        {
            double d1, d2, p;
            d1 = (Math.Log(F / K) + 0.5 * sig * sig * T) / (sig * Math.Sqrt(T));
            d2 = d1 - sig * Math.Sqrt(T);
            p = (K * Form1.CND(-d2) - F * Form1.CND(-d1)) * Math.Exp(-r * T);
            return p;
        }


        //迭代参数设定

        const double tolerance = 1e-10;
        const double lower = 0.00001;
        const double upper=10;

        static double impvolC(double S, double K, double r, double T, double C)
        {
            double a = lower, b = upper, tmp = 0.5 * (a + b);
            if ((C - blsC(S, K, r, T, a)) * (C - blsC(S, K, r, T, b)) > 0 || C>S)
            {
                MessageBox.Show("无解，请重新输入！","警告！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            else do
                {
                    tmp=0.5*(a+b);
                if (blsC(S, K, r, T, tmp) > C )
                {
                   b = tmp;
                }
                else a = tmp;
                }
                while (Math.Abs(blsC(S, K, r, T, tmp) - C)>tolerance);
            return tmp;
        }


        static double impvolP(double S, double K, double r, double T, double P)
        {
            double a = lower, b = upper, tmp = 0.5 * (a + b);
            if ((P - blsP(S, K, r, T, a)) * (P - blsP(S, K, r, T, b)) > 0 || P>S)
            {
                MessageBox.Show("无解，请重新输入！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            else do
                {
                    tmp=0.5*(a+b);
                if (blsP(S, K, r, T, tmp) > P )
                {
                   b = tmp;
                }
                else a = tmp;
                }
                while (Math.Abs(blsP(S, K, r, T, tmp) - P)>tolerance);
            return tmp;
        }

        static double impvolCF(double S, double K, double r, double T, double C)
        {
            double a = lower, b = upper, tmp = 0.5 * (a + b);
            if ((C - blkC(S, K, r, T, a)) * (C - blkC(S, K, r, T, b)) > 0 || C>S)
            {
                MessageBox.Show("无解，请重新输入！","警告！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            else do
                {
                    tmp=0.5*(a+b);
                if (blkC(S, K, r, T, tmp) > C )
                {
                   b = tmp;
                }
                else a = tmp;
                }
                while (Math.Abs(blkC(S, K, r, T, tmp) - C)>tolerance);
            return tmp;
        }


        static double impvolPF(double S, double K, double r, double T, double P)
        {
            double a = lower, b = upper, tmp = 0.5 * (a + b);
            if ((P - blkP(S, K, r, T, a)) * (P - blkP(S, K, r, T, b)) > 0 || P>S)
            {
                MessageBox.Show("无解，请重新输入！","警告！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            else do
                {
                    tmp=0.5*(a+b);
                if (blkP(S, K, r, T, tmp) > P )
                {
                   b = tmp;
                }
                else a = tmp;
                }
                while (Math.Abs(blkP(S, K, r, T, tmp) - P)>tolerance);
            return tmp;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();

            double temp2 = 0, temp3 = 0, temp4 = 0;

            
            
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3) || !double.TryParse(s4, out temp4))
            {
                MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (radioButton1.Checked)
            {
                string s1 = textBox1.Text.Trim();
                string s6= textBox6.Text.Trim();

                double temp1 = 0, temp6 = 0;

                if (textBox1.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("输入的内容不能为空，请重新输入!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!double.TryParse(s1, out temp1) || !double.TryParse(s6, out temp6))
                {
                    MessageBox.Show("输入的内容只能包含数字和小数点!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (temp1 <= 0 || temp2 <= 0 || temp3 <= 0 || temp4 <= 0 || temp6 <= 0)
                {
                    MessageBox.Show("输入有误！输入的内容必须为正值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (temp3 > 1)
                {
                    MessageBox.Show("输入有误！无风险利率r 必须在[0,1]内取值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }




                double S, K, r, T, C, imp;
                 S = Convert.ToDouble(textBox1.Text);
            K = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            T = Convert.ToDouble(textBox4.Text);
            C = Convert.ToDouble(textBox6.Text);
             imp= impvolC( S,  K,  r,  T,  C);
             textBox5.Text = Convert.ToString(imp);
            }
            else if (radioButton2.Checked)
            {
                string s1 = textBox1.Text.Trim();
                string s8 = textBox8.Text.Trim();

                double temp1 = 0, temp8 = 0;


                if (textBox1.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!double.TryParse(s1, out temp1) || !double.TryParse(s8, out temp8))
                {
                    MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                double S, K, r, T, P, imp;
                S = Convert.ToDouble(textBox1.Text);
                K = Convert.ToDouble(textBox2.Text);
                r = Convert.ToDouble(textBox3.Text);
                T = Convert.ToDouble(textBox4.Text);
                P = Convert.ToDouble(textBox8.Text);
                imp = impvolP(S, K, r, T, P);
                textBox5.Text = Convert.ToString(imp);
            }
            else if (radioButton3.Checked)
            {
                string s7 = textBox7.Text.Trim();
                string s9 = textBox9.Text.Trim();

                double temp7 = 0, temp9= 0;

                if (textBox7.Text == "" || textBox9.Text == "")
                {
                    MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!double.TryParse(s7, out temp7) || !double.TryParse(s9, out temp9))
                {
                    MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                double F, K, r, T, c, imp;
                F = Convert.ToDouble(textBox7.Text);
                K = Convert.ToDouble(textBox2.Text);
                r = Convert.ToDouble(textBox3.Text);
                T = Convert.ToDouble(textBox4.Text);
                c = Convert.ToDouble(textBox9.Text);
                imp = impvolCF(F, K, r, T, c);
                textBox5.Text = Convert.ToString(imp);
            }
            else if (radioButton4.Checked)
            {
                string s7 = textBox7.Text.Trim();
                string s10 = textBox10.Text.Trim();

                double temp7 = 0, temp10 = 0;

                if (textBox7.Text == "" || textBox10.Text == "")
                {
                    MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!double.TryParse(s7, out temp7) || !double.TryParse(s10, out temp10))
                {
                    MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double F, K, r, T, p, imp;
                F = Convert.ToDouble(textBox7.Text);
                K = Convert.ToDouble(textBox2.Text);
                r = Convert.ToDouble(textBox3.Text);
                T = Convert.ToDouble(textBox4.Text);
                p = Convert.ToDouble(textBox10.Text);
                imp = impvolPF(F, K, r, T, p);
                textBox5.Text = Convert.ToString(imp);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox7.ReadOnly = true; textBox6.ReadOnly = false;
            textBox8.ReadOnly = true; textBox9.ReadOnly = true; textBox10.ReadOnly = true; 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox7.ReadOnly = true; textBox6.ReadOnly = true;
            textBox8.ReadOnly = false; textBox9.ReadOnly = true; textBox10.ReadOnly = true; 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox7.ReadOnly = false; textBox6.ReadOnly = true;
            textBox8.ReadOnly = true; textBox9.ReadOnly = false; textBox10.ReadOnly = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox7.ReadOnly = false; textBox6.ReadOnly = true;
            textBox8.ReadOnly = true; textBox9.ReadOnly = true; textBox10.ReadOnly = false;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked=true;
            textBox7.ReadOnly = true; 
            textBox8.ReadOnly = true; textBox9.ReadOnly = true; textBox10.ReadOnly = true; 

        }
    }
}
