using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }

    }
}
