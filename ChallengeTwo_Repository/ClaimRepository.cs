using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimsQueue = new Queue<Claim>();

        //Create
        public void AddClaimToQueue(Claim claim)
        {
            _claimsQueue.Enqueue(claim);
        }

        //Read
        public Queue<Claim> GetClaimsQueue()
        {
            return _claimsQueue;
        }
        //Helper method
        public Claim SeeNextClaimInQueue()
        {
            Claim nextClaim = _claimsQueue.Peek();
            return nextClaim;

        }
        //Delete 
        public bool RemoveClaimFromQueue()
        {
            //Claim nextClaim = _claimsQueue.Peek(); <=== this does same thing as next line
            Claim nextClaim = SeeNextClaimInQueue();

            if (nextClaim == null)
            {
                return false;
            }

            int initialCount = _claimsQueue.Count;
            _claimsQueue.Dequeue();


            if (initialCount > _claimsQueue.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
