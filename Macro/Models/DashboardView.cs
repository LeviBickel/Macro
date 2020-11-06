using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macro.Models
{
    public class DashboardView
    {
        public List<Circuit> RecentCircuit { get; set; }
        public List<DiscoCircuit> RecentDisco { get; set; }
        public List<Software> RecentSoft { get; set; }
    }
}
