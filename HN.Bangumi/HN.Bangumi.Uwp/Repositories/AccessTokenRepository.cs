using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace HN.Bangumi.Uwp.Repositories
{
    public class AccessTokenRepository
    {
        public void Get()
        {
            var passwordVault = new PasswordVault();
            passwordVault.Add(new PasswordCredential("xx", "accesstoken" , "refreshtoken"){});

        }
    }
}
