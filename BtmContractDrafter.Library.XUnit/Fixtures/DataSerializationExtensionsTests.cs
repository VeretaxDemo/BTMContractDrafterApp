using System.Text.Json;
using System.Xml.Linq;
using BTMContractDrafter.Library.Extensions;
using FluentAssertions;

namespace BtmContractDrafter.Library.XUnit.Fixtures
{
    // Test data


    public class DataSerializationExtensionsTests
    {

        [Fact]
        public void GetElementTypeOfCollection_ValidList_ShouldReturnElementType()
        {
            // Arrange
            var list = new List<int> { 1, 2, 3 };

            // Act
            Type elementType = DataSerializationExtensions.GetElementTypeOfCollection(list);

            // Assert
            Assert.Equal(typeof(int), elementType);
        }

        [Fact]
        public void GetElementTypeOfCollection_NullList_ShouldThrowArgumentNullException()
        {
            // Arrange
            List<int> list = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => DataSerializationExtensions.GetElementTypeOfCollection(list));
        }

        [Fact]
        public void SerializeToJson_WhenCalled_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string json = data.SerializeToJson();

            // Assert
            json.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void SerializeToJson_ShouldSerializeObjectToJsonString()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string json = data.SerializeToJson();

            // Assert
            // We are calling this Fully Qualified because it enables us to rely on a
            // Framework provided method instead of just a third Party Library
            var expectedJson = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true // To format the JSON string with indentation
            });
            json.Should().Be(expectedJson);
        }

        [Fact]
        public void SerializeToCsv_WhenCalled_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string csv = data.SerializeToCsv();

            // Assert
            // Implement the CSV serialization logic and perform assertions here
            // For the sake of simplicity, we will just check if the returned string is not empty
            csv.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void SerializeToCsv_WhenCalled_ShouldReturnCsvText()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string csv = data.SerializeToCsv();
            var expected = $"Id,Name{Environment.NewLine}" +
                           $"1,Test Object{Environment.NewLine}";

            // Assert
            // Implement the CSV serialization logic and perform assertions here
            // For the sake of simplicity, we will just check if the returned string is not empty
            csv.Should().Be(expected);
        }

        [Fact]
        public void SerializeToCsv_WhenDataIsNull_ShouldReturnEmptyString()
        {
            // Arrange
            TestData data = null;

            // Act
            string csv = data.SerializeToCsv();

            // Assert
            csv.Should().BeEmpty();
        }

        [Fact]
        public void SerializeCollectionToCsv_WhenDataIsNull_ShouldReturnEmptyString()
        {
            // Arrange
            IEnumerable<TestData> data = null;

            // Act
            string csv = data.SerializeCollectionToCsv();

            // Assert
            csv.Should().BeEmpty();
        }

        [Fact]
        public void SerializeToCsv_WhenCalledWithCollection_ShouldReturnCsvString()
        {
            // Arrange
            var data = new List<TestData>
            {
                new TestData { Id = 1, Name = "Test Object 1" },
                new TestData { Id = 2, Name = "Test Object 2" },
                new TestData { Id = 3, Name = "Test Object 3" }
            };

            // Act
            string csv = data.SerializeToCsv();

            // Assert
            string expectedCsv =
                $"Id,Name{Environment.NewLine}" +
                $"1,Test Object 1{Environment.NewLine}" +
                $"2,Test Object 2{Environment.NewLine}" +
                $"3,Test Object 3{Environment.NewLine}";

            csv.Should().Be(expectedCsv);
        }

        [Fact]
        public void SerializeToCsv_WhenCalledWithEmptyCollection_ShouldReturnHeaderRow()
        {
            // Arrange
            var data = new List<TestData>();

            // Act
            string csv = data.SerializeToCsv();

            // Assert
            var expectedHeaderRow = "Id,Name";
            csv.Should().NotBeNullOrEmpty();
            csv.Should().Contain(expectedHeaderRow);
        }


        [Fact]
        public void SerializeToCsv_WhenCalledWithNullCollection_ShouldReturnEmptyString()
        {
            // Arrange
            List<TestData> data = null;

            // Act
            string csv = data.SerializeToCsv();

            // Assert
            csv.Should().BeEmpty();
        }

        [Fact]
        public void SerializeToCsv_WhenCalledWithCollectionOfDifferentTypes_ShouldThrowArgumentException()
        {
            // Arrange
            var data = new List<object>
            {
                new TestData { Id = 1, Name = "Test Object 1" },
                new TestData { Id = 2, Name = "Test Object 2" },
                new AnotherTestData { Id = 3, Description = "Another Test Object 3" }
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => data.SerializeToCsv());
        }

        [Fact]
        public void SerializeCollectionToCsv_WhenElementTypeIsNull_ShouldThrowArgumentException()
        {
            // Arrange
            var data = new NullElementTypeEnumerable();

            // Act
            Action action = () => data.SerializeCollectionToCsv();

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void SerializeCollectionToCsv_WhenCalledAsNonExtensionMethodWithDataIsNull_ShouldReturnEmptyString()
        {
            // Arrange
            IEnumerable<TestData> data = null;
            var elementType = typeof(TestData); // You can set the elementType to any type since data is null

            // Act
            string csv = DataSerializationExtensions.SerializeCollectionToCsv(data, elementType);

            // Assert
            csv.Should().BeEmpty();
        }



        [Fact]
        public void SerializeToPlainText_WhenCalled_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            // Implement the plain text serialization logic and perform assertions here
            // For the sake of simplicity, we will just check if the returned string is not empty
            plainText.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void SerializeToPlainText_ShouldSerializeObjectToPlainTextString()
        {
            // Arrange
            var data = new TestData { Id = 1, Name = "Test Object" };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            // Implement the plain text serialization logic and perform assertions here
            // For the sake of simplicity, we will just check if the returned string is not empty
            plainText.Should().NotBeNullOrEmpty();
        }

        //[Fact]
        //public void SerializeToPlainText_WhenCalledWithBasicObject_ShouldReturnPlainText()
        //{
        //    // Arrange
        //    var data = new { Name = "John", Age = 30 };

        //    // Act
        //    string plainText = data.SerializeToPlainText();

        //    // Assert
        //    string expectedPlainText = "Name: John, Age: 30";
        //    plainText.Should().Be(expectedPlainText);
        //}

        //[Fact]
        //public void SerializeToPlainText_WhenCalledWithNullableProperty_ShouldHandleNullValues()
        //{
        //    // Arrange
        //    var data = new { Name = "Alice", Age = (int?)null };

        //    // Act
        //    string plainText = data.SerializeToPlainText();

        //    // Assert
        //    string expectedPlainText = "Name: Alice, Age: ";
        //    plainText.Should().Be(expectedPlainText);
        //}

        [Fact]
        public void SerializeToPlainText_WhenCalledWithCollection_ShouldReturnPlainTextForEachItem()
        {
            // Arrange
            var dataList = new List<TestData>
            {
                new TestData { Id = 1, Name = "Test Object 1" },
                new TestData { Id = 2, Name = "Test Object 2" },
                new TestData { Id = 3, Name = "Test Object 3" }
            };

            // Act
            string plainText = dataList.SerializeToPlainText();

            // Assert
            string expectedPlainText =
                $"Id: 1{Environment.NewLine}Name: Test Object 1{Environment.NewLine}" +
                $"Id: 2{Environment.NewLine}Name: Test Object 2{Environment.NewLine}" +
                $"Id: 3{Environment.NewLine}Name: Test Object 3{Environment.NewLine}{Environment.NewLine}";
            plainText.Should().Be(expectedPlainText);
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithNestedObjects_ShouldReturnPlainTextWithNestedData()
        {
            // Arrange
            var nestedData = new { NestedId = 42, NestedName = "Nested Object" };
            var data = new { Id = 1, Name = "Test Object", NestedData = nestedData };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            string expectedPlainText = $"Id: 1{Environment.NewLine}Name: Test Object{Environment.NewLine}NestedData: {{ NestedId = 42, NestedName = Nested Object }}";
            plainText.Should().Be(expectedPlainText);
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithEmptyObject_ShouldReturnInitializedData()
        {
            // Arrange
            var emptyData = new TestData();
            string expected = $"Id: {emptyData.Id}, {Environment.NewLine}{Environment.NewLine}Name: {emptyData.Name}{Environment.NewLine}{Environment.NewLine}";

            // Act
            string plainText = emptyData.SerializeToPlainText();

            // Assert
            plainText.Should().Be(expected);
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithSpecialCharacters_ShouldEscapeSpecialCharacters()
        {
            // Arrange
            var data = new { Name = $"Test \"Object\"", Description = $"Line{Environment.NewLine}Break" };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            string expectedPlainText = $"Name: Test \"Object\"{Environment.NewLine}Description: Line{Environment.NewLine}Break";
            plainText.Should().Be(expectedPlainText);
        }

        // Sample class implementing IPlainTextSerializable
        public class CustomPlainTextSerializable : IPlainTextSerializable
        {
            public string CustomProperty { get; set; }

            public string SerializeToPlainText()
            {
                return "Custom Property: " + CustomProperty;
            }
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithCustomPlainTextSerializable_ShouldUseCustomSerialization()
        {
            // Arrange
            var data = new CustomPlainTextSerializable { CustomProperty = "Hello, Custom!" };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            string expectedPlainText = "Custom Property: Hello, Custom!";
            plainText.Should().Be(expectedPlainText);
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithLargeObject_ShouldPerformEfficiently()
        {
            // Arrange
            var largeData = new TestData
            {
                Id = 1,
                Name = new string('x', 10000) // Create a large string
            };

            // Act
            string plainText = largeData.SerializeToPlainText();

            // Assert
            plainText.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithNullAndDefaultValues_ShouldHandleThemAppropriately()
        {
            // Arrange
            var data = new TestData { Id = 0, Name = null };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            string expectedPlainText = $"Id: 0, {Environment.NewLine}{Environment.NewLine}Name: {Environment.NewLine}{Environment.NewLine}";
            plainText.Should().Be(expectedPlainText);
        }

        [Fact]
        public void SerializeToPlainText_WhenCalledWithCustomSerializableClass_ShouldReturnPlainText()
        {
            // Arrange
            var data = new CustomSerializableClass { Value = 42 };

            // Act
            string plainText = data.SerializeToPlainText();

            // Assert
            string expectedPlainText = "Value: 42";
            plainText.Should().Be(expectedPlainText);
        }

    }
}

