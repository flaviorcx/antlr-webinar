lexer grammar JsonLexer;

fragment Digit: [0-9];

Int         : Digit+;
Quote       : '"';
String      : Quote ([a-zA-Z]|Digit|.)*? Quote;
Bool        : 'true' | 'false';
Null        : 'null';
Lsbracket   : '[';
Rsbracket   : ']';
Lbracket    : '{';
Rbracket    : '}';
Comma       : ',';
Semicolon   : ':';
WS          : [ \r\n\t] -> skip;
