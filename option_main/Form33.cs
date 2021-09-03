using System;
using System.Windows.Forms;

namespace binomethod
{
    public partial class Form33 : Form
    {
        public Form33()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("输入的内容不能为空，请重新输入!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            string s1 = textBox1.Text.Trim();
            string s2 = textBox2.Text.Trim();
            string s3 = textBox3.Text.Trim();
            string s4 = textBox4.Text.Trim();
            string s5 = textBox5.Text.Trim();
            string s6 = textBox6.Text.Trim();
            string s7 = textBox11.Text.Trim();

            double temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0, temp6 = 0, temp7 = 0;
            Int32 temp5 = 0;

            if (!double.TryParse(s1, out temp1) || !double.TryParse(s2, out temp2) || !double.TryParse(s3, out temp3)
                || !double.TryParse(s4, out temp4) || !Int32.TryParse(s5, out temp5) 
                || !double.TryParse(s6, out temp6) || !double.TryParse(s7, out temp7))
            {
                MessageBox.Show("输入的内容只能包含数字和小数点!", "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (temp1 <= 0 || temp2 <= 0 || temp3 <= 0 || temp4 <= 0 || temp5 <= 0 || temp6 <= 0)
            {
                MessageBox.Show("输入有误！输入的内容必须为正值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp7 < 0)
            {
                MessageBox.Show("输入有误！输入的内容必须非负，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (temp3 > 1)
            {
                MessageBox.Show("输入有误！无风险利率r 必须在[0,1]内取值，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (temp5 > 2000)
            {
                DialogResult mess = MessageBox.Show("期数N 设置较大，程序需要运行较长时间，是否耐心等待？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (mess == DialogResult.Cancel)
                {
                    return;
                }

            }



            double S, K, r, T, sigma;
            double u, d, q, dt;

            Int32 N;
            S = Convert.ToDouble(textBox1.Text);
            K = Convert.ToDouble(textBox2.Text);
            r = Convert.ToDouble(textBox3.Text);
            sigma = Convert.ToDouble(textBox4.Text);
            N = Convert.ToInt32(textBox5.Text);
            T = Convert.ToDouble(textBox6.Text);
            double q1 = Convert.ToDouble(textBox11.Text);
            dt = T/N;
            u = Math.Exp(sigma*Math.Sqrt(dt));
            d = 1 / u;
            q = (Math.Exp((r-q1) * dt) - d) / (u - d);


            double[] C1 = new double[N + 1];
            double[] C2 = new double[N + 1];
            double[] P1 = new double[N + 1];
            double[] P2 = new double[N + 1];
            for (int i = 0; i <= N; i++)
            {
                C1[i] = Math.Max(S * Math.Pow(d, i) * Math.Pow(u, (N - i)) - K, 0);  //欧式看涨
                C2[i] = Math.Max(S * Math.Pow(d, i) * Math.Pow(u, (N - i)) - K, 0);  //美式看涨
                P1[i] = Math.Max(-S * Math.Pow(d, i) * Math.Pow(u, (N - i)) + K, 0); //欧式看跌
                P2[i] = Math.Max(-S * Math.Pow(d, i) * Math.Pow(u, (N - i)) + K, 0); //美式看跌
            }

            for (int j = 1; j <= N; j++)
            {
                for (int i = 0; i <= N - j; i++)
                {
                    C1[i] = Math.Exp(-r * T / N) * (q * C1[i] + (1 - q) * C1[i + 1]);
                    C2[i] = Math.Max(S * Math.Pow(d, i) * Math.Pow(u, (N - j - i)) - K, Math.Exp(-r * T / N) * (q * C2[i] + (1 - q) * C2[i + 1]));
                    P1[i] = Math.Exp(-r * T / N) * (q * P1[i] + (1 - q) * P1[i + 1]);
                    P2[i] = Math.Max(-S * Math.Pow(d, i) * Math.Pow(u, (N - j - i)) + K, Math.Exp(-r * T / N) * (q * P2[i] + (1 - q) * P2[i + 1]));
                }
            }

            textBox7.Text = Convert.ToString(C1[0]);
            textBox8.Text = Convert.ToString(P1[0]);
            textBox9.Text = Convert.ToString(C2[0]);
            textBox10.Text = Convert.ToString(P2[0]);

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
            textBox11.Text = "0";
        }
    }
}
