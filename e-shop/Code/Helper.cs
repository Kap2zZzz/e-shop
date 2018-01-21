using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Code
{
    public static class Helper
    {
        public static List<string> Category()
        {
            List<string> c = new List<string> { "Тепла підлога", "Кабель" };
            return c;
        }
    }
}