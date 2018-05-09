namespace UnityEngine.UI.Extensions.ColorPicker
{
    public struct HsvColor
    {
        /// <summary>
        /// The Hue, ranges between 0 and 360
        /// </summary>
        public double H;

        /// <summary>
        /// The saturation, ranges between 0 and 1
        /// </summary>
        public double S;

        // The value (brightness), ranges between 0 and 1
        public double V;

        public float NormalizedH
        {
            get
            {
                return (float)H / 360f;
            }

            set
            {
                H = (double)value * 360;
            }
        }

        public float NormalizedS
        {
            get
            {
                return (float)S;
            }
            set
            {
                S = value;
            }
        }

        public float NormalizedV
        {
            get
            {
                return (float)V;
            }
            set
            {
                V = (double)value;
            }
        }

        public HsvColor(double h, double s, double v)
        {
            this.H = h;
            this.S = s;
            this.V = v;
        }

        public override string ToString()
        {
            return "{" + H.ToString("f2") + "," + S.ToString("f2") + "," + V.ToString("f2") + "}";
        }
    }
}