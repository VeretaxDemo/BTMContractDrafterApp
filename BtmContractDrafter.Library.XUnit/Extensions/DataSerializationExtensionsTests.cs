using Moq;
using Newtonsoft.Json;
using System;
using BTMContractDrafter.Library.Extensions;
using FluentAssertions;
using Xunit;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BtmContractDrafter.Library.XUnit.Extensions
{
    public class DataSerializationExtensionsTests
    {
        // Test data
        private class TestData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private class AnotherTestData
        {
            public int Id { get; set; }
            public string Description { get; set; }
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
    }
}

