using System;
using Xunit;

namespace Violet.WorkItems.ValueTypes
{
    public class CommonTypeExtensionsTest
    {
        [Fact]
        public void CommonTypeExtensions_Value_DataTypeMismatchSet()
        {
            // arrange
            long x = 2345;
            var property = new Property("FOO", nameof(Int32), string.Empty);

            // act & assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                property.Value(x);
            });
        }

        [Fact]
        public void CommonTypeExtensions_Value_DataTypeMismatchGet()
        {
            // arrange
            var property = new Property("FOO", nameof(Int32), string.Empty);

            // act & assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                property.Value(out long x);
            });
        }


        [Fact]
        public void CommonTypeExtensions_Value_Int32_DesierializeNullFails()
        {
            // arrange
            var property = new Property("FOO", nameof(Int32), string.Empty);

            // act & assert
            Assert.Throws<ArgumentException>(() =>
            {
                property.Value(out int result);
            });
        }
        [Fact]
        public void CommonTypeExtensions_Value_Int32_NullableAllowed()
        {
            // arrange
            var property = new Property("FOO", "Int32", string.Empty);

            // act
            property.NullableValue(out int? result);

            // assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1234)]
        public void CommonTypeExtensions_Value_Int32_NullableRoundtrip(int? x)
        {
            // arrange
            var property = new Property("FOO", "Int32", "1234");

            // act
            property.NullableValue(x);
            property.NullableValue(out int? result);

            // assert
            Assert.Equal(x, result);
        }

        [Fact]
        public void CommonTypeExtensions_Value_Int32_Roundtrip()
        {
            // arrange
            int x = 2345;
            var property = new Property("FOO", nameof(Int32), string.Empty);

            // act
            property.Value(x);
            property.Value(out int result);

            // assert
            Assert.Equal(x, result);
        }

        [Fact]
        public void CommonTypeExtensions_Value_Int64_Roundtrip()
        {
            // arrange
            long x = 2345;
            var property = new Property("FOO", nameof(Int64), string.Empty);

            // act
            property.Value(x);
            property.Value(out long result);

            // assert
            Assert.Equal(x, result);
        }

        [Fact]
        public void CommonTypeExtensions_Value_Single_Roundtrip()
        {
            // arrange
            float x = 3.14f;
            var property = new Property("FOO", nameof(Single), string.Empty);

            // act
            property.Value(x);
            property.Value(out float result);

            // assert
            Assert.Equal(x, result);
        }

        [Fact]
        public void CommonTypeExtensions_Value_Double_Roundtrip()
        {
            // arrange
            double x = Math.PI;
            var property = new Property("FOO", nameof(Double), string.Empty);

            // act
            property.Value(x);
            property.Value(out double result);

            // assert
            Assert.Equal(x, result);
        }
    }
}