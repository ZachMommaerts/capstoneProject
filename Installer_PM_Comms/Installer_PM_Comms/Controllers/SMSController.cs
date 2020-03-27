using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Installer_PM_Comms.Controllers
{
    public class SMSController : Controller
    {
        public ActionResult sendSMS()
        {
            const string accountSid = "AC4351474b69c9ca4d0a4d09b92371ebe9";
            const string authToken = "e6d84f9edeeb67901627f1ed16edb275";

            TwilioClient.Init(accountSid, authToken);

            
            var message = MessageResource.Create(
                body: "A new job is ready to be installed.",
                from: new Twilio.Types.PhoneNumber("+16312066522"),
                to: new Twilio.Types.PhoneNumber("+12624905722")
            );

            return Content(message.Sid);
        }
    }
}