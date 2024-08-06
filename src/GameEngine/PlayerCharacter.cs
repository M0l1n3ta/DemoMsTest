using System.ComponentModel;

namespace GameEngine;

public class PlayerCharacter : INotifyPropertyChanged
{
    private int _health = 100;

    public string FirstName { get; set; }
    public string LastName { get; set;}
    public string FullName => $"{FirstName} {LastName}";

    public string? NickName  { get; set; }

    public int Health { 
        get { return _health;}
        set { 
            _health = value; 

            }
    }

    public bool isNoob  {get; set;}

    public List<string> Weapons { get; set; } = new List<string>();

    public event EventHandler<EventArgs>? PlayerSleep;
    public event PropertyChangedEventHandler? PropertyChanged;

    public PlayerCharacter()
    {
        FirstName = GenerateRamdomFirstName();
        LastName = "";
        isNoob = true;
        CreateStartingWeapons();

    }

    private void CreateStartingWeapons()
    {
        Weapons.AddRange(["Long Bow","Short Bow","Short Sword"]);
    }

    private string GenerateRamdomFirstName()
    {
       return "Pepe";
    }

    public void Sleep()
    {
        var healIncrease = CaclulateHealtIncrease();
        Health += healIncrease;

        OnPLayerSlept(EventArgs.Empty);

    }

    private int CaclulateHealtIncrease()
    {
        var rnd = new Random();
        return rnd.Next(1, 101);
    }

    protected virtual void OnPLayerSlept(EventArgs e){
        PlayerSleep?.Invoke(this, e);
    }

    public void TakeDamage(int damage){
        Health = Math.Max(1,Health -= damage);
    }
}