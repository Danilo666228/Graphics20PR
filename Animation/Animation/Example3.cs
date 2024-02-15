using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    public partial class Example3 : Form
    {
        SolidBrush bgcol = new SolidBrush(Color.Black);

        int cnt1 = 0;

        float SpeedA = 0;
        float SpeedB = 0;
        float SpeedC = 0;
        float SpeedD = 0;
        float SpeedE = 0;
        float SpeedF = 0;
        float SpeedG = 0;
        float SpeedH = 0;
        float SpeedI = 0;
        public Example3()
        {
            InitializeComponent();
        }

        private void Example3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt1++;

            SpeedA += (float)1.1;
            SpeedB += (float)1;
            SpeedC += (float)0.9;
            SpeedD += (float)0.8;
            SpeedE += (float)0.7;
            SpeedF += (float)0.6;
            SpeedG += (float)0.5;
            SpeedH += (float)0.4;
            SpeedI += (float)0.3;

            if (cnt1 == 3600)
            {
                cnt1 = 0;
                SpeedA = 0;
                SpeedB = 0;
                SpeedC = 0;
                SpeedD = 0;
                SpeedE = 0;
                SpeedF = 0;
                SpeedG = 0;
                SpeedH = 0;
                SpeedI = 0;
            }
            RotatingFigures();
        }
        private void SetPolygon(PointF center, int vertexes, float radius, Graphics graphics, Bitmap bmp, float speed)
        {
            var angle = Math.PI * 2 / vertexes;
            var points = Enumerable.Range(0, vertexes).Select(i => PointF.Add(center, new SizeF((float)Math.Sin(i * angle) * radius, (float)Math.Cos(i * angle) * radius)));
            SolidBrush transparent = new SolidBrush(Color.FromArgb(30, 255, 0, 0));
            graphics.TranslateTransform((float)pictureBox1.Width / 2, (float)pictureBox1.Height / 2);
            graphics.RotateTransform(speed);
            graphics.FillPolygon(transparent,points.ToArray());
        }
        private void RotatingFigures()
        {
            Bitmap btmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics a = Graphics.FromImage(btmp);
            Graphics b = Graphics.FromImage(btmp);
            Graphics c = Graphics.FromImage(btmp);
            Graphics d = Graphics.FromImage(btmp);
            Graphics e = Graphics.FromImage(btmp);
            Graphics f = Graphics.FromImage(btmp);
            Graphics g = Graphics.FromImage(btmp);
            Graphics h = Graphics.FromImage(btmp);
            Graphics i = Graphics.FromImage(btmp);

            g.FillRectangle(bgcol,0,0,500,500);

            SetPolygon(new PointF(0, 0), 3, 20, a, btmp, SpeedA);
            SetPolygon(new PointF(0, 0), 4, 45, b, btmp, SpeedB);
            SetPolygon(new PointF(0, 0), 5, 70, c, btmp, SpeedC);
            SetPolygon(new PointF(0, 0), 6, 95, d, btmp, SpeedD);
            SetPolygon(new PointF(0, 0), 7, 120, e, btmp, SpeedE);
            SetPolygon(new PointF(0, 0), 8, 145, f, btmp, SpeedF);
            SetPolygon(new PointF(0, 0), 9, 170, g, btmp, SpeedG);
            SetPolygon(new PointF(0, 0), 10, 195, h, btmp, SpeedH);
            SetPolygon(new PointF(0, 0), 11, 220, i, btmp, SpeedI);
            pictureBox1.BackgroundImage = btmp;
        }
    }
}
