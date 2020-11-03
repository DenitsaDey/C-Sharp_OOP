using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string InvalidExceptionMsg = "{0} cannot be zero or negative.";
        
        private double length;
        private double width;
        private double height;
        
        
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(InvalidExceptionMsg, paramName));
            }
        }

        public double CalculateSurface()
        {
            double surface = (2 * this.Length * this.Width) + this.CalculateLateralSurface();
            return surface;
        }

        public double CalculateLateralSurface()
        {
            double surface = 2 * (this.Width * this.Height + this.Height * this.Length);
            return surface;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {this.CalculateSurface():f2}")
                .AppendLine($"Lateral Surface Area - {this.CalculateLateralSurface():f2}")
                .AppendLine($"Volume - {this.CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
