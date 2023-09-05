using System;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace ColorName
{
    public static partial class ColorNameProvider
    {
        public static (string colorName, bool exactMatch) GetColorNameFromRGB(byte r, byte g, byte b)
        {
            return GetColorNameFromHex($"{r:X2}{g:X2}{b:X2}");
        }

        /// <summary>
        /// Get color name from its hex representation. 
        /// </summary>
        /// <param name="hex">Supports following formats:
        /// #AABBCC - long version with leading #
        /// AABBCC - long version
        /// #ABC - shorthand version with leading #
        /// ABC - shorthand version
        /// </param>
        /// <returns>Name of the color and indication if we have an exact match or approximation only</returns>
        public static (string colorName, bool exactMatch) GetColorNameFromHex(string hex)
        {
            var hexClean = hex.Replace("#", "").Trim();

            if (string.IsNullOrEmpty(hexClean) || (hexClean.Length != 6 && hexClean.Length != 3))
            {
                return (InvalidColor, false);
            }

            if (!IsHexadecimal(hexClean))
            {
                return (InvalidColor, false);
            }

            if (hexClean.Length == 3)
            {
                // convert to long hex form
                hexClean = string.Concat(hexClean.Select(c => $"{c}{c}"));
            }


            if (Names.ContainsKey(hexClean))
            {
                return (Names[hexClean], true);
            }

            return (GetClosestColor(hexClean), false);
        }

        private static bool IsHexadecimal(string input)
        {
            return BigInteger.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out _);
        }

        private static string GetClosestColor(string hexColor)
        {
            double minDistance = double.MaxValue;
            string closestColor = InvalidColor;
            var rgbColor = GetRgbFromHex(hexColor);

            foreach (var color in Names)
            {
                var rgbColorKey = GetRgbFromHex(color.Key);
                var distance = GetColorDistanceInRgb(rgbColor, rgbColorKey) + GetColorDistanceInHls(rgbColor, rgbColorKey) * 2;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = color.Value;
                }
            }

            return closestColor;
        }

        private static double GetColorDistanceInRgb((byte r, byte g, byte b) rgbColor1, (byte r, byte g, byte b) rgbColor2)
        {
            return (Math.Pow(rgbColor1.r - rgbColor2.r, 2) + Math.Pow(rgbColor1.g - rgbColor2.g, 2) + Math.Pow(rgbColor1.b - rgbColor2.b, 2));
        }

        private static double GetColorDistanceInHls((byte r, byte g, byte b) rgbColor1, (byte r, byte g, byte b) rgbColor2)
        {
            var color1 = Color.FromArgb(rgbColor1.r, rgbColor1.g, rgbColor1.b);

            // get HLS normalized to RGB range
            var h1 = (color1.GetHue() / 360.0) * 255.0;
            var s1 = color1.GetSaturation() * 255.0;
            var l1 = color1.GetBrightness() * 255.0;

            var color2 = Color.FromArgb(rgbColor2.r, rgbColor2.g, rgbColor2.b);

            // get HLS normalized to RGB range
            var h2 = (color2.GetHue() / 360.0) * 255.0;
            var s2 = color2.GetSaturation() * 255.0;
            var l2 = color2.GetBrightness() * 255.0;

            return (Math.Pow(h1 - h2, 2) + Math.Pow(s1 - s2, 2) + Math.Pow(l1 - l2, 2));
        }

        private static (byte r, byte g, byte b) GetRgbFromHex(string hexColor)
        {
            var r = byte.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = byte.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = byte.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return (r, g, b);
        }
    }
}
