namespace hw6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Valera", 120, 30);
            Mage mage = new Mage("Grisha", 100, 50, 40);

            while (warrior.health > 0 && mage.health > 0)
            {
                warrior.attack(mage, mage.name);
                Console.WriteLine("\n");
                mage.attack(warrior, warrior.name);
                Console.WriteLine("\n");
            }
            Console.WriteLine("GAME OVER");
        }

        interface Attackable
        {
            void takeDamage(int damage);

            Boolean isAlive();
        }

        interface Attacker
        {
            void attack(Attackable target, string name);
        }

        class Warrior : Attackable, Attacker
        {
            public string name;
            public int health;
            public int strengh;

            public Warrior(string name, int health, int strengh)
            {
                this.name = name;
                this.health = health;
                this.strengh = strengh;
            }

            public void takeDamage(int damage)
            {
                if (health > 0)
                {
                    health -= damage;
                    if (health <= 0)
                    {
                        Console.WriteLine($"{this.name} is dead");
                    }
                    else
                    {
                        Console.WriteLine($"{this.name} is survived");
                    }
                }
            }

            public void attack(Attackable target, string name)
            {
                if (health > 0)
                {
                    Console.WriteLine($"{this.name} attacking {name}!\nGiving {strengh} damage from hit");
                    target.takeDamage(strengh);
                }
                else
                {
                    Console.WriteLine($"{this.name} is dead and can't attack");
                    return;
                }
            }

            public bool isAlive()
            {
                if(health <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        class Mage : Attackable, Attacker
        {
            public string name;
            public int health;
            public int mana;
            public int spellPower;

            public Mage(string name, int health, int mana, int spellPower)
            {
                this.name = name;
                this.health = health;
                this.mana = mana;
                this.spellPower = spellPower;
            }

            public void takeDamage(int damage)
            {
                health -= damage;
                if (health <= 0)
                {
                    Console.WriteLine($"{this.name} is dead");
                }
                else
                {
                    Console.WriteLine($"{this.name} is survived");
                }
            }

            public void attack(Attackable target, string name)
            {
                if(mana >= 10 && health > 0)
                {
                    Console.WriteLine($"{this.name} attacking {name}!\nGiving {spellPower} damage from spell");
                    target.takeDamage(spellPower);
                    mana -= 10;
                }
                else if(mana < 10 && health > 0)
                {
                    target.takeDamage(1);
                    Console.WriteLine($"{this.name} is tired and giving 1 damage from spell to {target}");
                }
                else
                {
                    Console.WriteLine($"{this.name} is dead and can't attack");
                    return;
                }
            }

            public bool isAlive()
            {
                if (health <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
