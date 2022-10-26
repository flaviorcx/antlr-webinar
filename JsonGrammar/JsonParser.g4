parser grammar JsonParser;
options{tokenVocab=JsonLexer;}

json    : array | object;

array   : Lsbracket elements Rsbracket  #arrayNotEmpty
        | Lsbracket Rsbracket           #arrayEmpty
        ;

elements: element (Comma element)*;

element : object | array | Int | String | Bool | Null;

object  : Lbracket pairs Rbracket       #objectNotEmpty
        | Lbracket Rbracket             #objectEmpty
        ;

pairs   : pair (Comma pair)*;
pair    : key Semicolon element;
key     : String;
