using System;
using System.IO;
using Xunit;

namespace JSonHandler.Test
{
    public class FileHandlerTest
    {
        private readonly FileHandler<Product> _fileHandler = new FileHandler<Product>();

        [Fact]
        public void TestWriteAndRead()
        {
            var p1 = new Product
            {
                Name = "Apple",
                ExpiryDate = new DateTime(2008, 12, 28),
                Price = 3.99M,
                Sizes = new[] { "Small", "Medium", "Large" }
            };
            _fileHandler.WriteToFile(p1,@"c:\temp\out.json");
            var p2 = _fileHandler.ReadFromFile(@"c:\temp\out.json");
            Assert.Equal(p1,p2);

        }
    }
}
