using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class StructureJson

    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Dist { get; set; }
        public List<string> Lines { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
