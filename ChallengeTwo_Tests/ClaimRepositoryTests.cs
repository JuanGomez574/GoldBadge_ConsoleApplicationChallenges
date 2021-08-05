using ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        private ClaimRepository _repo;
        private Claim _claim;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);

            _repo.AddClaimToQueue(_claim);
        }
        // Add Method
        [TestMethod]
        public void AddClaimToQueue_ShouldGetNotNull()
        {
            // Arrange            
            Claim newClaim = new Claim();
            newClaim.ClaimAmount = 4000.00m;
            ClaimRepository repository = new ClaimRepository();

            // Act
            repository.AddClaimToQueue(newClaim);
            Claim claimFromQueue = repository.SeeNextClaimInQueue();

            // Assert
            Assert.IsNotNull(claimFromQueue);

        }
        // Read Method
        [TestMethod]
        public void GetClaimsQueue_ShouldGetNotNull()
        {
            // Arrange 
            // TestInitialize

            // Act
            Queue<Claim> claimsQueue = _repo.GetClaimsQueue();

            // Assert
            Assert.IsNotNull(claimsQueue);
        }
        // Helper Method
        [TestMethod]
        public void SeeNextClaimInQueue_ShouldGetNotNull()
        {
            // Arrange
            // TestInitialize

            // Act
            Claim nextClaimInQueue = _repo.SeeNextClaimInQueue();

            // Assert
            Assert.IsNotNull(nextClaimInQueue);
        }
        // Delete Method
        [TestMethod]
        public void RemoveClaimFromQueue_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize

            // Act
            bool removedClaim = _repo.RemoveClaimFromQueue();

            // Assert
            Assert.IsTrue(removedClaim);
        }
    }
}
