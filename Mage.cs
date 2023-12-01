namespace BattleMages;

public abstract class Mage
{
    public string _name;
    public int _health;
    public int _damage;
    // 0 - mage in ice, 1 - normal state, 2 - mage in fire.
    public int _state;

    public Mage(string name, int health, int damage)
    {
        if (health <= 0 || damage <= 0)
        {
            throw new ArgumentOutOfRangeException("Parameter health or parameter damage non-positive.");
        }
        _name = name;
        _health = health;
        _damage = damage;
        _state = 1;
    }

    public void GetAttack(int harm, int attackState)
    {
        if (_health == 0)
        {
            Console.WriteLine($"Fighters decided to make fun of the corpse {_name}");
            return;
        }
        if (harm >= _health)
        {
            _health = 0;
            if (attackState == 0)
            {
                Console.WriteLine($"Mage {_name} frozen to death.");
                return;
            }

            if (attackState == 2)
            {
                Console.WriteLine($"Mage {_name} burned to the ground.");
                return;
            }

            if (attackState == 1)
            {
                Console.WriteLine($"Mage {_name} is dead.");
                return;
            }

            throw new ArgumentOutOfRangeException("Invalid parameter attackState.");
        }
        else
        {
            _health -= harm;
            if (attackState == 0)
            {
                if (_state == 2)
                {
                    _state -= 1;
                    Console.WriteLine($"Mage {_name} took {harm} damage and was extinguished. Now he has {_health} health points.");
                    return;
                }

                if (_state == 1)
                {
                    _state -= 1;
                    Console.WriteLine($"Mage {_name} took {harm} damage and was frozen. Now he has {_health} health points.");
                    return;
                }
                
                Console.WriteLine($"Mage {_name} took {harm} damage and still frozen. Now he has {_health} health points.");
                return;
            }

            if (attackState == 1)
            {
                Console.WriteLine($"Mage {_name} took {harm} damage. Now he has {_health} health points.");
                return;
            }

            if (attackState == 2)
            {
                if (_state == 0)
                {
                    _state += 1;
                    Console.WriteLine($"Mage {_name} took {harm} damage and was melted. Now he has {_health} health points.");
                    return;
                }

                if (_state == 1)
                {
                    _state += 1;
                    Console.WriteLine($"Mage {_name} took {harm} damage and was set on fire. Now he has {_health} health points.");
                    return;
                }
                
                Console.WriteLine($"Mage {_name} took {harm} damage and still burned. Now he has {_health} health points.");
                return;
            }
            
        }
    }

    public void Attack(Mage target)
    {
        Random rnd = new Random();
        int randmg = rnd.Next(_damage - 3, _damage + 4);
        if (_state == 0)
        {
            Console.WriteLine($"Mage {_name} can not attack.");
        }

        if (_state == 1)
        {
            Console.WriteLine($"Mage {_name} is attacking the mage {target._name}.");
            target.GetAttack(randmg, 1);
        }
        
        if (_state == 2)
        {
            Console.WriteLine($"Mage {_name} burns, but he is attacking the mage {target._name} anyway.");
            target.GetAttack(randmg/2, 1);
        }
    }
}
