using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Repo
{
    public class OutingsRepo
    {
        private readonly List<Outing> _outingRepo = new List<Outing>();

        //create
        public void AddOuting(Outing outing)
        {
            _outingRepo.Add(outing);
        }
        //read
        public List<Outing> GetOutings()
        {
            return _outingRepo;
        }
        //update 

        //delete

    }
}
