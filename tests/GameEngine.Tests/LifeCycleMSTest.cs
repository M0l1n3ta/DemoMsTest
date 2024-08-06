
namespace GameEngine.Tests;

[TestClass]
[TestCategory("LifeCycle")]
public class LifeCycleMSTest
{
    static string someTestContext = string.Empty;

    [ClassInitialize]
    public static void SetUp(TestContext context){
        Console.WriteLine("Code run before all class test init");
        Console.WriteLine("Data Loaded from disk or some expensive object creation");
        someTestContext = "42";
    }

    [TestInitialize]
    public void SetUpTest()
    {
        Console.WriteLine("     Code run before each test init");
    }

    [TestMethod]
    public void TestA()
    {
        Console.WriteLine("         Teat A strarting");
        Console.WriteLine($"        Shared test context: {someTestContext}");
    }

      [TestMethod]
    public void TestB()
    {
        Console.WriteLine("         Teat B strarting");
    }

    [TestCleanup]
    public void DisposeTest()
    {
        Console.WriteLine("     Code ran after each test has been finished");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Console.WriteLine("Code run after all class test finish");
    }

  
}