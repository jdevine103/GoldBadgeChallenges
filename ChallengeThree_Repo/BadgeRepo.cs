using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repo
{
    public class BadgeRepo
    {
        //create Dictionary of badges 
        private readonly Dictionary<int, Badge> _badgeDict = new Dictionary<int, Badge>();

        public Dictionary<int, Badge> GetDict()
        {
            return _badgeDict;
        } 
        public void AddNewBadgeToDict(Badge newBadge)
        {
            if (!_badgeDict.ContainsKey(newBadge.ID))
            {
            _badgeDict.Add(newBadge.ID, newBadge);
            }
        }
        public Badge GetBadgeById(int id)
        {
            return _badgeDict[id];
        }
        public void RemoveDoor(Badge badge, string door) //is there a better way to utilized Dictionaires?
        {
            badge.Doors.Remove(door);
        }
        public void AddDoor(Badge badge, string door) //is there a better way to utilized Dictionaires?
        {
            badge.Doors.Add(door);
        }
        public void DeleteAllDoors(int id)
        {
            List<string> emptyList = new List<string>(); //.RemoveAll did not work
            _badgeDict[id].Doors = emptyList;
        }
    }
}
