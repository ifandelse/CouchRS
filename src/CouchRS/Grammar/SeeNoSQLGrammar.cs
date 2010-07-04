using Irony.Parsing;

namespace CouchRS.Grammar
{
    /// <summary>
    /// This class defines the query syntax that will be used to create a syntax
    /// tree that can then be parsed to build up a request againts a NoSQL DB (like CouchDB).
    /// The Irony Project is awesome.  Check it out at: http://irony.codeplex.com/
    /// </summary>
    [Language("SeeNoSQL", "1.0", "Basic language for querying NoSQL stores (like CouchDB views and documents).")]
    public class SeeNoSQLGrammar : Irony.Parsing.Grammar
    {

        public SeeNoSQLGrammar()
            : base(false)
        {
            //Terminals
            var lineComment = new CommentTerminal("LINE_COMMENT", "//", "\n", "\r\n");
            var blockComment = new CommentTerminal("BLOCK_COMMENT", "/*", "*/");
            NonGrammarTerminals.Add(lineComment);
            NonGrammarTerminals.Add(blockComment);

            var number = new NumberLiteral("number");
            var intVal = new NumberLiteral("integer", NumberOptions.IntOnly);
            var stringLiteral = new StringLiteral("string", "'", StringOptions.AllowsDoubledQuote);
            var id = new IdentifierTerminal("id");
            id.Priority = Terminal.HighestPriority;
            var param = new IdentifierTerminal("param");
            param.AddPrefix("@",IdOptions.None);
            param.Priority = Terminal.LowestPriority;
            var constantTerminal = new ConstantTerminal("constantTerminal");
            constantTerminal.Add("true", true);
            constantTerminal.Add("false", false);
            constantTerminal.Add("null", null);
            constantTerminal.Priority = Terminal.HighestPriority;

            var ALL = ToTerm("ALL");
            var ALLOW_STALE = ToTerm("ALLOW_STALE");
            var AND = ToTerm("AND");
            var BETWEEN = ToTerm("BETWEEN");
            var COMMA = ToTerm(",");
            var DESCENDING = ToTerm("DESCENDING");
            var DOCUMENT = ToTerm("DOCUMENT");
            var FALSE = ToTerm("false");
            var FROM = ToTerm("FROM");
            var GROUP = ToTerm("GROUP");
            var GROUP_LEVEL = ToTerm("GROUP_LEVEL");
            var IN = ToTerm("IN");
            var INCLUDE_DOCS = ToTerm("INCLUDE_DOCS");
            var INCLUSIVE_END = ToTerm("INCLUSIVE_END");
            var KEY = ToTerm("KEY");
            var LIMIT = ToTerm("LIMIT");
            var OR = ToTerm("OR");
            var QUERYOPTIONS = ToTerm("QUERYOPTIONS");
            var REDUCE = ToTerm("REDUCE");
            var SKIP = ToTerm("SKIP");
            var TRUE = ToTerm("true");
            var UNION = ToTerm("UNION");
            var USING = ToTerm("USING");
            var VIEW = ToTerm("VIEW");
            var WHERE = ToTerm("WHERE");
            var WITH = ToTerm("WITH");

            //Non-terminals
            var betweenStatement = new NonTerminal("between");
            var binExpr = new NonTerminal("binExpr");
            var binOp = new NonTerminal("binOp");
            var constOperand = new NonTerminal("constOperand");
            var documentStatement = new NonTerminal("documentStatement");
            var expression = new NonTerminal("expression");
            var fromStatement = new NonTerminal("from");
            var keyArrayStatement = new NonTerminal("keyArray");
            var keyList = new NonTerminal("keys");
            var keyObjectStatement = new NonTerminal("keyObject");
            var keyValueStatement = new NonTerminal("keyValue");
            var keyStatement = new NonTerminal("key");
            var query = new NonTerminal("query");
            var queryOption = new NonTerminal("queryOption");
            var queryOptionList = new NonTerminal("queryOptionList");
            var queryOptions = new NonTerminal("queryOptions");
            var stmt = new NonTerminal("stmt");
            var unionStatement = new NonTerminal("unionStatement");
            var term = new NonTerminal("term");
            var view = new NonTerminal("view");
            var whereStatement = new NonTerminal("where");


            //Rules
            this.Root = query;
            query.Rule = MakePlusRule(query, unionStatement, stmt);
            stmt.Rule = fromStatement + queryOptions + keyStatement + whereStatement | fromStatement + queryOptions;
            unionStatement.Rule = UNION + ALL;

            term.Rule = id | stringLiteral | number | param | constOperand;
            binOp.Rule = ToTerm("=") | ">" | "<" | ">=" | "<=" | AND | OR | IN | BETWEEN;
            binExpr.Rule = expression + binOp + expression;
            expression.Rule = term | binExpr | betweenStatement | "(" + expression + ")";

            constOperand.Rule = constantTerminal;
            view.Rule = VIEW + "(" + id + COMMA + id + ")";
            queryOptions.Rule = Empty | USING + QUERYOPTIONS + "(" + queryOptionList + ")";
            queryOption.Rule = ALLOW_STALE + binOp + constOperand | DESCENDING + binOp + constOperand | GROUP + binOp + constOperand |
                               GROUP_LEVEL + binOp + intVal | INCLUDE_DOCS + binOp + constOperand | INCLUSIVE_END + binOp + constOperand |
                               LIMIT + binOp + intVal | REDUCE + binOp + constOperand | SKIP + binOp + intVal;
            queryOptionList.Rule = MakePlusRule(queryOptionList, COMMA, queryOption);
            fromStatement.Rule = FROM + view | FROM + documentStatement;
            documentStatement.Rule = DOCUMENT + "(" + term + ")";

            keyStatement.Rule = keyArrayStatement | keyObjectStatement | keyValueStatement;
            keyArrayStatement.Rule = WITH + KEY + "[" + keyList + "]";
            keyObjectStatement.Rule = WITH + KEY + "{" + keyList + "}";
            keyValueStatement.Rule = WITH + KEY + id;
            keyList.Rule = MakePlusRule(keyList, COMMA, id);

            whereStatement.Rule = Empty | WHERE + expression;
            betweenStatement.Rule = "(" + term + COMMA + term + ")";
            
            //Operators
            RegisterOperators(10, "=", "<", ">", "<=", ">=", "BETWEEN");
            RegisterOperators(9, "AND");
            RegisterOperators(8, "OR");
            RegisterOperators(7, "IN");
            MarkPunctuation("[", "]", "(", ")", "{", "}", ",");
            MarkTransient(term,expression, binOp, constOperand, keyStatement);
        }
    }
}
