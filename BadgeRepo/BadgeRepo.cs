using BadgeClass.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClass.Repo
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        // key value pair will be Badge ID and List of Door Names
        private int _count;
        public bool CreateNewBadge(Badge badge)
        {
            if(badge != null)
            {
                _count++;
                badge.BadgeID = _count;
                _badgeDictionary.Add(badge.BadgeID, badge);
                return true;
            }
            return false;
        }
        public Dictionary<int, Badge> ShowListOfBadgesAndDoorAccess()
        {
            return _badgeDictionary;
        }
        public Badge GetBadgeByID(int id)
        {
            foreach (var badge in _badgeDictionary)
            {
                if(badge.Key == id)
                {
                    return badge.Value;
                }
            }
            return null;
        }
        public bool UpdateExistingBadge(int newID, Badge updatedDoorList)
        {
            Badge oldBadge = GetBadgeByID(newID);
            if(oldBadge == null)
            {
                return false;
            }
            oldBadge.BadgeID = newID;
            oldBadge.DoorList = updatedDoorList.DoorList;
            return true;
        }
    }
}
