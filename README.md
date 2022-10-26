# antlr-webinar
A simple solution to demonstrate how AnTLR can be used for static analysis and transformations.

## Description
The solution has 4 projects:
- **JsonGrammar**: contains the AnTLR files (*.g4) and the configuration for code generation (C#).
- **JsonToXml**: contains the business logic to create an XML output from the JSON input using an AnTLR visitor.
- **JsonToXml.App**: a simple console application to test the **JsonToXml** project with real JSON files as inputs.
- **JsonToXml.UnitTests**: contains a couple of unit tests to check the generated parse tree and the visitor created.

## Useful links
- : [AnTLR 4 Documentation](https://github.com/antlr/antlr4/blob/master/doc/index.md)
- : [Regular Expressions Reference](https://www.regular-expressions.info/refquick.html)

**Enjoy!**
