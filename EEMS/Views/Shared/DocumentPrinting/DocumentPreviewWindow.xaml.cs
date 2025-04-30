using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace EEMS.UI.Views.Shared.DocumentPrinting
{
    /// <summary>
    /// Interaction logic for DocumentPreviewWindow.xaml
    /// </summary>
    public partial class DocumentPreviewWindow : Window
    {
        private readonly IPrintableDocumentBuilder _documentBuilder;
        public DocumentPreviewWindow(IPrintableDocumentBuilder documentBuilder)
        {
            InitializeComponent();
            _documentBuilder = documentBuilder;
            documentReader.Document = _documentBuilder.BuilderDocument();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PrintDialog
            var printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Get the FlowDocument
                var document = documentReader.Document;

                // Create a paginator
                var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;

                // Print the document
                printDialog.PrintDocument(paginator, "Printing Document");

                // Notify user
                MessageBox.Show("Document sent to printer.", "Print", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            // Create save file dialog
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                DefaultExt = ".pdf",
                Title = "Export as PDF"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Get the FlowDocument
                    var document = documentReader.Document;

                    // Export to PDF using a method you'll need to implement
                    // You'll need to add a reference to a PDF library since .NET doesn't include built-in PDF export
                    ExportToPdf(document, saveFileDialog.FileName);

                    // Notify user
                    MessageBox.Show("Document exported successfully.", "Export PDF", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting document: {ex.Message}", "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExportToPdf(FlowDocument document, string filePath)
        {
            // This is a placeholder method. You'll need to use a third-party library to create PDFs.
            // Some popular options are iTextSharp, PDFsharp, or Spire.PDF

            // For temporary XPS conversion (which is built into WPF):
            string tempXpsFile = System.IO.Path.GetTempFileName() + ".xps";
            try
            {
                // Create XPS file
                using (XpsDocument xpsDoc = new XpsDocument(tempXpsFile, FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
                    writer.Write(((IDocumentPaginatorSource)document).DocumentPaginator);
                }

                // Here you would convert the XPS file to PDF using a third-party library
                // For example:
                // ConvertXpsToPdf(tempXpsFile, filePath);

                MessageBox.Show("To complete PDF export functionality, please add a PDF library reference and implement the XPS to PDF conversion.",
                    "Implementation Required", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                // Clean up temp file
                if (File.Exists(tempXpsFile))
                {
                    try { File.Delete(tempXpsFile); } catch { }
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
