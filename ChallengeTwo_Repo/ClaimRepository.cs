using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repo
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        
        //create

        //read
        public Queue<Claim> GetClaimDirectory()
        {
            return _claimQueue;
        }
        public void DealWithNextClaim()
        {
            _claimQueue.Dequeue();
        }
    }
}
