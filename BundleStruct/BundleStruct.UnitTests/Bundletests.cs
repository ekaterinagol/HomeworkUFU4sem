using System;
using System.Reflection.Metadata;
using BundleStruct;

namespace BundleStruct.UnitTests
{
    [TestFixture]
    public class BundleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var bundle = new Bundle(10, 18);

            Assert.That(bundle.Banknote, Is.EqualTo(10));
            Assert.That(bundle.Count, Is.EqualTo(18));
        }

        [TestCase(-3)]
        [TestCase(11)]
        public void BanknoteSet_WrongNominal_ArgumentException(int val)
        {
            var bundle = new Bundle();

            Assert.That(() => bundle.Banknote = val, Throws.ArgumentException);
        }

        [TestCase(-30)]
        [TestCase(-5)]
        public void CountSet_Negative_ArgumentException(int val)
        {
            var bundle = new Bundle();

            Assert.That(() => bundle.Count = val, Throws.ArgumentException);
        }

        [TestCase(5, 20, 100)]
        [TestCase(10, 0, 0)]
        [TestCase(200, 42, 8400)]
        public void SumTest(
           int banknote, int count, int sum)
        {
            var bundle = new Bundle(banknote, count);

            Assert.That(bundle.Sum, Is.EqualTo(sum));
        }

        [TestCase(10, 42, "42 x 10 ð.")]
        [TestCase(5, 0, "0 x 5 ð.")]
        [TestCase(2000, 14, "14 x 2000 ð.")]
        public void ToStringTest(int banknote, int count, string result)
        {
            var bundle = new Bundle(banknote, count);

            Assert.That(bundle.ToString(), Is.EqualTo(result));
        }

        [TestCase(100, 100, 30, 30, true)]
        [TestCase(500, 500, 5, 6, false)]
        [TestCase(500, 1000, 8, 8, false)]
        public void Equals_TwoBundles_ExpectedResult(
            int banknote1, int banknote2, int count1, int count2, bool result)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);

            Assert.That(bundle1.Equals(bundle2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var bundle = new Bundle();
            var smth = new object();

            Assert.That(() => bundle.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public static void GetHashCodeTest()
        {
            var x = new Bundle(50, 18);
            var y = new Bundle(50, 18);
            var z = new Bundle(10, 100);

            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [Test]
        public static void ComparisonTest()
        {
            var x = new Bundle(50, 18);
            var y = new Bundle(50, 18);
            var z = new Bundle(10, 100);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(50, 20, 50, 40, 50, 60)]
        [TestCase(2, 35, 2, 55, 2, 90)]
        [TestCase(100, 0, 100, 20, 100, 20)]
        public void AdditionTest(
           int banknote1, int count1,
           int banknote2, int count2,
           int resultBanknote, int resultCount)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            var result = new Bundle(resultBanknote, resultCount);

            Assert.That(bundle1 + bundle2, Is.EqualTo(result));
        }

        [TestCase(100, 100, 50, 30)]
        [TestCase(500, 10, 5, 10)]
        [TestCase(50, 10, 2000, 8)]
        public void Addition_WrongArgument_ArgumentException(int banknote1, int count1,
           int banknote2, int count2 )
        {
            var bundle1 = new Bundle(banknote1,count1);
            var bundle2 = new Bundle(banknote2, count2);

            Assert.That(() => bundle1+bundle2, Throws.ArgumentException);
        }

        [TestCase(50, 40, 50, 20, 50, 20)]
        [TestCase(2, 79, 2, 55, 2, 24)]
        [TestCase(100, 24, 100, 0, 100, 24)]
        public void SubtractionTest(
           int banknote1, int count1,
           int banknote2, int count2,
           int resultBanknote, int resultCount)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            var result = new Bundle(resultBanknote, resultCount);

            Assert.That(bundle1 - bundle2, Is.EqualTo(result));
        }

        [TestCase(100, 100, 50, 120)]
        [TestCase(500, 10, 5, 10)]
        [TestCase(50, 3, 50, 10)]
        [TestCase(200, 24, 200, 30)]
        public void Subtraction_WrongArgument_ArgumentException(int banknote1, int count1,
           int banknote2, int count2)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);

            Assert.That(() => bundle1 - bundle2, Throws.ArgumentException);
        }
    }

}