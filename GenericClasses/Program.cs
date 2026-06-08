namespace GenericClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single type parameter example
            /*
            // Create an instance of Box with int as the type parameter
            Box<int> intBox = new Box<int>();
            intBox.Content = 42;
            Console.WriteLine(intBox.Log());

            Box<string> stringBox = new Box<string>();
            stringBox.Content = "Hello, World!";
            Console.WriteLine(stringBox.Log());
            

            Box<string> boxString = new Box<string>("Hello World!!!");
            boxString.updateContent("Updated content!!!");
            Console.WriteLine(boxString.GetContent());
            
            Box<int> boxInt = new Box<int>(100);
            boxInt.updateContent(200);
            Console.WriteLine(boxInt.GetContent());
            */

            // Multiple type parameter example
            /*
            Box<int, string> box = new Box<int, string>(100, "String!!!");
            box.Display();
            */

            // Generic method without generic classes
            /*
            Logger logger = new Logger();

            logger.Log<int>(10);
            logger.Log<string>("Hello World!!!");

            logger.Log(new {Name = "Miro", Age = 10});
            */

            // Constraint for generic class
            /*
            Box<int> boxInt = new Box<int>();
            Box<Book> bookBox = new Box<Book>();
            */

            // Repository
            /*
            Repository<Product> repository = new Repository<Product>();
            var product = new Product();
            repository.Add(product);
            */

            // Constraint for generic method
            /*
            var productOne = new Products();
            var productTwo = new Products();

            var result = Comparer.AreEqual(productOne, productTwo);

            Console.WriteLine(result);
            */


        }
    }
    // Constraint for generic class
    /*
    class Book
    {

    }
    class Product : IEntity
    {
        public int Id { get; set; }
    }
    class Products()
    {

    }
    */

    // Generic interfaces

    
    internal interface IEntity
    {
        int Id { get; }
    }
    internal interface IRepository<T> where T : IEntity
    {

        void Add(T entity);
        void Remove(T entity);
        
    }
    internal class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    internal class User : IEntity 
    {
        
        public string Name { get; set; }
        public int Id { get; }
    }

    internal class ProductRepository : IRepository<Product>
    {
        public void Add(Product entity)
        {

        }
        public void Remove(Product entity)
        {

        }


    }
    internal class UserRepository : IRepository<User>
    {
        public void Add(Product entity)
        {

        }
        public void Remove(Product entity)
        {

        }

        void IRepository<User>.Add(User entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<User>.Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }

}
