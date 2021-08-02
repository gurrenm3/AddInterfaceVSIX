using Microsoft.VisualStudio.Shell;
using System.Windows.Controls;

namespace AddNewItem_Template.Shared
{
    public class MyExtensionInfo
    {
        public static string itemName = "Interface";

        public static string checkboxText = "Public";

        public static string GenerateFileText(string sourceFolder, string solutionDir, string newFileName, ref CheckBox checkBox)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string namespacePath = sourceFolder.Replace(solutionDir, "").Replace("\\", ".").Replace(" ", "_").TrimStart('.').TrimEnd('.');

            string className = newFileName.Replace(".cs", "").Replace(" ", "_");
            string publicTxt = (!checkBox.IsChecked()) ? "" : "public ";

            string txt =
                "using System;\n" +
                "using System.IO;\n" +
                "using System.Linq;\n" +
                "using System.Collections.Generic;\n" +
                "\n" +
                $"namespace {namespacePath}\n" +
                "{\n" +
                $"\t{publicTxt}interface {className}" +
                "\n\t{" +
                $"\n\t\t\n" +
                "\t}\n" +
                "}";

            return txt;
        }
    }
}
