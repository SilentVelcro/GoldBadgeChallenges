using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepo
{
    public class Badge
    { //POCO
        public int BadgeId { get; set; }
        public List<string> DoorAccess { get; set; }
        public Badge() { }
        public Badge(int badgeId, List<string> _doorAccess)
        {
            BadgeId = badgeId;
            DoorAccess = _doorAccess;
        }
      
    }
}
