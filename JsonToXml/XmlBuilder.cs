using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JsonGrammar;

namespace JsonToXml
{
    public class XmlBuilder
    {
        public IParseTree ParseJson(string content)
        {
            var input = new AntlrInputStream(content);
            var lexer = new JsonLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new JsonParser(tokens);

            return parser.json();
        }

        public string CreateXml(IParseTree jsonParseTree)
        {
            var visitor = new JsonParserCustomVisitor();
            return visitor.Visit(jsonParseTree);
        }
    }
}
