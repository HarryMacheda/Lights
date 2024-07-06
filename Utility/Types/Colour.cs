using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Types
{
    public class Colour
    {
        public float R { get; set; } 
        public float G { get; set; }
        public float B { get; set; }


        public Colour(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Colour(string hex)
        {
            Color c = System.Drawing.ColorTranslator.FromHtml(hex);
            R = c.R;
            G = c.G;
            B = c.B;
        }
        public override string ToString()
        {
            return "{" + R.ToString() + ", " + G.ToString() + ", " + B.ToString() + "}";
        }

        public static List<Colour> Gradient(Colour start, Colour end, int steps)
        {
            List<Colour> result = new List<Colour>();
            Colour delta = (end - start) / (steps);
            result.Add(start);
            for(int i = 0; i < steps - 2; i++)
            {
                result.Add(result[i] + delta);
            }
            result.Add(end);
            return result;
        }

        public static List<Colour> Gradient(List<Colour> colours, int steps, bool loop = false)
        {
            if (loop) { colours.Add(colours[0]); }
            List<Colour> result = new List<Colour>();
            int countPerGradient = steps / (colours.Count - 1);
            int rangeCount = colours.Count - 1;
            for (int i = 0; i < rangeCount; i++) 
            {
                result.AddRange(Gradient(colours[i], colours[i + 1], i == (rangeCount - 1) ? steps - result.Count : countPerGradient));
            }
            return result;
        }

        public static implicit operator Colour(string colour)
        {
            return (Colour)System.Drawing.ColorTranslator.FromHtml(colour);
        }

        public static implicit operator System.Drawing.Color(Colour colour)
        {
            return System.Drawing.Color.FromArgb((int)Math.Max(0, colour.G), (int)Math.Max(0, colour.R), (int)Math.Max(0, colour.B)); //led strip uses grb
        }

        public static implicit operator Colour(System.Drawing.Color color)
        {
            return new Colour(color.R, color.G, color.B);
        }

        public static Colour operator -(Colour colour1, Colour colour2)
        {
            return new Colour(colour1.R - colour2.R, colour1.G - colour2.G, colour1.B - colour2.B);
        }

        public static Colour operator +(Colour colour1, Colour colour2)
        {
            return new Colour(colour1.R + colour2.R, colour1.G + colour2.G, colour1.B + colour2.B);
        }

        public static Colour operator*(Colour colour, int scale) 
        {
            return new Colour(colour.R * scale, colour.G * scale, colour.B * scale);
        }

        public static Colour operator /(Colour colour, int scale)
        {
            if (scale == 0) { throw new DivideByZeroException(); }
            return new Colour(colour.R / scale, colour.G / scale, colour.B / scale);

        }

    }
}
