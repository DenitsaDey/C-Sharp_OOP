namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class RobotsTests
    {
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("Robbie", 100);
        }

        [Test]
        public void ConstructorShouldInitializeRobot()
        {
            string expectedName = "Robbie";
            int expectedBattery = 100;
            int expectedMaximumBattery = 100;

            string actualName = robot.Name;
            int actualBattery = robot.Battery;
            int actualMaximumBattery = robot.MaximumBattery;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedBattery, actualBattery);
            Assert.AreEqual(expectedMaximumBattery, actualMaximumBattery);
        }

        [Test]
        public void RobotManagerCapacityShouldThrowExceptionWhenLessThanZero()
        {
            int capacity = -5;

            Assert
                .Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void ConstructorShouldInitializeRobotManager()
        {
            int expectedCapacity = 10;
            int expectedRobotsCount = 0;

            RobotManager robotManager = new RobotManager(10);

            Assert.AreEqual(expectedCapacity, robotManager.Capacity);
            Assert.AreEqual(expectedRobotsCount, robotManager.Count);
          
        }

        [Test]
        public void AddShouldAddARobotSuccessfully()
        {
            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(this.robot);

            Assert.AreEqual(1, robotManager.Count);

        }

        [Test]
        public void AddShouldThrowExceptionWhenARobotWithSameNameIsAdded()
        {
            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot(this.robot.Name, 50)));

        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsExceeded()
        {
            RobotManager robotManager = new RobotManager(1);

            robotManager.Add(this.robot);

            Assert
                .Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Bobbie", 50)));
        }

        [Test]
        public void RemoveShouldRemoveRobotSuccessfully()
        {
            string name = this.robot.Name;
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            robotManager.Remove(name);

            Assert.AreEqual(0, robotManager.Count);

        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRobotDoesNotExist()
        {
            string name = "Bobbie";
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);


            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(name));

        }

        [Test]
        public void WorkShouldDecreaseBatteryWithUsageAmount()
        {
            int expectedBatteryAfterUse = 70;
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            robotManager.Work("Robbie", "cook", 30);

            Assert.AreEqual(expectedBatteryAfterUse, this.robot.Battery);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotNotFound()
        {
            string robotName = "Bobbie";
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotName, "cook", 30));
        }
        [Test]
        public void WorkShouldThrowExceptionWhenBatteryUsageIsBiggerThanBattery()
        {
            int batteryUsage = 120;
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(this.robot.Name, "cook", batteryUsage));
        }

        [Test]
        public void ChargeShouldIncreaseBatteryToItsMaximum()
        {
            RobotManager robotManager = new RobotManager(1);
            this.robot.Battery = 55;
            robotManager.Add(this.robot);

            robotManager.Charge(this.robot.Name);

            Assert.AreEqual(this.robot.MaximumBattery, this.robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowExceptionWhenRobotNotFound()
        {
            string robotName = "Bobbie";
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robotName));
        }


        //[TestCase(null, 50, 100)]
    }
}
