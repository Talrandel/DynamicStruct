using System.Windows;
using System.Windows.Controls;

namespace Lab2_Lists.View
{
    public class ExtendedTreeView : TreeView
    {
        public static readonly DependencyProperty SelectedItemBindableProperty = DependencyProperty.Register("SelectedItemBindable", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));

        public object SelectedItemBindable
        {
            get { return (object)GetValue(SelectedItemBindableProperty); }
            set { SetValue(SelectedItemBindableProperty, value); }
        }

        public ExtendedTreeView()
            : base()
        {
            SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        }

        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItemBindableProperty, SelectedItemBindable);
            }
        }
    }
}