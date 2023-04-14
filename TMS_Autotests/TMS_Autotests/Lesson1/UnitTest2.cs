namespace TMS_Autotests.Lesson1
{
    public class Minus
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Retry(2)]
        [Test, Description("Test with random")]
        [Category("Minus")]
        public void CheckMinus(
            [Random(1, 10, 2)] double num1,
            [Random(1, 10, 2)] double num2
            )
        {
            double result = 3;

            var actualResult = calculator.Minus(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("The end.");
        }
    }
}