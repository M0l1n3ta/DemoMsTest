using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests;

public class PlayerDefaultAttribute : TestCategoryBaseAttribute
{
    public override IList<string> TestCategories => new[] { "Player Default" };
}