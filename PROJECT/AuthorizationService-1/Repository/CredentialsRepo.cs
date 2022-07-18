using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public class CredentialsRepo: ICredentialsRepo
    {
        private Dictionary<string, string> ValidUsersDictionary = new Dictionary<string, string>()
        {
               {"jayanth","12345"},
               {"juhi","12345"},
               {"saloni","12345"},
               {"david","12345"}
        };
        public Dictionary<string,string> GetCredentials()
        {
            return ValidUsersDictionary;
        }
    }
}
