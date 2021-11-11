using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Client
{
    /// <summary>
    /// Физическое лицо
    /// </summary>
    internal class ClientIndividual : ClientAbstract
    {
        public override string Status => "Физическое лицо";
        public override decimal DepositRate => 0.1M;

        public ClientIndividual(string fname, string lname, int cliAge, decimal acc = 0, decimal deposAcc = 0) :
               base(fname, lname, cliAge, acc, deposAcc)
        { }

        public ClientIndividual() : base() { }
    }
}
