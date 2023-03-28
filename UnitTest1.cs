using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;

namespace UnitTestZad1
{
    [TestClass]
    public class UnitTest1
    {
        public static void shuffle(List<Item> itemList)
        {
            Random rand = new Random();

            for (int i = itemList.Count - 1; i > 0; i--)
            {
                int k = rand.Next(i + 1);
                Item item = itemList[k];
                itemList[k] = itemList[i];
                itemList[i] = item;
            }
        }

        [TestMethod]
        public void CheckAtOneMatching()
        {
            List<Item> itemListTest = new List<Item>();
            itemListTest.Add(new Item(1, 10));


            Backpack backpack = new Backpack(itemListTest, 11);
            backpack.solveProblem();

            Assert.AreEqual(backpack.getItemOrder().Count, 1);
        }
        [TestMethod]
        public void CheckAtNoneMatching()
        {
            List<Item> itemListTest = new List<Item>();
            itemListTest.Add(new Item(1, 9));


            Backpack backpack = new Backpack(itemListTest, 10);
            backpack.solveProblem();

            Assert.AreEqual(backpack.getItemOrder().Count, 1);
        }
        [TestMethod]
        public void CheckAtShuffled()
        {
            List<Item> itemListTest1 = new List<Item>();
            itemListTest1.Add(new Item(1, 9));
            itemListTest1.Add(new Item(2, 9));
            itemListTest1.Add(new Item(3, 9));
            itemListTest1.Add(new Item(4, 9));

            Backpack backpack1 = new Backpack(itemListTest1, 20);

            backpack1.solveProblem();

            List<Item> itemListTest2 = new List<Item>();
            itemListTest2.Add(new Item(4, 9));
            itemListTest2.Add(new Item(3, 9));
            itemListTest2.Add(new Item(2, 9));
            itemListTest2.Add(new Item(1, 9));

            Backpack backpack2 = new Backpack(itemListTest2, 40);

            backpack2.solveProblem();

            for (int i = 0; i < backpack1.getItemOrder().Count; i++)
                Assert.IsTrue(backpack1.getItemOrder()[i] != backpack2.getItemOrder()[i]);
        }
        [TestMethod]
        public void CheckExactOutcome()
        {
            List<Item> itemListTest = new List<Item>();
            itemListTest.Add(new Item(1, 10));
            itemListTest.Add(new Item(2, 10));
            itemListTest.Add(new Item(3, 10));
            itemListTest.Add(new Item(4, 10));

            List<Item> itemListOutcome = new List<Item>();
            itemListOutcome.Add(new Item(1, 10));
            itemListOutcome.Add(new Item(2, 10));


            Backpack backpack = new Backpack(itemListTest, 21);

            backpack.solveProblem();

            List<Item> itemsOrder = backpack.getItemOrder();

            for (int i = 0; i < backpack.getItemOrder().Count; i++)
                Assert.IsTrue(itemListTest[i] == itemListOutcome[i], "Error");
        }

        [TestMethod]
        public void CheckIfFull()
        {
            List<Item> itemListTest = new List<Item>();
            itemListTest.Add(new Item(1, 10));
            itemListTest.Add(new Item(2, 20));
            itemListTest.Add(new Item(3, 30));
            itemListTest.Add(new Item(4, 40));

            Backpack backpack = new Backpack(itemListTest, 100);

            backpack.solveProblem();

            Assert.AreEqual(backpack.getItemOrder().Count, 4);
        }
    }
}
