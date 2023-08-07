//using BTMContractDrafter.Library.Data;
//using BTMContractDrafter.Library.Extensions;
//using FluentAssertions;
//using Moq;
//using System;
//using Xunit;

//namespace BtmContractDrafter.Library.XUnit.Extensions
//{
//    public class UnitDataSerializerExtensionTests
//    {


//        public UnitDataSerializerExtensionTests()
//        {

//        }

//        [Fact]
//        public void SaveAllFormats_ShouldSerializeToAllFormatsAndCallFileService()
//        {
//            // Arrange
//            var unitData = new UnitData { /* initialize unitData with necessary properties */ };
//            var mockFileService = new MockFileService();

//            // Act
//            unitData.SaveAllFormats(mockFileService);

//            // Assert
//            string expectedJson = unitData.SerializeToJson();
//            string expectedCsv = unitData.SerializeToCsv();
//            string expectedPlainText = unitData.SerializeToPlainText();

//            string jsonFileContent = mockFileService.GetFileContent(sanitizedFileName + ".json");
//            string csvFileContent = mockFileService.GetFileContent(sanitizedFileName + ".csv");
//            string plainTextFileContent = mockFileService.GetFileContent(sanitizedFileName + ".txt");

//            jsonFileContent.Should().Be(expectedJson);
//            csvFileContent.Should().Be(expectedCsv);
//            plainTextFileContent.Should().Be(expectedPlainText);
//        }
//    }
//}
