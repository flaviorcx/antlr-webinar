using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using JsonGrammar;

namespace JsonToXml
{
    public class JsonParserCustomVisitor : JsonParserBaseVisitor<string>
    {
        public override string VisitJson([NotNull] JsonParser.JsonContext context)
        {
            return $"<wrapper>{base.VisitJson(context)}</wrapper>";
        }

        public override string VisitArrayEmpty([NotNull] JsonParser.ArrayEmptyContext context)
        {
            return "<elements />";
        }

        public override string VisitArrayNotEmpty([NotNull] JsonParser.ArrayNotEmptyContext context)
        {
            return Visit(context.elements());
        }

        public override string VisitElements([NotNull] JsonParser.ElementsContext context)
        {
            string elements = string.Empty;
            foreach (var elementContext in context.element())
            {
                elements += Visit(elementContext);
            }

            return $"<elements>{elements}</elements>";
        }

        public override string VisitObjectEmpty([NotNull] JsonParser.ObjectEmptyContext context)
        {
            return string.Empty;
        }

        public override string VisitObjectNotEmpty([NotNull] JsonParser.ObjectNotEmptyContext context)
        {
            return Visit(context.pairs());
        }

        public override string VisitPairs([NotNull] JsonParser.PairsContext context)
        {
            string result = string.Empty;
            foreach (var pairContext in context.pair())
            {
                result += Visit(pairContext);
            }

            return result;
        }

        public override string VisitPair([NotNull] JsonParser.PairContext context)
        {
            string tag = Visit(context.key());
            string element = Visit(context.element());

            return $"<{tag}>{element}</{tag}>";
        }

        public override string VisitKey([NotNull] JsonParser.KeyContext context)
        {
            return context.GetText().Replace("\"", "");
        }

        public override string VisitTerminal(ITerminalNode node)
        {
            return node.GetText();
        }
    }
}
