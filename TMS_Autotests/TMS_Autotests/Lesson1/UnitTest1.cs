namespace TMS_Autotests.Lesson1
{
    public class Add
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Retry(2)]
        [Test, Description("Test with range and values")]
        [Category("Add")]
        public void CheckAdd(
            [Range(1, 10)] double num1, 
            [Values(1, 2, 3)] double num2
            )
        {
            double result = 3;

            var actualResult = calculator.Add(num1, num2);

            Assert.That(result, Is.EqualTo(actualResult), $"Result Failed");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("The end.");
        }
    }
}