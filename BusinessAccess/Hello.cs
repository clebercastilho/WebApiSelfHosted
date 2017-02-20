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
        public static Try<Exception, string> GetHelloType(int identifier)
        {
            if (identifier <= 0)
                return new NotImplementedException("Ação não implementada.");

            var helloPersonID = string.Format("Hello World {0}!", identifier);
            return helloPersonID;
        }
    }
}
