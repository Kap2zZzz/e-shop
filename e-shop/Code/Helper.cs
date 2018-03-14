using e_shop.Entities;
using e_shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace e_shop.Code
{
    public static class Helper
    {
        public static List<string> Category()
        {
            List<string> c = new List<string> 
            { "Тепла підлога", 
              "Терморегулятори", 
              "Кабель", 
              "Щитки, бокси (метал, пластик)", 
              "LED освітлення", 
              "Автоматика", 
              "Кабеленесучі системи" 
            };
            c.Sort();
            return c;
        }

        public static List<string> StatusOrder()
        {
            List<string> so = new List<string> { "Нове замовлення", "В роботі", "Виконано", "Відмовлено" };
            return so;
        }

        //public static int getTotalItems(string category, string filter, IEnumerable<Product> products)
        //{
        //    int k = 0;

        //    if (category == null || category == string.Empty)
        //    {
        //        k = products.Count();
        //    }
        //    else if (filter == null || filter == string.Empty)
        //    {
        //        k = products.Where(p => p.Category == category).Count();
        //    }
        //    else
        //    {
        //        k = products.Where(p => p.Category == category && p.Brand == filter).Count();
        //    }
        //    //        TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Where(p => filter == null ? p.Brand != null : p.Brand == filter).Count()
        //    return k;
        //}

        //public static IEnumerable<Product> getTotalProducts(int page, int pageSize, string category, string filter, IEnumerable<Product> products)
        //{
        //    IEnumerable<Product> countProduct;

        //    if (category == null || category == string.Empty)
        //    {
        //        countProduct = products.Skip((page - 1) * pageSize).Take(pageSize);
        //    }
        //    else if (filter == null || filter == string.Empty)
        //    {
        //        countProduct = products.Where(p => p.Category == category).Skip((page - 1) * pageSize).Take(pageSize);
        //    }
        //    else
        //    {
        //        countProduct = products.Where(p => p.Category == category && p.Brand == filter).Skip((page - 1) * pageSize).Take(pageSize);
        //    }
        //    return countProduct;
        //}

        public static List<MenuView> GetMenu()
        {
            List<MenuView> _menu = new List<MenuView> { 
                new MenuView{Category = "Тепла підлога", Brand = new List<string> {"IN-TERM (Нагрівальний кабель)", "IN-TERM (Нагрівальний мат)", "GRAYHOT (Двожильний кабель)", "GRAYHOT (Двожильний мат)", "Hi Heat (Інфрачервона плівка)"}},
                new MenuView{Category = "Терморегулятори", Brand = new List<string> {"IN-TERM", "TERNEO"}},
                new MenuView{Category = "Кабель", Brand = new List<string> {"VIP Кабель (ВВГ-П)", "VIP Кабель (ПВС)", "VIP Кабель (ШВВП)", "Одеса кабель ГОСТ (ПВС)", "Одеса кабель ГОСТ (ШВВП)", "Кабель алюмінієвий", "Кабель телевізійний+відеонагляд"}},
                new MenuView{Category = "Щитки, бокси (метал, пластик)", Brand = new List<string> {"Щитки Mutlusan пласт. зовн.", "Щитки Mutlusan пласт. внутр.", "Бокси монтажні герметичні з ПМ", "Щитки внутрішні (ЩО, ЯУР)", "Щитки зовнішні (ЩО, ЯУР)"}},
                new MenuView{Category = "LED освітлення", Brand = new List<string> {"LED Original"}},
                new MenuView{Category = "Автоматика", Brand = new List<string> {"Schneider Electric (Автомати)", "Schneider Electric (ПЗВ, Диф. автомати)", "Schrack Technik (Автомати)", "Schrack Technik (ПЗВ)"}},
                new MenuView{Category = "Кабеленесучі системи", Brand = new List<string> {"Гофротрубка DКС ПВХ легка негорюча світло-сіра", "Гофра труба (ПВХ) чорна", "Металорукав", "Короб пластиковий (кабель канал)", "Труба ПВХ гладка" }},
            };
            return _menu.OrderBy(x => x.Category).ToList();
        }

        public static List<string> GetImages()
        {
            List<string> ImagesList = new List<string>();
            //string path = HttpContext.Current.Server.MapPath(@"~/Images/Product");

            foreach (var fullPath in Directory.EnumerateFiles(HttpContext.Current.Server.MapPath("~/Images/Product")))
            {
                var fileName = Path.GetFileName(fullPath);
                ImagesList.Add(fileName);
            }

            return ImagesList;
        }

        public static string GetKeywords(string category)
        {
            string keyWords = string.Empty;

            switch (category)
            {
                case "LED освітлення": keyWords = "Купити дешево Діодні лампочки, ЛЕД, LED, Даунлайт, Прожектори, Панелі, LED Original, G45, A60, MR16, C37, R39, R50, T8 у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Автоматика": keyWords = "Купити дешево Диф. автомат, Автоматичний вимикач, ПЗВ, Пристрій захисного відключення, Відсікач, Schrack, Schneider у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Кабеленесучі системи": keyWords = "Купити дешево Металорукав, Короб пластиковий, Кабель канал, Гофра, Труба, Гофротрубка, DКС, ПВХ, чорна, сіра, гладка у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Кабель": keyWords = "Купити дешево силовий кабель, ВВГ, ВВГП, ШВВП, ПВС, ГОСТ Одеса, Львів, Алюмінєвий, Мідний, Телевізійний, для відеонагляду у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Тепла підлога": keyWords = "Купити дешево теплу підлогу, нагрівальний кабель, мат, інфрачервона плівка, під ламінат, плитку, IN-TERM, GRAYHOT, FENIX, Hi Heat у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Терморегулятори": keyWords = "Купити дешево терморегулятор для теплої підлоги, програмовані, Wi-Fi, сенсорні, IN-TERM, TERNEO у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                case "Щитки, бокси (метал, пластик)": keyWords = "Купити дешево електричні розподільні щити, щитки, (ЩО, ЯУР), монтажні бокси, БМ, коробки, металічні, пластикові, зовнішні, внутрішні, Mutlusan (Мутлусан), Bilmax (Білмакс) у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
                default: keyWords = "Купити дешево: Кабель (ВВГ, ВВГП, ШВВП, ПВС, ГОСТ Одеса), Теплу підлогу (IN-TERM, GRAYHOT, FENIX, Hi Heat), Терморегулятори, Щитки та Бокси (Mutlusan, Bilmax), LED Освітлення, Диф. автомати та ПЗВ (Schrack, Schneider), Кабеленесучі системи у Львові та по всій Україні. Діють знижки до -10%!. Доставка по Львову БЕЗКОШТОВНА!";
                    break;
            }

            return keyWords;

        }
    }
}