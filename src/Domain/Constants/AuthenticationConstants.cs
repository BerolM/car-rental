using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public class AuthenticationConstants
    {
        public const string AuthenticationScheme = "Cookies";
        public class OperationClaims
        {
            public const int Admin = 1;
            public const int User = 2;

            public const string AdminStr = "1";
            public const string UserStr = "2";
        }
    }
}
