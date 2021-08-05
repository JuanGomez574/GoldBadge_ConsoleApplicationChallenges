using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //Create 
        public void AddBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
        }
        //Read 
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }
        //Create
        public bool AddDoorToDoorValueOfSpecificBadge(string doorName, int badgeID)
        {
            List<string> doors = GetDoorsByBadgeID(badgeID);

            if (doors == null)
            {
                return false;
            }
            int initialCount = doors.Count;
            doors.Add(doorName);

            if (initialCount < doors.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete 
        public bool DeleteDoorOnBadge(string doorName, int badgeID)
        {
            List<string> doors = GetDoorsByBadgeID(badgeID);

            if (doors == null)
            {
                return false;
            }

            int initialCount = doors.Count;
            doors.Remove(doorName);

            if (initialCount > doors.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method 
        public List<string> GetDoorsByBadgeID(int badgeID)
        {
            foreach (var kvp in _badgeDictionary)
            {
                if (kvp.Key == badgeID)
                {
                    return kvp.Value;

                }
            }
            return null;

        }
        //public string RemoveDoorFromBadge(string doorName)
        //{
        //    foreach (var door in _badgeDictionary.Values)
        //    {
        //        if (door.Contains(doorName))
        //        {
        //            door.Remove(doorName);

        //        }
        //    }
        //    return null;

        //}

    }
}
