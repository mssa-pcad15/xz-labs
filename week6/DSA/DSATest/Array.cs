


namespace DSATest
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void DeclareSingleDimensionArray()
        {
            int[] array = new int[5];
            Assert.AreEqual(5, array.Length);

            int[] array2 = new int[5];
            Assert.AreEqual(5, array2.Length);
        }

        [TestMethod]
        public void DeclareMultiDimensionArray()
        {
            int[,] multiArray = new int[3, 2];
            Assert.AreEqual(6, multiArray.Length);
            Assert.AreEqual(3, multiArray.GetLength(0));
            Assert.AreEqual(2, multiArray.GetLength(1));
        }

        [TestMethod]
        public void InitializeMultiDimensionArrayWithInitializer()
        {
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } }; //array initializer
            Assert.AreEqual(6, multiDimensionalArray2.Length);
            Assert.AreEqual(2, multiDimensionalArray2.GetLength(0));
            Assert.AreEqual(3, multiDimensionalArray2.GetLength(1));
            Assert.AreEqual(2, multiDimensionalArray2.Rank);
        }

        [TestMethod]
        public void MultiDimensionChallenge()
        {
            int[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 } }; //array initializer
            int[,] array2 = { { 1, 2, 3 }, { 4, 5, 6 } }; //array initializer
            //Assert.AreEqual(array1, array2);
            Assert.ArrayEqual(array1, array2);
            //how do we write an extension method to Assert class?
            //How do we compare 2 array based on members
        }
















    }
}
