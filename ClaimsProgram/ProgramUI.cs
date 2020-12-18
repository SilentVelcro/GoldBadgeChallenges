using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsProgram
{
    class ProgramUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeeList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims.\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit program.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //1. See all claims
        private void ViewAllClaims()
        {
            Console.Clear();

            Queue<Claims> claimList = _claimsRepo.GetClaimsList();

            Console.WriteLine($"{ "ID",-4} {"Type",-6} {"Description",-25} {"Amount",-8} {"Incident Date",-18} {"Claim Date",-18} {"IsValid",-5}");
            foreach (Claims claims in claimList)
            {
                ShowAClaim(claims);
            }
        }
        //2. Next claim - enqueue - dequeue
        private void NextClaim()
        {
            var next = _claimsRepo.GetClaimsList();
            Claims nextCase = next.Peek();

            Console.WriteLine($"Claim ID: {nextCase.ClaimId}\n" +
                $"Type: {nextCase.TypeOfClaim}\n" +
                $"Description: {nextCase.Description}\n" +
                $"Ammount: {nextCase.Description}\n" +
                $"Date of incident: {nextCase.DateOfIncident}\n" +
                $"Date of claim: {nextCase.DateOfClaim}\n" +
                $"Is valid: {nextCase.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");

            string input = Console.ReadLine();

            if (input == "y")
            {
                next.Dequeue();
            }
            else
            {
                Console.Clear();
            }
        }
        //3. New Claim
        private void NewClaim()

        {
            Console.Clear();

            Claims newClaim = new Claims();

            Console.WriteLine("Enter the Claim Type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.TypeOfClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter the new claim ID number:");
            string itemNumber = Console.ReadLine();
            newClaim.ClaimId = int.Parse(itemNumber);

            Console.WriteLine("Enter brief description of claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter amount of claim:");
            string claimAmount = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimAmount);

            Console.WriteLine("Enter the date the incident took place (yyyy/mm/dd):");
            string incidentDate = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDate);

            Console.WriteLine("Enter the date that incident was reported to claims(yyyy/mm/dd):");
            string claimDate = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDate);       

            //if the content was saved, say so 
            //otherwise state it could not be saved.
            bool wasSaved = _claimsRepo.AddNewClaim(newClaim);
            if (wasSaved)
            {
                Console.WriteLine("Content successfuly updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }

        //see method
        private void ShowAClaim(Claims claim)
        {
            Console.WriteLine($"{claim.ClaimId,-4} {claim.TypeOfClaim,-6} {claim.Description,-25} {claim.ClaimAmount,-11}{claim.DateOfIncident.ToString("MM/dd/yyyy"),-16} {claim.DateOfClaim.ToString("MM/dd/yyyy"),-20} {claim.IsValid,-4}");
        }



        public void SeeList()
        {
            Claims claimOne = new Claims(ClaimType.Home, 101, "Roof Collapse", 15000, new DateTime(2020, 10, 22), new DateTime(2020, 10, 23));
            _claimsRepo.AddNewClaim(claimOne);

            Claims claimTwo = new Claims(ClaimType.Theft, 102, "Safe Stolen", 44000, new DateTime(2020, 10, 02), new DateTime(2020, 11, 23));
            _claimsRepo.AddNewClaim(claimTwo);

            Claims claimThree = new Claims(ClaimType.Car, 103, "Totaled", 8000, new DateTime(2020, 09, 22), new DateTime(2020, 10, 15));
            _claimsRepo.AddNewClaim(claimThree);
        }
    }
}
