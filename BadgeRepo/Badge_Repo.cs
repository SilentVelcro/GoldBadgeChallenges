using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepo
{
    public class Badge_Repo
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();
        
        //Create
        public void AddBadge(Badge badge)
        {

            _doorAccess.Add(badge.BadgeId, badge.DoorAccess);
        }

        //Read
        public Dictionary<int, List<string>> GetList()
        {
            return _doorAccess;
        }
        
        //Update
        public bool GrantAccess(int badgeId, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeId];

            int doorCount = doors.Count;
            doors.Add(doorAccess);

            if (doors.Count > doorCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveAccess(int badgeId, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeId];
            int doorCount = doors.Count;
            doors.Remove(doorAccess);

            if (doors.Count < doorCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper method
    }
}
