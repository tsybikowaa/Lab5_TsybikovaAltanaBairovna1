using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5Podderzhka
{
    public class SearchResult
    {
        public string Num { get; } // он не нужен
        public string Account { get; }
        public string Type { get; }
        public string Payee { get; }
        public string Amount { get; }
        

        public SearchResult(string num, string account, string type, string payee, string amount)
        {
            Num = num;
            Account = account;
            Type = type;
            Payee = payee;
            Amount = amount;
           
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                SearchResult p = (SearchResult)obj;
                return (Account == p.Account) && (Type == p.Type) && (Payee == p.Payee) && (Amount == p.Amount);
            }
        }

    }
}
