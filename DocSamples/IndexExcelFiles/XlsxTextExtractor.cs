using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services.Documents;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Txt;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace SitefinityWebApp
{
    public class XlsxTextExtractor : ITextExtractor
    {
        private string mimeType;
        private static readonly object documentActionLock = new object();

        public void Initialize(string mimeType, NameValueCollection config)
        {
            this.mimeType = mimeType;
        }

        public string MimeType
        {
            get
            {
                return this.mimeType;
            }
        }

        public void GetText(Stream doc, Stream text)
        {
            ExecuteDocumentAction(() =>
            {
                byte[] data;
                using (var reader = new BinaryReader(doc))
                    data = reader.ReadBytes((int)doc.Length);

                Workbook intermediateDoc = new XlsxFormatProvider().Import(data);
                new TxtFormatProvider().Export(intermediateDoc, text);
            });
        }
        private static void ExecuteDocumentAction(Action action)
        {
            // This way only one document is processed at a time.
            lock (documentActionLock)
            {
                Thread thread = new Thread(() =>
                {
                    // IMPORTANT: Exceptions unhandled in a thread kill the process.
                    try
                    {
                        action();
                    }

                    catch (Exception ex)
                    {
                        ex = new Exception("Error extracting the text content of a document", ex);
                        Log.Write(ex, ConfigurationPolicy.ErrorLog);
                    }
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
        }
    }
}