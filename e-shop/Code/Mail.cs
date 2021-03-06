﻿using e_shop.Entities;
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
            var fromAddress = new MailAddress("shop@elektrokonyk.com.ua", "Електро Коник"); //mail, Опис відправника
            var toAddress = new MailAddress("yurij.muzyka@gmail.com", "Юрій Музика");
            string Login = "u86090";
            string Password = "ba78b12d";
            string subject = "Новe замовлення № " + order.OrderID.ToString() + " [Електро Коник]"; //Тема листа
            string body = Body(order); //Тіло листа
            var smtp = new SmtpClient
            {
                Host = "smtp-5.1gb.ua",
                Credentials = new NetworkCredential(Login, Password),
                //UseDefaultCredentials = true,
                //EnableSsl = true
            };

            var message = new MailMessage(fromAddress, toAddress);
            message.To.Add(new MailAddress("oleksandrkonyk@ukr.net", "Олександр Коник"));

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
                    <table>
                        <tr>
                            <td>Клієнт:</td>
                            <td>" + o.UserName + @"</td>
                        </tr>
                        <tr>
                            <td>Телефон:</td>
                            <td>" + o.UserPhone + @"</td>
                        </tr>
                        <tr>
                            <td>Місто:</td>
                            <td>" + o.City + @"</td>
                        </tr>
                        <tr>
                            <td>Адреса доставки:</td>
                            <td>" + o.DeliveryAddress + @"</td>
                        </tr>
                        <tr>
                          <td colspan='2'>
                            <table border='1' cellpadding='5' cellspacing='5'>
                                <th>Товар</th>
                                <th>Кількість</th>
                                <th>Ціна</th>" + s +
                              @"<tr>
                                   <td colspan='2'>Разом:</td>
                                   <td>" + o.Suma + @"</td>
                                </tr>
                            </table>
                          </td>
                        </tr>
                    </table>
                </body>"
              );

            return b;
        }

        public static void Send(AskClient ac)
        {
            var fromAddress = new MailAddress("shop@elektrokonyk.com.ua", "Електро Коник"); //mail, Опис відправника
            var toAddress = new MailAddress("yurij.muzyka@gmail.com", "Юрій Музика");
            string Login = "u86090";
            string Password = "ba78b12d";
            string subject = "Новe запитання № " + ac.AskClientID.ToString() + " [Електро Коник]"; //Тема листа
            string body = Body(ac); //Тіло листа
            var smtp = new SmtpClient
            {
                Host = "smtp-5.1gb.ua",
                Credentials = new NetworkCredential(Login, Password),
                //UseDefaultCredentials = true,
                //EnableSsl = true
            };

            var message = new MailMessage(fromAddress, toAddress);
            message.To.Add(new MailAddress("oleksandrkonyk@ukr.net", "Олександр Коник"));

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

        private static string Body(AskClient ac)
        {
            string b = string.Format
            (
                @"<body>
                    <table>
                        <tr>
                            <td>Клієнт:</td>
                            <td>" + ac.Name + @"</td>
                        </tr>
                        <tr>
                            <td>Телефон:</td>
                            <td>" + ac.Phone + @"</td>
                        </tr>
                        <tr>
                            <td>Тема:</td>
                            <td>" + ac.Theme + @"</td>
                        </tr>
                        <tr>
                            <td>Питання:</td>
                            <td>" + ac.Question + @"</td>
                        </tr>
                        <tr>
                            <td>Деталі:</td>
                            <td>http://elektrokonyk.com.ua/Admin?category=AskClients</td>
                        </tr>
                    </table>
                </body>"
              );

            return b;
        }
    }
}