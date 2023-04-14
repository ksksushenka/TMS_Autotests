namespace TMS_Autotests.Lesson1
{
    public class Multiply
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Retry(2)]
        [TestCase(1, 3, 3), Description("Test with testCases")]
        [TestCase(1, 3, 5)]
        [Category("Multiply")]
        public void CheckMultiply(double num1, double num2, double result)
        {

            var actualResult = calculator.Multiply(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("The end.");
        }
    }
}