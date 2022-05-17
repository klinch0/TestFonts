using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace TestFonts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InstalledFontCollection installedFontCollection = new InstalledFontCollection();
                var fontFamilies = installedFontCollection.Families;
                var fonts = new List<string>();
                foreach (var fontName in fontFamilies)
                {
                    Console.WriteLine($"{fontName.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            while (true) { }
        }
    }
}
