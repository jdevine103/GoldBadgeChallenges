using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repo
{

    public class Badge
    {
        //consructors 
        public Badge(int id, List<string> accessList)
        {
            ID = id;
            Doors = accessList;
        }
        public int ID { get; set; }
        public List<string> Doors { get; set; }
        public string Name { get; set; } 

    }
}
