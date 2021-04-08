using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Xaml.Behaviors;
using ViewModels.Graph;
using Wpf.Tools.Helpers;

namespace FunctionGraphManager.Behaviors
{
    internal class CollectionViewSourceSortRefreshBehavior : Behavior<DataGrid>
    {
        private INotifyCollectionChanged _items;

        protected override void OnAttached()
        {
            base.OnAttached();

            _items = AssociatedObject.Items;
            _items.CollectionChanged += ItemsOnCollectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            _items.CollectionChanged -= ItemsOnCollectionChanged;
        }

        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    _items.CollectionChanged -= ItemsOnCollectionChanged;
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.SortDescriptions.Add(new SortDescription {PropertyName = nameof(GraphPointViewModel.X)});
                    ViewSource.View?.Refresh();
                    _items.CollectionChanged += ItemsOnCollectionChanged;
                }
            }
            catch (Exception ex)
            {
                this.LogCriticalException(ex);
            }
        }

        #region ViewSource dependency: CollectionViewSource

        public static readonly DependencyProperty ViewSourceProperty =
            DependencyProperty.Register(
                nameof(ViewSource),
                typeof(CollectionViewSource),
                typeof(CollectionViewSourceSortRefreshBehavior),
                new PropertyMetadata(default(CollectionViewSource)));

        public CollectionViewSource ViewSource
        {
            get => (CollectionViewSource) GetValue(ViewSourceProperty);
            set => SetValue(ViewSourceProperty, value);
        }

        #endregion
    }
}