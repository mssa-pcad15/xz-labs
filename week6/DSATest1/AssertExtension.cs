using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATest
{
    internal static class AssertExtension
    {
        public static void ArrayAreEqualInContent(this Assert a, Array left, Array right)
        {
            //1. check if two arrays have same dimensions
            if (left.Rank != right.Rank)
                Assert.Fail("Arrays have different dimensions");
            
            for (int i = 0; i < left.Rank; i++)
            {
                if (left.GetLength(i) != right.GetLength(i))
                    Assert.Fail($"Arrays have different number of elements at rank {i}");
                
                for (int j=0; j<left.GetLength(left.Rank-1); j++)
                {
                    if (!left.GetValue(i, j)!.Equals(right.GetValue(i, j))) //second ! is null-forgivable operator
                        Assert.Fail($"Arrays contains different elements at index {i}, {j}");
                }
            
            }
        }
    }
}
