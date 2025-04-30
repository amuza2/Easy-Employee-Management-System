using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EEMS.UI.Views.Shared.DocumentPrinting
{
    /// <summary>
    /// Interaction logic for LiveDocumentDesignerWindow.xaml
    /// </summary>
    public partial class LiveDocumentDesignerWindow : Window
    {
        private const string CodeTemplate = @"
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DocumentDesigner
{
    public class DocumentGenerator
    {
        public static FlowDocument GenerateDocument()
        {
            // Your document generation code goes here
            var document = new FlowDocument();
            document.PagePadding = new Thickness(50);
            document.FontFamily = new FontFamily(""Segoe UI"");
            document.FontSize = 12;
            document.ColumnWidth = 500;

            // Document Header
            var headerSection = new Section();
            var text1 = new Paragraph(new Run(""الجمهورية الجزائرية الديموقراطية الشعبية""))
            {
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };
            headerSection.Blocks.Add(text1);
            document.Blocks.Add(headerSection);

            return document;
        }
    }
}";

        public LiveDocumentDesignerWindow()
        {
            InitializeComponent();
            codeTextBox.Text = CodeTemplate;

            // Generate initial preview
            GeneratePreview();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            GeneratePreview();
        }

        private void btnCopyCode_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(codeTextBox.Text);
            MessageBox.Show("Code copied to clipboard!", "Copy Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void GeneratePreview()
        {
            try
            {
                // Get the code from the text box
                string code = codeTextBox.Text;

                // Create a C# compiler
                var csc = new CSharpCodeProvider();
                var parameters = new CompilerParameters
                {
                    GenerateInMemory = true,
                    GenerateExecutable = false
                };

                // Add necessary references
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.Core.dll");
                parameters.ReferencedAssemblies.Add("PresentationFramework.dll");
                parameters.ReferencedAssemblies.Add("PresentationCore.dll");
                parameters.ReferencedAssemblies.Add("WindowsBase.dll");

                // Compile the code
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, code);

                // Check for errors
                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Compilation errors:");
                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine($"Line {error.Line}: {error.ErrorText}");
                    }

                    // Show errors in preview
                    FlowDocument errorDoc = new FlowDocument();
                    errorDoc.Blocks.Add(new Paragraph(new Run(sb.ToString())) { Foreground = System.Windows.Media.Brushes.Red });
                    documentReader.Document = errorDoc;
                    return;
                }

                // Get the compiled assembly
                Assembly assembly = results.CompiledAssembly;

                // Get the DocumentGenerator class
                Type documentGeneratorType = assembly.GetType("DocumentDesigner.DocumentGenerator");

                // Invoke the GenerateDocument method
                MethodInfo generateDocumentMethod = documentGeneratorType.GetMethod("GenerateDocument");
                FlowDocument document = (FlowDocument)generateDocumentMethod.Invoke(null, null);

                // Update the preview
                documentReader.Document = document;
            }
            catch (Exception ex)
            {
                // Show error message
                FlowDocument errorDoc = new FlowDocument();
                errorDoc.Blocks.Add(new Paragraph(new Run($"Error generating preview: {ex.Message}")) { Foreground = System.Windows.Media.Brushes.Red });
                documentReader.Document = errorDoc;
            }
        }
    }
}
