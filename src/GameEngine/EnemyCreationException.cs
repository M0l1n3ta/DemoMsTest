namespace GameEngine;

public class EnemyCreationexception : Exception
{
    public string RequestedEnemyName { get; private set; }
    public EnemyCreationexception(string message, string enemyName) : base(message)
    {
       RequestedEnemyName = enemyName;
    }
}