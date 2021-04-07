using System;
using Common;
using Microsoft.Win32;

namespace ViewModels.Helpers
{
    internal static class MessageBoxHelper
    {
        public static SaveFileDialog CreateCsvSaveDialog() =>
            new SaveFileDialog
            {
                Filter = GlobalConstants.CsvFileFilter,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
            };

        public static OpenFileDialog CreateCsvOpenDialog() =>
            new OpenFileDialog
            {
                Filter = GlobalConstants.CsvFileFilter,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
            };
    }
}