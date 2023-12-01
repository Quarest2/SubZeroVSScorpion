using BattleMages;

IceMage SubZero = new IceMage("SubZero", 100, 10);
FireMage Scorpion = new FireMage("Scorpion", 100, 15);

while (SubZero._health > 0 && Scorpion._health > 0)
{
    Scorpion.Attack(SubZero);
    if (SubZero._health > 0)
    {
        SubZero.Attack(Scorpion);
    }
}
