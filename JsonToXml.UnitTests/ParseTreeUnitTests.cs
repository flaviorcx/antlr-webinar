using FakeItEasy;
using JsonGrammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonToXml.UnitTests
{
    [TestClass]
    public class ParseTreeUnitTests
    {
        [TestMethod]
        public void ParseTree_VisitElementsMustHaveHappenedOnce()
        {
            // Arrange
            var jsonInput = "{ \"key\": [ {\"hello\": \"world\"} ] }";
            var fakeBuilder = A.Fake<XmlBuilder>();
            var fakeVisitor = A.Fake<JsonParserCustomVisitor>(options => options.CallsBaseMethods());

            // Act
            var tree = fakeBuilder.ParseJson(jsonInput);
            fakeVisitor.Visit(tree);

            // Assert
            A.CallTo(() => fakeVisitor.VisitJson(A<JsonParser.JsonContext>.Ignored)).MustHaveHappened()
                .Then(A.CallTo(() => fakeVisitor.VisitElements(A<JsonParser.ElementsContext>.Ignored)).MustHaveHappenedOnceExactly());
        }
    }
}
