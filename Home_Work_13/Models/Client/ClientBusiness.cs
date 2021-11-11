using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Client
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    internal class ClientBusiness : ClientAbstract
    {
        public override string Status => "Юридическое лицо";
        public override decimal DepositRate => 0.15M;

        public ClientBusiness(string fname, string lname, int cliAge, decimal acc = 0, decimal deposAcc = 0) :
            base(fname, lname, cliAge, acc, deposAcc)
        { }

        public ClientBusiness() : base() { }
    }
}
