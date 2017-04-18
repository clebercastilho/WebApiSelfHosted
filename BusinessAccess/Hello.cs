using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionContainer;

namespace BusinessAccess
{
    public class Hello
    {
        public static Try<Notification, string> GetHelloType(int identifier)
        {
            var notification = new Notification(NotificationDelimiter.WebDelimiter);

            if (identifier <= 0)
                notification.AddError("O identificador informado é inválido.");

            if (notification.HasError)
                return notification;

            var helloPersonID = string.Format("Hello World: {0}ID!", identifier);
            return helloPersonID;
        }
    }
}
