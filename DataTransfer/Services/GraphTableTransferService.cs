using System;
using System.IO;
using System.Windows;
using DataTransfer.Helpers;
using Unity;
using ViewModels.Graph;
using ViewModels.Interfaces;

namespace DataTransfer.Services
{
    internal class GraphTableTransferService : IGraphTableTransferService
    {
        public GraphTableTransferService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public void Save(string path, GraphViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var csv = item.ToCsv();

            File.WriteAllLines(path, csv);
        }

        public void Load(string path, GraphViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            var csv = File.ReadAllLines(path);
            var points = CsvConverter.ToPointList(csv);

            item.Points.Clear();

            foreach (var point in points)
            {
                item.Points.Add(point);
            }
        }

        public void SaveToClipboard(GraphViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var csv = item.ToCsv();
            var text = string.Join(Environment.NewLine, csv);

            Clipboard.SetText(text);
        }

        public bool TryLoadFromClipboard(GraphViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var text = Clipboard.GetText().Trim();

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var csv = text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var points = CsvConverter.ToPointList(csv);

            if (points.Count == 0)
            {
                return false;
            }

            item.Points.Clear();

            foreach (var point in points)
            {
                item.Points.Add(point);
            }

            return true;
        }
    }
}