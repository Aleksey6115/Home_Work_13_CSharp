using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Client
{
    /// <summary>
    /// VIP клиент
    /// </summary>
    internal class ClientVIP : ClientAbstract
    {
        public override string Status => "VIP Клиент";
        public override decimal DepositRate => 0.2M;

        public ClientVIP(string fname, string lname, int cliAge, decimal acc = 0, decimal deposAcc = 0) :
               base(fname, lname, cliAge, acc, deposAcc)
        { }

        public ClientVIP() : base() { }
    }
}
