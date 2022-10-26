using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonToXml.UnitTests
{
    [TestClass]
    public class VisitorUnitTests
    {
        [TestMethod]
        [DataRow(
            @"{ ""key"": [ {""hello"": ""world""} ] }", 
            @"<wrapper><key><elements><hello>""world""</hello></elements></key></wrapper>")]
        [DataRow(
            @"{ ""key"": [] }", 
            "<wrapper><key><elements /></key></wrapper>")]
        [DataRow(
            @"{ ""key1"": """", ""key2"": [] }",
            @"<wrapper><key1>""""</key1><key2><elements /></key2></wrapper>")]
        public void Visitor_XmlCreated(string jsonInput, string xmlOutput)
        {
            // Arrange
            var fakeBuilder = A.Fake<XmlBuilder>();

            // Act
            var tree = fakeBuilder.ParseJson(jsonInput);
            var result = fakeBuilder.CreateXml(tree);
            
            // Assert
            Assert.AreEqual(xmlOutput, result);
        }
    }
}
