namespace GameEngine;

public class Enemyfactory{

public Enemy Create(string? name, bool isBoos = false)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (isBoos)
        {
            if(!IsValidBossName(name))
            {
                throw new EnemyCreationexception($"{name} is not vlaid name for a Boss Enemy. Boss enemy name should end with King or Queen",name);
            }
            return new BossEnemy { Name = name };
        }
        return new NormalEnemy { Name = name };
    }

    private bool IsValidBossName(string name) => name.EndsWith("King") || 
                                                                                name.EndsWith("Queen");
}