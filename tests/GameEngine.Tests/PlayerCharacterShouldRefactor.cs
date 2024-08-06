using NUnit.Framework;
using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.Legacy.CollectionAssert;
using msAssert =  Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using StringAssert = NUnit.Framework.Legacy.StringAssert;

namespace GameEngine.Tests;

[TestClass]
[TestCategory("Refactor")]
public class PlayerCharacterShouldRefactor
{
    PlayerCharacter sut = new PlayerCharacter();

    [TestInitialize]
    public void Setup()
    {
        sut = new PlayerCharacter
        {
            FirstName = "Sarah",
            LastName = "Smith"
        };

    }

    [TestMethod]
    [PlayerDefault]
    public void NoHaveNickNameByDefault()
    {
         ClassicAssert.IsNull(sut.NickName);
    }    

    [TestMethod]
    [PlayerDefault]
    public void StartWithDefaultHealth()
    {    
        ClassicAssert.AreEqual(100, sut.Health);
        Assert.That(sut.Health, Is.EqualTo(100));
    }

    [TestMethod]
    [DataRow(1,99)]
    [DataRow(200,1)]
    public void TakeDamage(int damage,int expectedHealth){
        
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
        
        sut.TakeDamage(damage);

        Assert.That(sut.Health,Is.EqualTo(expectedHealth));
    }

    [TestMethod]
    [DynamicData(nameof(Data.DamageData.GetDamages), typeof(Data.DamageData),DynamicDataSourceType.Method)]
    public void TakeDamageTDDStaticList(int damage,int expectedHealth){
        
        sut.TakeDamage(damage);

        Assert.That(sut.Health,Is.EqualTo(expectedHealth));
    }

    [TestMethod]
    public void IncreaseHealthAfterSleeping(){
        
        sut.Sleep();
        msAssert.That.IsInRage(sut.Health,101,200);
    }

    [TestMethod]
    public void CalculateFullName()
    {
            msAssert.AreEqual("sarah smith", sut.FullName,true);
            StringAssert.AreEqualIgnoringCase("sarah smith", sut.FullName);
    }

    [TestMethod]
    public void CalculateFullNameTitleCase()
    {
        StringAssert.IsMatch("^Sarah",sut.FullName);
    }

    [TestMethod]
    public void HaveLongBow()
    {
        Assert.That(sut.Weapons.Any(x => x == "Long Bow"));
    }

    [TestMethod]
    public void NotHaveAStaffOfWonder()
    {
        Assert.That(!sut.Weapons.Any(x => x == "Staff of Wonder"));
    }

    [TestMethod]
    public void HaveAllexpectedWeapons()
    {
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
        CollectionAssert.AllItemsAreUnique(sut.Weapons);
        Assert.That(sut.Weapons,Is.Unique);
    }
}