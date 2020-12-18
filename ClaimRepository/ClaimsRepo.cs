using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimsRepo
    {
        private Queue<Claims> _listOfClaims = new Queue<Claims>();
        
        //C
        public bool AddNewClaim(Claims newClaim)
        {
            _listOfClaims.Enqueue(newClaim);

            if (newClaim != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //R
        public Queue<Claims> GetClaimsList()
        {
            return _listOfClaims;
        }
        //U

        //D

        //helper method
       
    }
}
