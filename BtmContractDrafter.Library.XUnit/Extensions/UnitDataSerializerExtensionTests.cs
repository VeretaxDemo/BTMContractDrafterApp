using System;
using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;
using BTMContractDrafter.Library.Managers;
using BTMContractDrafter.Library.IO;
using BtmContractDrafter.Library.XUnit.Fakes;
using FluentAssertions;
using Xunit;

namespace BTMContractDrafter.Library.XUnit.Extensions
{
    public class UnitDataSerializerExtensionTests
    {
        private string _dateFormat = "yyyyMMdd";

        [Fact]
        public void CreateValidFilename_ShouldReturnValidFilename()
        {
            // Arrange
            var unitData = new UnitData
            {
                UnitName = "Test Unit",
                UnitSizeName = "Large"
            };

            // Act
            string filename = unitData.CreateValidFilename("yyyyMMdd_HHmmss");

            // Assert
            filename.Should().NotBeNullOrEmpty();
            filename.Should().MatchRegex(@"^Test-Unit-Large-\d{8}_\d{6}$");
            // Example valid filename pattern: "Test-Unit-Large-20230803_093015"
        }

        [Fact]
        public void SaveAllFormats_ShouldSaveAllFormats()
        {
            // Arrange
            var unitData = new UnitData
            {
                UnitName = "Test Unit",
                UnitSizeName = "Large",
                // Initialize other properties as needed for the UnitData object
            };
            var expectedJsonPath = "SaveData\\Json\\Unit\\";
            var expectedCsvPath = "SaveData\\Csv\\Unit\\";
            var expectedPlainTextPath = "SaveData\\PlainText\\Unit\\";

            // Set up the mock file system
            var fakeFileSystem = new FakeFileSystem();
            IFileSystem originalFileSystem = SaveDataManager.FileSystem;
            SaveDataManager.FileSystem = fakeFileSystem;

            try
            {
                // Act
                UnitDataSerializerExtension.DefaultDateFormat = _dateFormat;
                unitData.SaveAllFormats(fakeFileSystem);

                // Assert
                string expectedJsonFilename = unitData.CreateValidFilename(_dateFormat) + ".json";
                string expectedCsvFilename = unitData.CreateValidFilename(_dateFormat) + ".csv";
                string expectedPlainTextFilename = unitData.CreateValidFilename(_dateFormat) + ".txt";

                string sanitizedJsonFileName = SaveDataManager.SanitizeFilename(expectedJsonFilename);
                string sanitizedCsvFileName = SaveDataManager.SanitizeFilename(expectedCsvFilename);
                string sanitizedPlainTextFileName = SaveDataManager.SanitizeFilename(expectedPlainTextFilename);

                var expectedFullJsonPath = $"{expectedJsonPath}{sanitizedJsonFileName}";
                fakeFileSystem.FileExists(expectedFullJsonPath).Should().BeTrue();

                var expectedFullCsvPath = $"{expectedCsvPath}{sanitizedCsvFileName}";
                fakeFileSystem.FileExists(expectedFullCsvPath).Should().BeTrue();

                var expectedFullPlainTextPath = $"{expectedPlainTextPath}{sanitizedPlainTextFileName}";
                fakeFileSystem.FileExists(expectedFullPlainTextPath).Should().BeTrue();

                FakeFile jsonFile = fakeFileSystem.GetFile(expectedFullJsonPath);
                FakeFile csvFile = fakeFileSystem.GetFile(expectedFullCsvPath);
                FakeFile plainTextFile = fakeFileSystem.GetFile(expectedFullPlainTextPath);

                jsonFile.TextContents.Should().NotBeNullOrEmpty();
                csvFile.TextContents.Should().NotBeNullOrEmpty();
                plainTextFile.TextContents.Should().NotBeNullOrEmpty();

                // Add additional assertions as needed for the content of each file format.
                // For example, you could deserialize the jsonFile.TextContents back to UnitData and compare properties.
            }
            finally
            {
                // Restore the original file system
                SaveDataManager.FileSystem = originalFileSystem;
            }
        }
    }
}

