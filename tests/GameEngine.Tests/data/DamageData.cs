namespace GameEngine.Tests.Data;


public class DamageData
{
    public static IEnumerable<object[]> GetDamages()
    {
        return new List<object[]>
        {
            new object[] { 1,99},
            new object[] { 0 ,100},
            new object[] { 100,1},
            new object[] { 200,1},
        };
    }
}