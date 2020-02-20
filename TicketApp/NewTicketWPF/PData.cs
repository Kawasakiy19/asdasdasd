using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTicketWPF
{
    public class PData
    {
        PData data;

        public PData()
        {
        }

        public PData(int index, string name)
        {
            Index = index;
            PName = name;
        }

        public int Index { get; set; }

        public string PName { get; set; }
        
    }
}
