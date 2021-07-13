using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClass.POCO
{
    public enum ClaimType
    {
        car = 1,
        home,
        theft
    }
    public class ClaimsPOCO
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsClaimValid { get; set; }

        public ClaimsPOCO() { }

        public ClaimsPOCO(int claimID, ClaimType claimType, string claimDescription, int claimAmount, DateTime dateOfIncicent, DateTime dateofClaim, bool isClaimValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncicent;
            DateOfClaim = dateofClaim;
            IsClaimValid = isClaimValid;
        }
    }
}

