using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP
{
    public class Polygon : Control
    {
        private Point[] points;
        public Polygon()
        {
            points = new Point[8];
            points[0] = new Point(100, 150);
            points[1] = new Point(400, 150);
            points[2] = new Point(400, 250);
            points[3] = new Point(300, 250);
            points[4] = new Point(300, 450);
            points[5] = new Point(200, 450);
            points[6] = new Point(200, 250);
            points[7] = new Point(100, 250);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.BlueViolet, 3);
            if (points != null && points.Length > 1)

                g.DrawPolygon(pen, points);
            double area = CalculatePolygonArea();
            string areaText = $"Area of the polygon: {area}mm^2";
            Font font = new Font(FontFamily.GenericMonospace, 10);
            g.DrawString(areaText, font, Brushes.Black, 10, 10);
            PointF centroid = CalculateCentroid(points);
            float size = 5.0f; 
            g.FillEllipse(Brushes.Blue, centroid.X - size / 2, centroid.Y - size / 2, size, size);
            string centroidLabel =$"G ({centroid.X},{centroid.Y})";
            using (Font fontG = new Font("GenericMonospace", 20))
            {            
                SizeF stringSize = g.MeasureString(centroidLabel, font);
                PointF stringPosition = new PointF(centroid.X - stringSize.Width / 2, centroid.Y - size / 2 - stringSize.Height);
                g.DrawString(centroidLabel, font, Brushes.Blue, stringPosition);
            }
        }
        private double CalculatePolygonArea()
        {
            double area = 0;

            if (points != null && points.Length >= 3)
            {
                int numPoints = points.Length;

                for (int i = 0; i < numPoints - 1; i++)
                {
                    area += (points[i].X * points[i + 1].Y) - (points[i + 1].X * points[i].Y);
                }


                area += (points[numPoints - 1].X * points[0].Y) - (points[0].X * points[numPoints - 1].Y);


                area = Math.Abs(area) / 2.0;
            }

            return area;
        }
        private PointF CalculateCentroid(Point[] points)
        {
          
            double area = CalculatePolygonArea();
            double cx = 0;
            double cy = 0;
            for (int i = 0; i < points.Length-1;i++)
            {
                double x1 = points[i].X;
                double y1 = points[i].Y;
                double x2 = points[i + 1].X;
                double y2 = points[i + 1].Y;
                cx += (x1 + x2) * (x1 * y2 - x2 * y1);
                cy += (y1 + y2) * (x1 * y2 - x2 * y1);
            }
            cx /= (6.0 * area);
            cy/=(6.0*area);
            return new PointF((float)cx,(float)cy);







        }
        


    }




}
