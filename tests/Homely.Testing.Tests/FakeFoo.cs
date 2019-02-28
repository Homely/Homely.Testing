using System;

namespace Homely.Testing.Tests
{
    public class FakeFoo
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = new DateTime(1975, 05, 23, 13, 12, 11);
        public string Name { get; set; }
    }
}
