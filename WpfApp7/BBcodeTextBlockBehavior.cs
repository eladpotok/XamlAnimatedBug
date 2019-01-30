using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace WpfApp7
{
    public sealed class BbCodeTextBlockBehavior : Behavior<TextBlock>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Unloaded += AssociatedObject_Unloaded;

            if (!AssociatedObject.IsLoaded)
            {
                AssociatedObject.Loaded += AssociatedObject_Loaded;
            }
          
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
            Detach();
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

           
                if (AssociatedObject.Text != string.Empty)
                {
                    var gifUrl = AssociatedObject.Text;
                    var im = ImageHelper.Create(gifUrl, new Size(100, 100));
                    AssociatedObject.Inlines.Clear();
                    AssociatedObject.Inlines.Add(im);
                }

        }

        protected override void OnDetaching()
        {
            ClearResources();
            AssociatedObject.Inlines.Clear();

            base.OnDetaching();
        }

        private void ClearResources()
        {
            ImageHelper.Dispose();
        }

    }
}
