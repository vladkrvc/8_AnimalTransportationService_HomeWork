using System.Reflection;
using NUnit.Framework;
using Polymorphism;

namespace Test
{
    public class Tests
    {
        /// <summary>
        /// Проверяем, что конструктор класса Cat создает кота размером 2.
        /// </summary>
        [Test]
        public void CatConstructor_ShouldCreateCatWithSize2()
        {
            var cat = new Cat();

            Assert.AreEqual(2, cat.GetSize(), 
                "Конструктор класса Cat создает кота неверного размера." +
                $"\nПолученное значение: {cat.GetSize()}. " +
                "Ожидаемое значение: 2");
        }
        
        /// <summary>
        /// Проверяем, что конструктор класса Dog создает собаку размером 3.
        /// </summary>
        [Test]
        public void DogConstructor_ShouldCreateDogWithSize3()
        {
            var dog = new Dog();

            Assert.AreEqual(3, dog.GetSize(), 
                "Конструктор класса Dog создает собаку неверного размера." +
                $"\nПолученное значение: {dog.GetSize()}. " +
                "Ожидаемое значение: 3");
        }
        
        /// <summary>
        /// Проверяем, что конструктор класса Cow создает корову размером 5.
        /// </summary>
        [Test]
        public void CowConstructor_ShouldCreateCowWithSize5()
        {
            var cow = new Cow();

            Assert.AreEqual(5, cow.GetSize(), 
                "Конструктор класса Cow создает корову неверного размера." +
                $"\nПолученное значение: {cow.GetSize()}. " +
                "Ожидаемое значение: 5");
        }

        /// <summary>
        /// Проверяем, что класс Animal содержит protected конструктор.
        /// </summary>
        [Test]
        public void AnimalClass_ShouldHasProtectedConstructor()
        {
            var isProtected = typeof(Animal).GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic).Length > 0;
            
            Assert.IsTrue(isProtected, 
                "У класса Animal должен быть protected конструктор.");
        }
        
        /// <summary>
        /// Проверяем, что класс Animal содержит только один конструктор.
        /// </summary>
        [Test]
        public void AnimalClass_ShouldHasSingleConstructor()
        {
            var constructorCount = typeof(Animal).GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Length;

            Assert.AreEqual(1, constructorCount, 
                "У класса Animal должен быть только один конструктор." +
                $"\nПолученное количество конструкторов: {constructorCount}" +
                $"\nОжидаемое значение: 1");
        }
        
        /// <summary>
        /// Проверяем, что поле size класс Animal является приватным.
        /// </summary>
        [Test]
        public void AnimalClass_ShouldHasPrivateSizeField()
        {
            var isPrivate = typeof(Animal).GetField(
                "_size", BindingFlags.Instance | BindingFlags.NonPublic).IsPrivate;
            
            Assert.IsTrue(isPrivate, 
                "Поле _size класса Animal должно быть приватным.");
        }
        
        /// <summary>
        /// Проверяем, что класс Cat содержит только одно приватное поле в родительском классе.
        /// </summary>
        [Test]
        public void CatClass_ShouldHasOnePrivateField()
        {
            var hasFields = typeof(Cat).GetField(
                "_size", BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.Public) != null;
            
            Assert.IsFalse(hasFields,
                "Поле _size не должно дублироваться в классе Cat.");
        }
        
        /// <summary>
        /// Проверяем, что класс Dog содержит только одно приватное поле в родительском классе.
        /// </summary>
        [Test]
        public void DogClass_ShouldHasOnePrivateField()
        {
            var hasFields = typeof(Dog).GetField(
                "_size", BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.Public) != null;
            
            Assert.IsFalse(hasFields,
                "Поле _size не должно дублироваться в классе Dog.");
        }
        
        /// <summary>
        /// Проверяем, что класс Cow содержит только одно приватное поле в родительском классе.
        /// </summary>
        [Test]
        public void CowClass_ShouldHasOnePrivateField()
        {
            var hasFields = typeof(Cow).GetField(
                "_size", BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.Public) != null;
            
            Assert.IsFalse(hasFields,
                "Поле _size не должно дублироваться в классе Cow.");
        }
    }
}