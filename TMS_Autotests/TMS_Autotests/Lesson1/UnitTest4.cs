namespace TMS_Autotests.Lesson1
{
    public class Division
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Retry(2)]
        [Test, Description("Test with range and values")]
        [Category("Division")]
        public void CheckDivision1(
            [Range(1, 10)] double num1,
            [Values(1, 2, 3)] double num2
            )
        {
            double result = 3;

            var actualResult = calculator.Division(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [Test, Description("Test with random")]
        public void CheckDivision2(
            [Random(1, 10, 2)] double num1,
            [Random(1, 10, 2)] double num2
            )
        {
            double result = 5;

            var actualResult = calculator.Division(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [TestCase(6, 3, 2), Description("Test with testCases")]
        [TestCase(6, 3, 3)]
        public void CheckDivision3(double num1, double num2, double result)
        {

            var actualResult = calculator.Division(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("The end.");
        }
    }
}