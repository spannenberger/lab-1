using System;
using System.Drawing;

namespace Library
{
    public class Rectangle
    {
        private PointF P0;
        private PointF P1;

        private float A
        {
            get
            {
                return P1.X - P0.X;
            }
        }

        private float B
        {
            get
            {
                return P1.X - P0.Y;
            }
        }


        #region Ctors
        public Rectangle(PointF d0, PointF d1)
        {
            if (d0.X > d1.X || d0.Y > d1.Y)
            {
                throw new ArgumentException("dot0 coors must be greater or equeal than dot1 coors");
            }
            P0 = d0;
            P1 = d1;
        }
        public Rectangle(float x0, float y0, float x1, float y1)
            : this(new PointF(x0, y0), new PointF(x1, y1))
        {

        }
        #endregion

        public Rectangle Scale(float scale_x = 1.0f, float scale_y = 1.0f)
        {
            if (scale_x <= 0 || scale_y <= 0)
            {
                throw new ArgumentException("Scale must be greater 0");
            }
            var newD1X = P0.X + A * scale_x;
            var newD1Y = P0.Y + B * scale_y;
            return new Rectangle(new PointF(P0.X, P0.Y), new PointF(newD1X, newD1Y));
        }

        public Rectangle Scale(float scale)
        {
            return Scale(scale, scale);
        }

        public Rectangle Move(float length_x, float length_y)
        {
            var tmpP0 = new PointF(P0.X + length_x, P0.Y + length_y);
            var tmpP1 = new PointF(P1.X + length_x, P1.Y + length_y);
            return new Rectangle(tmpP0,tmpP1);
        }

        public Rectangle Min(Rectangle rect)
        {
            var tmpX0 = Math.Min(P0.X, rect.P0.X);
            var tmpY0 = Math.Min(P0.Y, rect.P0.Y);
            var tmpX1 = Math.Max(P1.X, rect.P1.X);
            var tmpY1 = Math.Max(P1.Y, rect.P1.Y);
            return new Rectangle(tmpX0, tmpY0, tmpX1, tmpY1);
        }

        public Rectangle Intersection(Rectangle rect)
        {
            var tmpX0 = Math.Max(P0.X, rect.P0.X);
            var tmpY0 = Math.Max(P0.Y, rect.P0.Y);
            var tmpX1 = Math.Min(P1.X, rect.P1.X);
            var tmpY1 = Math.Min(P1.Y, rect.P1.Y);
            try
            {
                return new Rectangle(tmpX0, tmpY0, tmpX1, tmpY1);
            }
            catch (ArgumentException)
            {
                return null;
            }

        }

        public override string ToString()
        {
            return $"x0={P0.X}\tA={A}\ny0={P0.Y}\tB={B}";
        }
    }
}
