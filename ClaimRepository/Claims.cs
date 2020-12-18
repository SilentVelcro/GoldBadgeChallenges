using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{   public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
        public ClaimType TypeOfClaim { get; set; }
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public int DaysBetweenIncidentAndClaim
        {
            get
            {
                TimeSpan daysBetweenDates = DateOfClaim - DateOfIncident;
                double doubleDays = Math.Floor(daysBetweenDates.TotalDays);
                int amountOfDays = Convert.ToInt32(doubleDays);
                return amountOfDays;
            }
        }
        public bool IsValid 
        {
            get 
            {
                if (DaysBetweenIncidentAndClaim <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public Claims() { }
        public Claims(ClaimType typeOfClaim, int claimId, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            TypeOfClaim = typeOfClaim;
            ClaimId = claimId;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
