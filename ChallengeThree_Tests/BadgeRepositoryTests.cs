using ChallengeThree_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo;
        private Badge _badge;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            List<string> doors = new List<string>();
            string firstDoor = "A1";
            string secondDoor = "A4";
            string thirdDoor = "B1";
            string fourthDoor = "B2";
            doors.Add(firstDoor);
            doors.Add(secondDoor);
            doors.Add(thirdDoor);
            doors.Add(fourthDoor);
            _badge = new Badge(32345, doors, "Developer");

            _repo.AddBadgeToDictionary(_badge);
        }
        //Create
        [TestMethod]
        public void AddBadgeToDictionary_ShouldGetNotNull()
        {
            //Arrange
            List<string> doors = new List<string>();
            string firstDoor = "A1";
            string secondDoor = "A4";
            string thirdDoor = "B1";
            string fourthDoor = "B2";
            doors.Add(firstDoor);
            doors.Add(secondDoor);
            doors.Add(thirdDoor);
            doors.Add(fourthDoor);
            Badge badge = new Badge(1111, doors, "Developer");
            BadgeRepository repository = new BadgeRepository();
            //Act
            repository.AddBadgeToDictionary(badge);
            List<string> doorsFromDictionary = repository.GetDoorsByBadgeID(1111);
            //Assert
            Assert.IsNotNull(doorsFromDictionary);

            //repository.AddBadgeToDictionary(badge);

            //Dictionary<int, List<string>> badgeDictionary = repository.GetBadgeDictionary();
            //Dictionary<int, List<string>> secondBadgeDictionary = _repo.GetBadgeDictionary();

            ////Assert
            //CollectionAssert.Equals(badgeDictionary, secondBadgeDictionary);

        }
        //Read
        [TestMethod]
        public void GetBadgeDictionary_ShouldGetNotNull()
        {
            //Arrange
            //TestInitialize

            //Act
            Dictionary<int, List<string>> badgeDictionary = _repo.GetBadgeDictionary();

            //Assert
            Assert.IsNotNull(badgeDictionary);
        }
        //Create
        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize

            //Act
            string fifthDoor = "D3";
            bool addedDoor = _repo.AddDoorToDoorValueOfSpecificBadge(fifthDoor, _badge.BadgeID);
            //Assert
            Assert.IsTrue(addedDoor);
        }
        //Delete
        [TestMethod]
        public void DeleteDoorOnBadge_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize

            //Act
            string firstDoor = "A1";
            bool deletedDoor = _repo.DeleteDoorOnBadge(firstDoor, _badge.BadgeID);

            //Assert
            Assert.IsTrue(deletedDoor);
        }
        //Helper
        [TestMethod]
        public void GetDoorsByBadgeID_ShouldGetNotNull()
        {
            //Arrange
            //TestInitialize

            //Act
            List<string> doors = _repo.GetDoorsByBadgeID(_badge.BadgeID);
            //Assert
            Assert.IsNotNull(doors);
        }
    }

}
