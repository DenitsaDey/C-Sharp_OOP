//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Pesho", 50, 100);
        }

        [Test]
        public void ConstructorShouldInitializeWarrior()
        {
            string expectedName = "Pesho";
            int expectedDmg = 50;
            int expectedHP = 100;

            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDmg, actualDmg);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        [TestCase(null, 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase("", 50, 100)]
        [TestCase("Pesho", 0, 100)]
        [TestCase("Pesho", -50, 100)]
        [TestCase("Pesho", 50, -100)]        
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidInput
            (string name, int damage, int health)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, health));
        }

        [Test]
        [TestCase("Voin", 50, 100, "Vrag", 60, 29)]
        [TestCase("Voin", 50, 100, "Vrag", 60, 30)]
        [TestCase("Voin", 50, 29, "Vrag", 60, 100)]
        [TestCase("Voin", 50, 30, "Vrag", 60, 100)]
        public void AttackingEnemyShouldThrowExceptionWhenWarriorOrEnemyHealthBellow30(string warriorName, int warriorDmg, int warriorHp, string enemyName, int enemyDmg, int enemyHP)
        {
            Warrior warrior = new Warrior(warriorName, warriorDmg, warriorHp);
            Warrior enemy = new Warrior(enemyName, enemyDmg, enemyHP);

            Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void AttackingEnemyWithBiggerDamageThanWarriorHealthShouldThrowException()
        {
            Warrior enemy = new Warrior("Vrag", 101, 100);

            Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void AttackingEnemyShouldDecreaseTheWarriorHealth()
        {
            Warrior enemy = new Warrior("Vrag", 90, 100);
            int expectedWarriorHP = 10;

            warrior.Attack(enemy);

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            
        }

        [Test]
        public void AttackingEnemyShouldDecreaseTheEnemyHealthWhenDamageIsBigger()
        {

            Warrior enemy = new Warrior("Vrag", 30, 40);
            int expectedEnemyHP = 0;

            warrior.Attack(enemy);

            Assert.AreEqual(expectedEnemyHP, enemy.HP);
        }

        [Test]
        public void AttackingEnemyShouldDecreaseTheWarriorHealthWhenDamageIsSmaller()
        {
            Warrior enemy = new Warrior("Vrag", 90, 100);
            int expectedEnemyHP = 50;
            
            warrior.Attack(enemy);

            Assert.AreEqual(expectedEnemyHP, enemy.HP);
            

        }

    }
}