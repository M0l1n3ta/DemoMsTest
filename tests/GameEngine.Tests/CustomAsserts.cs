using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests;

public static class CustomAsserts
{
    public static void IsInRage(this Assert assert,
                                                int actual,
                                                int expectedMinimumValue,
                                                int expectedMaximumValue)
    {
        if(actual < expectedMinimumValue  || actual > expectedMaximumValue)
        {
            throw new AssertFailedException($"{actual} was not in the range {expectedMinimumValue}-{expectedMaximumValue}");
        }
    }
} 