//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior w2;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.w1 = new Warrior("Pesho", 5, 50);
            this.w2 = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void ContructorShouldInitializeCollection()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldAddWarriorToArena()
        {
            this.arena.Enroll(w1);

            Assert.That(this.arena.Warriors, Has.Member(this.w1));
        }

        [Test]
        public void EnrollShouldIncreaseArenaCount()
        {
            this.arena.Enroll(w1);
            this.arena.Enroll(w2);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void EnrollSameWariorShouldThrowException()
        {
            this.arena.Enroll(w1);

            Assert
                .Throws<InvalidOperationException>(() => this.arena.Enroll(w1));
        }

        [Test]
        public void EnrollTwoWariorsWithSameNamesShouldThrowException()
        {
            this.arena.Enroll(w1);

            Assert
                .Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(w1.Name, 5, 70)));
        }

        [Test]
        public void FightShouldThrowExceptionIfWarriorsDontExist()
        {
            this.arena.Enroll(w1);

            Assert
                .Throws<InvalidOperationException>(() => this.arena.Fight(w1.Name, w2.Name));
        }

        [Test]
        public void FightShouldThrowExceptionIfEnemyDontExist()
        {
            this.arena.Enroll(w1);

            Assert
                .Throws<InvalidOperationException>(() => this.arena.Fight(w2.Name, w1.Name));
        }

        [Test]
        public void MethodFightShouldAffectTheTwoExistingWarriors()
        {
            this.arena.Enroll(w1);
            this.arena.Enroll(w2);

            int expectedw1HP = this.w1.HP - this.w2.Damage;
            int expectedw2HP = this.w2.HP - this.w1.Damage;

            this.arena.Fight(w1.Name, w2.Name);

            Assert.AreEqual(expectedw1HP, this.w1.HP);
            Assert.AreEqual(expectedw2HP, this.w2.HP);
        }
    }
}
