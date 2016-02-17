using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romit
{
    public class RomitRequestOptions
    {
        public string ApiKey { get; set; }
        public string RomitConnectAccountId { get; set; }
        public string IdempotencyKey { get; set; }
    }
}
