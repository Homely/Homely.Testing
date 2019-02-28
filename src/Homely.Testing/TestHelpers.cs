using Shouldly;
using System;
using System.IO;

namespace Homely.Testing
{
    public static class TestHelpers
    {
        private static readonly Lazy<CustomJsonSerializer> lazyCustomJsonSerializer = new Lazy<CustomJsonSerializer>(() => new CustomJsonSerializer());

        /// <summary>
        /// Compares two models and throws an exception if they are not 'equal'.
        /// </summary>
        /// <typeparam name="T">Can be any POCO.</typeparam>
        /// <param name="actual">Model to test again. i.e. Source model.</param>
        /// <param name="expected">Model which contains the expected structure/data. i.e. destination model.</param>
        /// <remarks>This extension method is mainly to be used during an <code>Assert</code> test section.</remarks>
        public static void ShouldLookLike<T>(this T actual,
                                             T expected)
        {
            if (actual == null &&
                expected == null)
            {
                return;
            }

            actual.ShouldNotBeNull();
            expected.ShouldNotBeNull();

            var actualJson = actual.ConvertToJson();
            var expectedJson = expected.ConvertToJson();
            actualJson.ShouldBe(expectedJson);
        }

        /// <summary>
        /// Compares two models and returns <code>true</code> or <code>false</code> if they are 'equal' or not.
        /// </summary>
        /// <typeparam name="T">Can be any POCO.</typeparam>
        /// <param name="actual">Model to test again. i.e. Source model.</param>
        /// <param name="expected">Model which contains the expected structure/data. i.e. destination model.</param>
        /// <returns><code>bool</code>: If the two models are 'equal' / the same.</returns>
        /// <remarks>This extension method is mainly to be used in moq <code>Setup(..)</code> definitions.</remarks>
        public static bool LooksLike<T>(this T actual,
                                        T expected)
        {
            if (actual == null &&
                expected == null)
            {
                return true;
            }

            if (expected != null &&
                actual == null)
            {
                return false;
            }

            if (expected == null)
            {
                return false;
            }

            var actualJson = actual.ConvertToJson();
            var expectedJson = expected.ConvertToJson();

            return actualJson == expectedJson;
        }

        /// <summary>
        /// Simple helper method to convert some model to a Json representation but using the <code>CustomJsonSerializer</code> settings.
        /// </summary>
        /// <typeparam name="T">Can be any POCO.</typeparam>
        /// <param name="model">Model to convert to json.</param>
        /// <returns><code>string</code>: json result.</returns>
        public static string ConvertToJson<T>(this T model)
        {
            model.ShouldNotBeNull();

            using (var stringWriter = new StringWriter())
            {
                var serializer = lazyCustomJsonSerializer.Value;
                serializer.Serialize(stringWriter, model);

                return stringWriter.ToString();
            }
        }
    }
}
