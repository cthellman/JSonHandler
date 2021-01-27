﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JSonHandler
{
    public class Product: IEquatable<Product>
    {
        public string Name { get; set; }

        public DateTime ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<string> Sizes { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name:{Name}");
            sb.AppendLine($"ExpiryDate:{ExpiryDate.ToLongDateString()}");
            sb.AppendLine($"Price:{Price.ToString(CultureInfo.CurrentCulture)}");
            sb.AppendLine($"Sizes:{Sizes}");
            return sb.ToString();
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && ExpiryDate.Equals(other.ExpiryDate) && Price == other.Price && Sizes.SequenceEqual(other.Sizes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ExpiryDate, Price, Sizes);
        }
    }
}
