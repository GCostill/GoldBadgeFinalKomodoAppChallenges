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
        private readonly List<ClaimsPOCO> _claimsRepo = new List<ClaimsPOCO>();

        public bool CreateNewClaim(ClaimsPOCO claims)
        {
            if(claims != null)
            {
                _claimsRepo.Add(claims);
                return true;
            }
            return false;
        }

        public List<ClaimsPOCO> DisplayAllClaims()
        {
            return _claimsRepo;
        }

        //view next claim in queue
    }
}
