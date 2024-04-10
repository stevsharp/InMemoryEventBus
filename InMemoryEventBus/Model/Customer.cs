namespace InMemoryEventBus.Model
{
    public class Customer
    {
        public string Name { get;  }

        public string LastName { get;  }

        public Guid Id => Guid.NewGuid();

        public Customer(string name, string lastName)
        {
            Name = name;

            LastName = lastName;
        }

    }
}
