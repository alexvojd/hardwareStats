using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace HDInfoServer
{
    class AsyncMailSender
    {

        public void SendMail(string reciever)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("lldarkheroll@yandex.ru");
            mail.To.Add(new MailAddress(reciever));
            mail.Subject = "Изменение состояния оборудования";
            //mail.Body
        }

    }
}
