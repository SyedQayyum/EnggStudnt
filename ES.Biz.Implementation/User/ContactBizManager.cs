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

namespace ES.Biz.Implementation
{
    public class ContactBizManager : IContactBizManager
    {
        private readonly IContactDataManager _contactDataManager;
        private readonly ICommonBizManager _commonBizManager;


        public ContactBizManager(IContactDataManager contactDataManager)
        {
            _contactDataManager = contactDataManager;
            AppHelper.CreateMap<ContactVO, Contact>();
            _commonBizManager = new CommonBizManager();
        }
        public bool ContactUs(ContactVO ObjContactVO)
        {
            bool isSend = false;
            string Subject = string.Empty;
            string Body = string.Empty;

            Subject = ObjContactVO.isAdvertise ? "Advertisement Information" : "General Information";
            Body = ObjContactVO.SenderMessage;
            SmtpClientDetailsVO objSmtpClient = new SmtpClientDetailsVO
            {
                UserName = "sqm.syed@gmail.com",
                Password = "07231242280",
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            EmailVO objEmail = new EmailVO
            {

                Body = Body,
                Subject = Subject,
                From = "sqm.syed@gmail.com",
                To = new List<string> { "sqm.syed096@gmail.com", "alka362@gmail.com", "sqm.syed@gmail.com", "sqm.syed096@yahoo.com", "kiranmai.munagapati@gmail.com" }

            };
            if (_commonBizManager.SendEmailAsync(objEmail, objSmtpClient))
            {
                isSend = true;
            }

            return isSend;
        }
    }
}
