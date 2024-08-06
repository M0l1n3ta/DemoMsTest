
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;

namespace GameEngine.Tests;
[TestClass]
[TestCategory("QA")]
public class EnemyFactoryShould()
{
    [TestMethod]
  
    public void NotAllowNullName()
    {
        Console.WriteLine("Creating EnemyFactory");
        var sut = new Enemyfactory();

        Assert.Throws<ArgumentNullException>(
            () => sut.Create(null)
        );
    }

    [TestMethod]
    public void OnlyAllowKingOrQueenBossEnemies()
    {
        var sut = new Enemyfactory();

        EnemyCreationexception? ex = Assert.Throws<EnemyCreationexception>(
            () => sut.Create("Enemigo 1", true)
        );

        Assert.That(ex?.RequestedEnemyName, Is.EqualTo("Enemigo 1"));
    }

    [TestMethod]
    public void BossEnemyNameIsOK()
    {
        var sut = new Enemyfactory();
        var boss = sut.Create("Zombie King", true);

        Assert.That(boss.Name, Is.EqualTo("Zombie King"));
        ClassicAssert.IsInstanceOf<BossEnemy>(boss);
    }

      [TestMethod]
    public void CreateNormalEnemyByDefault()
    {
          var sut = new Enemyfactory();
          var enemy = sut.Create("Zombie");

          ClassicAssert.IsInstanceOf<NormalEnemy>(enemy);
          Assert.That(enemy, Is.InstanceOf<NormalEnemy>());
    }
}