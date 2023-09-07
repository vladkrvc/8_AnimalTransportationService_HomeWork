using System;
using System.Collections.Generic;

namespace Polymorphism
{
    public class Task
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Первый автомобиль:");
            
            // Создаем автомобиль на 10 мест.
            var car = new Car(10);

            // Создаем массив объектов класса Animal.
            var animals = new Animal[]
            {
                new Cat(), 
                new Dog(), 
                new Dog()
            };

            // Загружаем животных в автомобиль.
            foreach (var animal in animals)
            {
                // Если животное помещается в автомобиль.
                if (car.TryAdd(animal))
                {
                    // Здороваемся с ним.
                    animal.SayHi();
                }
            }
            // Вывод на экран (все животные поместились в автомобиль):
            // Привет! Я кот!
            // Привет! Я собака!
            // Привет! Я собака!

            Console.WriteLine("Второй автомобиль:");
            
            // Создаем автомобиль на 12 мест.
            var car2 = new Car(12);
            
            // Создаем массив объектов класса Animal.
            var animals2 = new Animal[]
            {
                new Dog(), 
                new Dog(),
                new Dog(),
                new Dog(),
                new Dog()
            };
            
            // Загружаем животных в автомобиль.
            foreach (var animal in animals2)
            {
                // Если животное помещается в автомобиль.
                if (car2.TryAdd(animal))
                {
                    // Здороваемся с ним.
                    animal.SayHi();
                }
            }
            // Вывод на экран (поместились только 4 собаки):
            // Привет! Я собака!
            // Привет! Я собака!
            // Привет! Я собака!
            // Привет! Я собака!
        }
    }
    
    public class Car
    {
        public List<Animal> Animals = new List<Animal>();

        // Вместимость автомобиля.
        private int _size;

        public Car(int size)
        {
            _size = size;
        }

        public bool TryAdd(Animal animal)
        {
            // Если животное является коровой - возвращаем false.
            if (animal is Cow)
            {
                return false;
            }

            // Иначе - Отнимаем от вместимости автомобиля размер переданного животного.
            _size -= animal.GetSize();

            // Если в автомобиле есть еще места.
            if (_size >= 0)
            {
                // Добавляем животное в массив и возвращаем true.
                Animals.Add(animal);
                return true;
            }
            
            // Иначе (если мест в автомобиле не осталось) - возвращаем false.
            return false;
        }
    }
    
    public abstract class Animal
    {
        // Размер животного.
        private int _size;
        
        protected Animal(int size)
        {
            _size = size;
        }

        public int GetSize()
        {
            return _size;
        }
        
        public virtual void SayHi()
        {
            Console.WriteLine("Привет! Я животное!");
        }
    }

    public class Cat : Animal
    {

        public override void SayHi()
        {
            Console.WriteLine("Привет! Я кот!");
        }
        
        public void Pet()
        {
            Console.WriteLine("Довольно мурлычу");
        }

        public Cat() : base(2)
        {
        }
    }

    public class Dog : Animal
    {
        public override void SayHi()
        {
            Console.WriteLine("Привет! Я собака!");
        }
        
        public void GiveBone()
        {
            Console.WriteLine("Грызу кость");
        }
        public Dog() : base(3)
        {
        }
    }

    public class Cow : Animal
    {
        public override void SayHi()
        {
            Console.WriteLine("Привет! Я корова!");
        }
        
        public void Milk()
        {
            Console.WriteLine("Угощайтесь");
        }
        public Cow() : base(5)
        {
        }
    }
}