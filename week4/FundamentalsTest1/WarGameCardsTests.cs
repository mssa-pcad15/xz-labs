using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fundamentals1.LearnTypes1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1.Tests
{
    [TestClass()]
    public class WarGameCardsTests
    {
        [TestMethod()]
        public void WarGameCardsInitializationTest()
        {
            WarGameCards shoe = new WarGameCards();
            Assert.IsTrue(shoe.Batches.Length == 2);
            Assert.IsTrue(shoe.Batches[0].Length == 6 * Deck.NumberOfCards);
            Assert.IsTrue(shoe.Batches[1].Length == 6 * Deck.NumberOfCards);
            Assert.AreSame(shoe.InPlayBatch, shoe.Batches[0]);
            Assert.AreSame(shoe.StandbyBatch, shoe.Batches[1]);

        }

        //[TestMethod()]
        //public void AfterDeal90PercentOfInPlayBatchSwapBatches()
        //{
        //    WarGameCards shoe = new WarGameCards();
        //    for (int i = 0; i < 0.9 * Deck.NumberOfCards * 6; i++)
        //    {
        //        _ = shoe.Deal(); //doesn't care the return value, only care about the side effect of Deal()
        //    }
        //    Assert.AreSame(shoe.InPlayBatch, shoe.Batches[1]);
        //    Assert.AreSame(shoe.StandbyBatch, shoe.Batches[0]);

        //    for (int i = 0; i < 0.9 * Deck.NumberOfCards * 6; i++)
        //    {
        //        _ = shoe.Deal(); //doesn't care the return value, only care about the side effect of Deal()
        //    }
        //    Assert.AreSame(shoe.InPlayBatch, shoe.Batches[0]);
        //    Assert.AreSame(shoe.StandbyBatch, shoe.Batches[1]);

        //}
    }
}