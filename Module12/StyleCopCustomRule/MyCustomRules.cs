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
        public override void AnalyzeDocument(CodeDocument currentCodeDocument)
        {
            var codeDocument = (CsDocument)currentCodeDocument;
            if (codeDocument.RootElement != null && !codeDocument.RootElement.Generated)
            {
                codeDocument.WalkDocument(InspectCurrentElement, null, null);
            }
        }

        private bool InspectCurrentElement(CsElement element, CsElement parentElement, object context)
        {
            if (element is Class cClass && cClass.BaseClass.Contains("Controller"))
            {
                var hasMvcUsingParent = parentElement?.ChildElements
                    .Any(x => x.ElementType == ElementType.UsingDirective && x.Declaration.Name.Equals("System.Web.Mvc", StringComparison.Ordinal)) ?? false;

                var hasMvcUsingRoot = parentElement.FindParentElement()?.ChildElements
                    .Any(x => x.ElementType == ElementType.UsingDirective && x.Declaration.Name.Equals("System.Web.Mvc", StringComparison.Ordinal)) ?? false;

                if (hasMvcUsingParent || hasMvcUsingRoot)
                {
                    if (!cClass.Name.EndsWith("Controller"))
                        AddViolation(element, "SystemWebMvcControllerMustHaveSuffixController", "SystemWebMvcControllerMustHaveSuffixController");

                    if (!element.Attributes.Any(x => x.ChildTokens.Any(t => t.Text.Contains("Authorize"))))
                    {
                        var publicMethods = element.ChildElements.Where(x =>
                            x.ElementType == ElementType.Method && x.AccessModifier == AccessModifierType.Public).ToList();

                        var hasNonAutorizePublicMethods = !publicMethods.Any() || publicMethods.Any(x => !x.Attributes.Any(a => a.ChildTokens.Any(t => t.Text.Contains("Authorize"))));

                        if (hasNonAutorizePublicMethods)
                            AddViolation(element, "SystemWebMvcControllerMustHaveAttribute", "SystemWebMvcControllerMustHaveAttribute");
                    }
                }
            }

            if (element.ElementType == ElementType.Namespace && element.Declaration.Name.EndsWith(".Entities"))
            {
                var classElements = element.ChildElements.Where(x => x.ElementType == ElementType.Class);

                foreach (var clElement in classElements)
                {
                    if (clElement is Class cl)
                    {
                        if (cl.AccessModifier != AccessModifierType.Public)
                            AddViolation(parentElement, "ClassUnderEntitiesNamespaceMustBePublic", "ClassUnderEntitiesNamespaceMustBePublic");

                        if (!clElement.Attributes.Any(x => x.ChildTokens.Any(t => t.Text.Contains("DataContract"))))
                            AddViolation(parentElement, "ClassUnderEntitiesNamespaceMustHaveAttribute", "ClassUnderEntitiesNamespaceMustHaveAttribute");
                    }

                    var propElements = clElement.ChildElements.Where(x => x.ElementType == ElementType.Property).ToList();

                    var idElement = propElements.FirstOrDefault(x => x.Declaration.Name.Equals("Id", StringComparison.Ordinal));
                    if (idElement == null || idElement.AccessModifier != AccessModifierType.Public)
                        AddViolation(parentElement, "ClassUnderEntitiesNamespaceMustHavePublicId", "ClassUnderEntitiesNamespaceMustHavePublicId");

                    var nameElement = propElements.FirstOrDefault(_ => _.Declaration.Name.Equals("Name", StringComparison.Ordinal));
                    if (nameElement == null || nameElement.AccessModifier != AccessModifierType.Public)
                        AddViolation(parentElement, "ClassUnderEntitiesNamespaceMustHavePublicName", "ClassUnderEntitiesNamespaceMustHavePublicName");
                }
            }
            return true;
        }
    }
}
