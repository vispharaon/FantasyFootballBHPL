using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SessionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SessionService.svc or SessionService.svc.cs at the Solution Explorer and start debugging.
    public class SessionService : ISessionService
    {

        public bool Login(String user, String password)
        {
            return true;
        }

        public bool Logout(String user)
        {
            return true;
        }
    }
}
