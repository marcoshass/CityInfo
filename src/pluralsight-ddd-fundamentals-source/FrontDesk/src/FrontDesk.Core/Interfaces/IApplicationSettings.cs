using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.Interfaces
{
    public interface IApplicationSettings
    {
        int ClinicId { get; }
        DateTimeOffset TestDate { get; }
    }
}
