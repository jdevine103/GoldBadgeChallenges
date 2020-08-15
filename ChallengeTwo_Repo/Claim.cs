using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repo
{
    class Claim
    {
        public Claim(int claimId, ClaimType type, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimId = claimId;
            Type = type;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }

        public int ClaimId { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        { 
            get
            {
                TimeSpan difference = DateOfClaim.Subtract(DateOfIncident);

                if (difference.TotalDays >= 30)
                {
                    return true;
                }
                else
                    return false;
            } 
        }


        public enum ClaimType
        {
            Car, Home, Theft
        }
    }
}
