using System.Collections.Generic;

namespace Homely.Common.Testing.Tests
{
    public static class FakeData
    {
        public static IEnumerable<object[]> EqualData
        {
            get
            {
                // All fields are filled.
                yield return new object[]
                {
                    new FakeFoo
                    {
                        Id = 1,
                        Name = "PewPew"
                    },
                    new FakeFoo
                    {
                        Id = 1,
                        Name = "PewPew"
                    }
                };

                // No names.
                yield return new object[]
                {
                    new FakeFoo
                    {
                        Id = 1
                    },
                    new FakeFoo
                    {
                        Id = 1
                    }
                };
            }
        }
    }
}
