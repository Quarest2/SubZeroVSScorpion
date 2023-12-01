namespace BattleMages;

public class IceMage : Mage
{
    public IceMage(string name, int health, int damage) : base(name, health, damage){}
  
    public void Attack(Mage target)
    {
        Random rnd = new Random();
        int randmg = rnd.Next(_damage - 3, _damage + 4);
        if (_state == 0)
        {
            Console.WriteLine($"Mage {_name} can not attack.", _name);
        }

        if (_state == 1)
        {
            Console.WriteLine($"Mage {_name} is attacking the mage {target._name}.");
            target.GetAttack(randmg, 0);
        }
        
        if (_state == 2)
        {
            Console.WriteLine($"Mage {_name} burns, but he is attacking the mage {target._name} anyway.");
            target.GetAttack(randmg/2, 0);
        }
    }
}
