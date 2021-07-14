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
        private readonly Queue<ClaimsPOCO> _claimsRepo = new Queue<ClaimsPOCO>();

        public bool CreateNewClaim(ClaimsPOCO claims)
        {
            if(claims != null)
            {
                _claimsRepo.Enqueue(claims);
                return true;
            }
            return false;
        }
        public bool RemoveClaimFromQueue(ClaimsPOCO claims)
        {
            if(claims != null)
            {
                _claimsRepo.Dequeue();
                return true;
            }
            return false;
        }
        public Queue<ClaimsPOCO> DisplayAllClaims()
        {
            return _claimsRepo;
        }

        public ClaimsPOCO ViewNextClaim()
        {
            return _claimsRepo.Peek();
        }
    }
}
