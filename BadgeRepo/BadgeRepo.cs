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
        private readonly List<BadgePOCO> _listOfBadges = new List<BadgePOCO>();
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        // key value pair will be Badge ID and List of Door Names
        public bool CreateNewBadge(BadgePOCO badge)
        {
            if(badge != null)
            {
                _badgeDictionary.Add(badge.BadgeID, badge.DoorList);
                _listOfBadges.Add(badge);
                return true;
            }
            return false;
        }
        public Dictionary<int, List<string>> ShowListOfBadgesAndDoorAccess()
        {
            return _badgeDictionary;
        }
        public BadgePOCO GetBadgeByID(int id)
        {
            foreach (BadgePOCO badge in _listOfBadges)
            {
                if(badge.BadgeID == id)
                {
                    return badge;
                }
            }
            return null;
        }
        public bool UpdateExistingBadge(int newID, BadgePOCO updatedDoorList)
        {
            BadgePOCO oldBadge = GetBadgeByID(newID);
            if(oldBadge == null)
            {
                return false;
            }
            oldBadge.BadgeID = newID;
            oldBadge.DoorList = updatedDoorList.DoorList;
            return true;
        }
        public bool DeleteAllDoorsFromBadge(int id)
        {
            BadgePOCO badge = GetBadgeByID(id);
            if (badge != null)
            {
                badge.DoorList.Clear();
                return true;
            }
            return false;
        }
    }
}
