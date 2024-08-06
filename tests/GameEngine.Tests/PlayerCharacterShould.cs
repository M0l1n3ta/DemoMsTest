

using NUnit.Framework;
using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.Legacy.CollectionAssert;
using msAssert =  Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using StringAssert = NUnit.Framework.Legacy.StringAssert;

namespace GameEngine.Tests;

[TestClass]
[TestCategory("Integration")]
public class PlayerCharacterShould
{
    [TestMethod]
    [TestCategory("Player Default")]
   //[Ignore("Test no implementado")]
    public void BeInexperienceWhenNew()
    {
        var sut = new PlayerCharacter();
        ClassicAssert.IsTrue(sut.isNoob);
    }


    [TestMethod]
    public void NoHaveNickNameByDefault()
    {
         var sut = new PlayerCharacter();
         ClassicAssert.IsNull(sut.NickName);

    }    

    [TestMethod]
    public void StartWithDefaultHealth()
    {
        var sut = new PlayerCharacter();
        ClassicAssert.AreEqual(100, sut.Health);
        Assert.That(sut.Health, Is.EqualTo(100));
    }

    [TestMethod]
    [DataRow(1,99)]
    [DataRow(200,1)]
    public void TakeDamage(int damage,int expectedHealth){
        var sut = new PlayerCharacter();
        sut.TakeDamage(damage);

        Assert.That(sut.Health,Is.EqualTo(expectedHealth));
    }

    public static IEnumerable<object[]> Damages
    {
        get
        {
            return new List<object[]>
            {
                new object[] { 1, 99},
                new object[] { 0, 100},
                new object[] { 200,1}
            };
        }
    }
    [TestMethod]
    [DynamicData(nameof(Damages))]
    public void TakeDamageTDDStatic(int damage,int expectedHealth){
        var sut = new PlayerCharacter();
        sut.TakeDamage(damage);

        Assert.That(sut.Health,Is.EqualTo(expectedHealth));
    }

    [TestMethod]
    [DynamicData(nameof(Data.DamageData.GetDamages), typeof(Data.DamageData),DynamicDataSourceType.Method)]
    public void TakeDamageTDDStaticList(int damage,int expectedHealth){
        var sut = new PlayerCharacter();
        sut.TakeDamage(damage);

        Assert.That(sut.Health,Is.EqualTo(expectedHealth));
    }

    [TestMethod]
    public void IncreaseHealthAfterSleeping(){
        var sut = new PlayerCharacter();
        sut.Sleep();
        ClassicAssert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
    }

    [TestMethod]
    public void CalculateFullName()
    {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            msAssert.AreEqual("sarah smith", sut.FullName,true);
            StringAssert.AreEqualIgnoringCase("sarah smith", sut.FullName);
    }

    [TestMethod]
    public void CalculateFullNameTitleCase()
    {
        var sut = new PlayerCharacter();

        sut.FirstName = "Sarah";
        sut.LastName = "Smith";

        StringAssert.IsMatch("^Sarah",sut.FullName);
    }

    [TestMethod]
    public void HaveLongBow()
    {
        var sut = new PlayerCharacter();

        Assert.That(sut.Weapons.Any(x => x == "Long Bow"));
    }


    [TestMethod]
    public void NotHaveAStaffOfWonder()
    {
        var sut = new PlayerCharacter();

        Assert.That(!sut.Weapons.Any(x => x == "Staff of Wonder"));
    }

    [TestMethod]
    public void HaveAllexpectedWeapons()
    {
        var sut = new PlayerCharacter();

        var expectedWeapons = new List<string>{
            "Long Bow",
            "Short Bow",
            "Short Sword"
        };

        CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);
        Assert.That(sut.Weapons,Is.EqualTo(expectedWeapons));
    }

    [TestMethod]
    public void HaveNoDuplicateWeapons()
    {
        var sut = new PlayerCharacter();
        CollectionAssert.AllItemsAreUnique(sut.Weapons);
        Assert.That(sut.Weapons,Is.Unique);
    }
}