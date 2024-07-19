using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    // Address Class
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }
    }

    // Customer Class
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
        }

        public Address CustomerAddress
        {
            get { return _address; }
        }

        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }
    }

    // Product Class
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _price;
        private int _quantity;

        public Product(string name, string productId, decimal price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ProductId
        {
            get { return _productId; }
        }

        public decimal TotalCost
        {
            get { return _price * _quantity; }
        }
    }

    // Order Class
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var product in _products)
            {
                totalCost += product.TotalCost;
            }
            totalCost += _customer.LivesInUSA() ? 5 : 35;
            return totalCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            foreach (var product in _products)
            {
                packingLabel.AppendLine($"Product: {product.Name}, ID: {product.ProductId}");
            }
            return packingLabel.ToString();
        }

        public string GetShippingLabel()
        {
            return $"{_customer.Name}\n{_customer.CustomerAddress.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating addresses
            Address address1 = new Address("123 Lake Salt", "Salt Lake City", "UT", "USA");
            Address address2 = new Address("123 Marsella", "Bogotá", "Bogotá", "Colombia");

            // Creating customers
            Customer customer1 = new Customer("Grace Atkson", address1);
            Customer customer2 = new Customer("Laura Guadalupe", address2);

            // Creating products
            Product product1 = new Product("Laptop", "LAP123", 800, 1);
            Product product2 = new Product("Book", "BOO456", 15, 2);
            Product product3 = new Product("Headphone", "HEA789", 40, 1);

            // Creating orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product2);
            order2.AddProduct(product3);

            // Displaying order details
            Console.WriteLine("Order 1:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order1.CalculateTotalCost():C}");

            Console.WriteLine("\nOrder 2:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order2.CalculateTotalCost():C}");
        }
    }
}
