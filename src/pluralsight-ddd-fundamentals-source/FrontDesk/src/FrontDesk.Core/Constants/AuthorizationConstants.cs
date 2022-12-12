using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.Constants
{
    public class AuthorizationConstants
    {
        // NOTE: Use an environment variable in a production app
        public const string JWT_SECRET_KEY = "SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes";
    }
}
