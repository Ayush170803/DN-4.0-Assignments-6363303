namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calc;

        [SetUp]
        public void Setup()
        {
            calc=new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calc.AllClear();
        }

        [Test]
        [TestCase(5,3,8)]
        [TestCase(10,-5,5)]
        [TestCase(2,3,5)]
        [TestCase(-1,-2,-3)]
        [TestCase(3,1,4)]
        [TestCase(991,9,1000)]
        public void Test_Addition(double a,double b,double expected)
        {
            double result=calc.Addition(a,b);
            Assert.That(result,Is.EqualTo(expected));
        }
    }
}
