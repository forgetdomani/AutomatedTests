using System;

namespace CompareAppProject.Models
{
    public class Product: IEquatable<Product>, IComparable<Product>
    {
        private string _name;
        private string _price;
        private string _description;
       
        public string Name { get { return _name; } set { _name = value; } }
        public string Price { get { return _price; } set { _price = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public Product() { }
        public Product(string name, string price)
        {
            _name = name;
            _price = price;
        }
        public Product(string name, string price, string description)
        {
            _name = name;
            _price = price;
            _description = description;
        }

        public int CompareTo(Product other)
        {
            if (Object.ReferenceEquals(other, null))
                return 1;
            int result = Name.CompareTo(other.Name);
            if (result == 0)
                result = Price.CompareTo(other.Price);
            return result;
        }

        public bool Equals(Product other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return (Name == other.Name && Price == other.Price);
        }
    }
}
