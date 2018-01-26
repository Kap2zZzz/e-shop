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
            List<string> c = new List<string> { "Тепла підлога", "Терморегулятори", "Кабель", "Світлодіодна стрічка", "Інше 1", "Інше 2", "Інше 3" };
            c.Sort();
            return c;
        }

        public static List<string> StatusOrder()
        {
            List<string> so = new List<string> { "Нове замовлення", "В роботі", "Виконано", "Відмовлено" };
            return so;
        }
    }
}