using BtmContractDrafter.Library.XUnit.Mocks;
using BTMContractDrafter.Library.Managers;
using FluentAssertions;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace BtmContractDrafter.Library.XUnit.Managers
{
    public class SaveDataManagerTests
    {
        [Fact]
        public void GetFolderPath_ShouldReturnCorrectFolderPath()
        {
            // Arrange
            string folderName = "UnitTest";
            string dataTypePath = "CustomData";

            // Act
            string result = SaveDataManager.GetFolderPath(folderName, dataTypePath);

            // Assert
            string expected = Path.Combine("SaveData", folderName, dataTypePath);
            result.Should().Be(expected);
        }


        [Fact]
        public void CreateFolders_ShouldCreateSaveDataFolders()
        {
            // Arrange
            string baseFolderPath = "SaveData";

            // Act
            SaveDataManager.CreateFolders();

            // Assert
            Directory.Exists(baseFolderPath).Should().BeTrue();
            Directory.Exists(Path.Combine(baseFolderPath, "Json")).Should().BeTrue();
            Directory.Exists(Path.Combine(baseFolderPath, "Csv")).Should().BeTrue();
            Directory.Exists(Path.Combine(baseFolderPath, "PlainText")).Should().BeTrue();
        }

        [Theory]
        [InlineData("invalid<>file:|?*name")]
        [InlineData("test-file.txt")]
        [InlineData("File Name With Spaces")]
        public void SanitizeFilename_ShouldRemoveInvalidCharacters(string input)
        {
            // Arrange
            string invalidFileNameChars = new string(Path.GetInvalidFileNameChars());
            string invalidPathChars = new string(Path.GetInvalidPathChars());

            // Act
            string result = SaveDataManager.SanitizeFilename(input);

            // Assert
            result.Should().NotContain(invalidFileNameChars);
            result.Should().NotContain(invalidPathChars);
            Regex.IsMatch(result, @"[<>:|?*]").Should().BeFalse();
        }

        [Theory]
        [InlineData("file.txt", 8, "file.txt")]
        [InlineData("very-long-file-name.txt", 10, "very-long-")]
        public void TruncateFilename_ShouldLimitFilenameLength(string input, int maxLength, string expected)
        {
            // Act
            string result = SaveDataManager.TruncateFilename(input, maxLength);

            // Assert
            result.Should().Be(expected);
        }

        // Additional tests for SaveJson, SaveCsv, and SavePlainText can be written similarly by mocking the File I/O operations and verifying the output.
        [Fact]
        public void SaveJson_ShouldWriteToFile()
        {
            // Arrange
            string fileName = "data.json";
            string jsonData = "{ \"key\": \"value\" }";
            string dataTypePath = "Unit";

            // Create the mock file system
            var mockFileSystem = new FakeFileSystem();

            // Act
            SaveDataManager.SaveJson(fileName, jsonData, mockFileSystem, dataTypePath);

            // Assert
            string expectedPath = Path.Combine("SaveData", "Json", "Unit", fileName);
            mockFileSystem.FileExists(expectedPath).Should().BeTrue();
            mockFileSystem.GetFile(expectedPath).TextContents.Should().Be(jsonData);
        }

        [Fact]
        public void SaveCsv_ShouldWriteToFile()
        {
            // Arrange
            string fileName = "data.csv";
            string csvData = "1,Test1\n2,Test2\n3,Test3";
            string dataTypePath = "Unit";

            // Create the mock file system
            var mockFileSystem = new FakeFileSystem();

            // Act
            SaveDataManager.SaveCsv(fileName, csvData, mockFileSystem, dataTypePath);

            // Assert
            string expectedPath = Path.Combine("SaveData", "Csv", "Unit", fileName);
            mockFileSystem.FileExists(expectedPath).Should().BeTrue();
            mockFileSystem.GetFile(expectedPath).TextContents.Should().Be(csvData);
        }

        [Fact]
        public void SavePlainText_ShouldWriteToFile()
        {
            // Arrange
            string fileName = "data.txt";
            string plainTextData = "This is a test data.";
            string dataTypePath = "Unit";

            // Create the mock file system
            var mockFileSystem = new FakeFileSystem();

            // Act
            SaveDataManager.SavePlainText(fileName, plainTextData, mockFileSystem, dataTypePath);

            // Assert
            string expectedPath = Path.Combine("SaveData", "PlainText", "Unit", fileName);
            mockFileSystem.FileExists(expectedPath).Should().BeTrue();
            mockFileSystem.GetFile(expectedPath).TextContents.Should().Be(plainTextData);
        }


        // Note: It's important to make sure the file system is not actually accessed during unit testing to keep the tests fast and isolated. For that reason, you should use a mocking library or create mock implementations of the File I/O operations, as shown in previous examples.
    }
}
