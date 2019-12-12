using StyleCop;
using StyleCop.CSharp;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleCopCustomRule
{
    [SourceAnalyzer(typeof(CsParser))]
    public class MyCustomRules : SourceAnalyzer
    {
        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csharpDocument = (CsDocument)document;
            if (csharpDocument.RootElement != null && !csharpDocument.RootElement.Generated)
            {
                // Run the custom rules against the code.
                csharpDocument.WalkDocument(
            new CodeWalkerElementVisitor<object>(this.VisitElement),
            new CodeWalkerStatementVisitor<object>(this.VisitStatement),
            new CodeWalkerExpressionVisitor<object>(this.VisitExpression));
            }
        }

        private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            throw new NotImplementedException();
        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            if (element.ElementType == ElementType.Class/* && element.Parent.GetType() == typeof(Controller)  && !element.Name.EndsWith("Controller")*/)
            {
                this.AddViolation(parentElement, element.LineNumber, "ClassMustHavePrefixController");
            }
            return false;
        }

        private bool VisitStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            if (statement.StatementType == StatementType.Block && statement.ChildStatements.Count == 0)
            {
                this.AddViolation(parentElement, statement.LineNumber, "BlockStatementsShouldNotBeEmpty");
            }
            return false;
        }
    }
}
