using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    public interface IRestConnection
    {
        string RestEndpoint { get; set; }
    }
}
