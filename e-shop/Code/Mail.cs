using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace e_shop.Code
{
    public static class Mail
    {
        public static void Send(Order order)
        {
            var fromAddress = new MailAddress("shop@elektrokonyk.com.ua", "ELEKTROKONYK"); //mail, Опис відправника
            var toAddress = new MailAddress("yurij.muzyka@gmail.com", "Юрій Музика");
            string Login = "u86073";
            string Password = "3c88aa0d";
            string subject = "[ЕЛЕКТРОКОНИК] - Новe замовлення № " + order.OrderID.ToString(); //Тема листа
            string body = Body(order); //Тіло листа
            var smtp = new SmtpClient
            {
                Host = "smtp-5.1gb.ua",
                Credentials = new NetworkCredential(Login, Password)
            };

            var message = new MailMessage(fromAddress, toAddress);
            message.To.Add(new MailAddress("oleksandrkonyk @ukr.net", "Олександр Коник"));

            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            try
            {
                //smtp.SendAsync(message,"");
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                 
            }
        }

        private static string Body(Order o)
        {
            string s = "";

            foreach (var a in o.OrderLines)
            {
                s = s + "<tr><td>" + a.Name + "</td><td>" + a.Quantity + "</td><td>" + a.ComputeTotalValue + @"</td></tr>";
            };

            string b = string.Format
            (
                @"<body>
                    <table border='1' cellpadding='5' cellspacing='5'>
                        <tr>
                            <td>Клієнт:</td>
                            <td>" + o.UserName + @"</td>
                        </tr>
                        <tr>
                            <td>Телефон:</td>
                            <td>" + o.UserPhone + @"</td>
                        </tr>
                        <tr>
                            <table>
                                <th>Товар</th>
                                <th>Кількість</th>
                                <th>Ціна</th>" + s +
                            @"</table>
                        </tr>
                        <tr>
                            <td colspan='2'>" + o.Suma + @"<td>
                        </tr>
                    </table>
                </body>"
              );

            return b;
        }
    }
}