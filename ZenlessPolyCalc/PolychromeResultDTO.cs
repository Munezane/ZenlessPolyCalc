using System;
using System.Collections.Generic;
using System.Text;

namespace ZenlessPolyCalc
{
    public class PolychromeResultDTO
    {
        public int TotalPolychromes { get; set; }
        public int TotalPulls 
        {
            get {
                //always round down, because 0.9 of a pull is still not enough to pull!
                return (int)Math.Round((decimal)(TotalPolychromes / 160), MidpointRounding.ToZero);
            }
        }
    }
}
