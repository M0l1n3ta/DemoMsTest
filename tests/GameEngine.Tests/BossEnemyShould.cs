
using NUnit.Framework.Legacy;


namespace GameEngine.Tests;

[TestClass]
public class BossEnemyShould{

[TestMethod]
public void HaveCorrectSpecialAttackPower()
{
    var sut  = new BossEnemy( );

    ClassicAssert.AreEqual( 166.6, sut.SpecialAtackPower,0.07);
}

}