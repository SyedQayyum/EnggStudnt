using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Net.Mail;

namespace ES.Biz.Implementation
{
    public class CommonBizManager : ICommonBizManager
    {

        private readonly ICommonDataManager _commonDataManager;

        public CommonBizManager()
        {
        }

        public CommonBizManager(ICommonDataManager commonDataManager)
        {
            _commonDataManager = commonDataManager;
            AppHelper.CreateMap<KeyValueVO, KeyValue>();
        }
        public List<KeyValueVO> GetAllCities()
        {
            return Mapper.Map<List<KeyValue>, List<KeyValueVO>>(_commonDataManager.GetAllCities());
        }

        public string BuildXmlString(string xmlRootName, string xmlLeafName, string[] values)
        {
            StringBuilder xmlString = new StringBuilder();

            xmlString.AppendFormat("<{0}>", xmlRootName);
            for (int i = 0; i < values.Length; i++)
            {
                if (!string.IsNullOrEmpty(values[i]))
                    xmlString.AppendFormat("<" + xmlLeafName + ">{0}</" + xmlLeafName + ">", values[i]);
            }
            xmlString.AppendFormat("</{0}>", xmlRootName);

            return xmlString.ToString();
        }

        public bool SendEmailAsync(EmailVO email, SmtpClientDetailsVO smtpClientDetails)
        {
            bool status = false;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(email.From);
            foreach (string to in email.To)
            {
                mail.To.Add(new MailAddress(to));
            }

            mail.Subject = email.Subject;
            mail.Body = email.Body;

            SmtpClient smtpClient = new SmtpClient
            {
                Host = smtpClientDetails.Host,
                Port = smtpClientDetails.Port,
                EnableSsl = smtpClientDetails.EnableSsl,
                UseDefaultCredentials = smtpClientDetails.UseDefaultCredentials,
                Credentials = new System.Net.NetworkCredential(smtpClientDetails.UserName, smtpClientDetails.Password)
            };

            Object state = mail;

            //event handler for asynchronous call
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            try
            {
                smtpClient.SendAsync(mail, state);
                status = true;
            }
            catch (Exception ex)
            {
                /* exception handling code here */
            }
            return status;
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error != null)
            {
                //message.Text = "Mail sent successfully";
            }
        }
    }
}
