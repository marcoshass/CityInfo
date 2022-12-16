using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Cqrs.Command
{
    public class CommandError
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        public CommandError()
        { }

        public CommandError(string code, string description)
        {
            ErrorCode = code;
            ErrorDescription = description;
        }
    }
}
