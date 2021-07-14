using ClaimsClass.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClass.Repo
{
    public class ClaimsRepo
    {
        //consider implementing list as well for backend storage
        private readonly Queue<ClaimsPOCO> _claimsQueue = new Queue<ClaimsPOCO>();

        public bool CreateNewClaim(ClaimsPOCO claims)
        {
            if(claims != null)
            {
                _claimsQueue.Enqueue(claims);
                return true;
            }
            return false;
        }
        public void RemoveClaimFromQueue()
            //dequeue automatically removes claim
        {
            _claimsQueue.Dequeue();
        }
        public Queue<ClaimsPOCO> DisplayAllClaims()
        {
            return _claimsQueue;
        }

        public ClaimsPOCO ViewNextClaim()
        {
            return _claimsQueue.Peek();
        }
    }
}
