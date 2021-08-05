using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
        // Method that runs/starts the application
        public void Run()
        {
            SeedClaimsQueue();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // View All Claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        // Take Care Of Next Claim
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        // Create A New Claim
                        CreateNewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //View current claims
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimsQueue = _claimRepo.GetClaimsQueue();

            Console.WriteLine($"{"ClaimID",-10}{"Type",-13}{"Description",-27}{"Amount",-12}{"DateOfAccident",-20}{"DateOfClaim",-16}{"IsValid",-9}");
            foreach (Claim claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID,-10}{claim.TypeOfClaim,-13}{claim.Description,-27}{claim.ClaimAmount.ToString("C"),-12}{claim.DateOfIncident.ToShortDateString(),-20}{claim.DateOfClaim.ToShortDateString(),-16}{claim.IsValid,-9}");

            }
        }
        //Take care of next claim
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            // Get the next claim in the queue
            Claim nextClaim = _claimRepo.SeeNextClaimInQueue();
            // Then display that claim so that it can be handled
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: {nextClaim.ClaimAmount}\n" +
                $"DateOfAccident: {nextClaim.DateOfIncident}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                $"IsValid: {nextClaim.IsValid}");
            Console.WriteLine("\nDo you want to deal with claim now(y/n)?");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                bool wasRemovedFromQueue = _claimRepo.RemoveClaimFromQueue();

                if (wasRemovedFromQueue)
                {
                    Console.WriteLine("The claim was removed from the queue.");
                }
                else
                {
                    Console.WriteLine("The claim could not be removed from the queue.");
                }
            }
            else if (answer == "n")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
            }
        }
        //Create a new claim
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //ID
            Console.WriteLine("Enter the ID of the claim:");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            //Type
            Console.WriteLine("Enter the claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;
            //Description
            Console.WriteLine("Enter a description for the claim:");
            newClaim.Description = Console.ReadLine();
            //Amount of Damage
            Console.WriteLine("Enter the amount of the claim:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            //Date of Accident
            Console.WriteLine("Enter the month of the accident: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day of the accident: ");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the year of the accident: ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);
            newClaim.DateOfClaim = inputtedDate;
            //Date of Claim
            Console.WriteLine("Enter the month the claim was filed: ");
            int monthOfClaim = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day the claim was filed: ");
            int dayOfClaim = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the year the claim was filed: ");
            int yearOfClaim = int.Parse(Console.ReadLine());

            DateTime dateOfClaim = new DateTime(yearOfClaim, monthOfClaim, dayOfClaim);
            newClaim.DateOfClaim = dateOfClaim;
            //Is Claim Valid?
            Console.WriteLine("Is the claim valid? (y/n)");
            string validClaimString = Console.ReadLine().ToLower();

            if (validClaimString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newClaim);
        }
        //Seed method
        private void SeedClaimsQueue()
        {
            // Create a new claim object
            Claim firstClaim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            // Create another claim object
            Claim secondClaim = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            // Create another claim object
            Claim thirdClaim = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            //Commented out code below unneccessary because the queue is in the repo so don't need to create new queue of claims.
            // Create a new queue and then add all the claims created above to the queue
            //Queue<Claim> queue = new Queue<Claim>();
            //queue.Enqueue(firstClaim);
            //queue.Enqueue(secondClaim);
            //queue.Enqueue(thirdClaim);

            _claimRepo.AddClaimToQueue(firstClaim);
            _claimRepo.AddClaimToQueue(secondClaim);
            _claimRepo.AddClaimToQueue(thirdClaim);
        }
    }

}
