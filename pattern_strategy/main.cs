using System;

namespace AdventureGame
{

    public interface IWeapon
    {
        void UseWeapon();
    }


    public class Sword : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Персонаж атакує мечем!");
        }
    }

    public class Staff : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Персонаж атакує магічним посохом!");
        }
    }

    public class Bow : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Персонаж стріляє з лука!");
        }
    }

    public class Dagger : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Персонаж атакує кинджалом!");
        }
    }

    public abstract class Character
    {
        protected string name;
        protected IWeapon weapon;

        public Character(string name)
        {
            this.name = name;
        }

        // Зміна стратегії (зброї)
        public void SetWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
            Console.WriteLine($"{name} змінив зброю.");
        }

        // Використання поточної зброї
        public virtual void Attack()
        {
            if (weapon != null)
            {
                Console.Write($"{name}: ");
                weapon.UseWeapon();
            }
            else
            {
                Console.WriteLine($"{name} не має зброї!");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Персонаж: {name}");
        }
    }


    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.Write($"{name} (Воїн): ");
            if (weapon != null)
                weapon.UseWeapon();
            else
                Console.WriteLine("немає зброї!");
        }
    }


    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.Write($"{name} (Маг): ");
            if (weapon != null)
                weapon.UseWeapon();
            else
                Console.WriteLine("немає зброї!");
        }
    }


    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.Write($"{name} (Лучник): ");
            if (weapon != null)
                weapon.UseWeapon();
            else
                Console.WriteLine("немає зброї!");
        }
    }


    public class Assassin : Character
    {
        public Assassin(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.Write($"{name} (Асасин): ");
            if (weapon != null)
                weapon.UseWeapon();
            else
                Console.WriteLine("немає зброї!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо персонажа
            Character warrior = new Warrior("Артур");

            warrior.ShowInfo();

            // Воїн бере меч
            warrior.SetWeapon(new Sword());
            warrior.Attack();

            // Під час гри воїн змінює зброю
            warrior.SetWeapon(new Bow());
            warrior.Attack();

            // Ще одна зміна зброї
            warrior.SetWeapon(new Dagger());
            warrior.Attack();


            Console.WriteLine();

            // Створюємо мага
            Character mage = new Mage("Мерлін");

            mage.ShowInfo();

            mage.SetWeapon(new Staff());
            mage.Attack();

            // Маг також може змінити зброю
            mage.SetWeapon(new Sword());
            mage.Attack();


            Console.ReadKey();
        }
    }
}