using System;
using System.Windows.Forms;

namespace option_main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            impvol.Form11 b1Frm = new impvol.Form11();
            b1Frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bsmethod.Form22 b2Frm = new bsmethod.Form22();
            b2Frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            binomethod.Form33 b3Frm = new binomethod.Form33 ();
            b3Frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            greeks.Form44 b4Frm = new greeks.Form44();
            b4Frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            delta_gamma.Form55 b5Frm = new delta_gamma.Form55();
            b5Frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static double CND(double d)
        {
            const double A1 = 0.31938153;
            const double A2 = -0.356563782;
            const double A3 = 1.781477937;
            const double A4 = -1.821255978;
            const double A5 = 1.330274429;
            const double RSQRT2PI = 0.39894228040143267793994605993438;

            double
            K = 1.0 / (1.0 + 0.2316419 * Math.Abs(d));

            double
            CND = RSQRT2PI * Math.Exp(-0.5 * d * d) *
                  (K * (A1 + K * (A2 + K * (A3 + K * (A4 + K * A5)))));

            if (d > 0)
                CND = 1.0 - CND;

            if (d == 0)
                CND = 0.5;

            return CND;
        }

    }
}