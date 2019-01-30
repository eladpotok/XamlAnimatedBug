using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace WpfApp7
{
    public abstract class TextBlockBehavior : Behavior<TextBlock>
    {
        private bool _stopEvents;

        private void NotifyOnTextChanged()
        {
            var descr = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            descr.AddValueChanged(AssociatedObject, OnTextChanged);
        }

        private void UnNotifyOnTextChanged()
        {
            var descr = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            descr.RemoveValueChanged(AssociatedObject, OnTextChanged);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            Update(AssociatedObject.Text);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            NotifyOnTextChanged();
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;

            if (!AssociatedObject.IsLoaded)
            {
                AssociatedObject.Loaded += AssociatedObject_Loaded;
            }
            else
            {




                Update();
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


            try
            {
                if (AssociatedObject.Text != string.Empty)
                {
                    //var gifUrl = AssociatedObject.Text;
                    //var im = ImageHelper.Create(gifUrl, new Size(100, 100));
                    //var inlines = GetInlines(im);
                    //AssociatedObject.Inlines.Clear();
                    //AssociatedObject.Inlines.AddRange(inlines); 
                }
            }

            finally
            {
                _stopEvents = false;
            }


           // Update();
        }

        protected override void OnDetaching()
        {
            ClearResources();
            UnNotifyOnTextChanged();
            AssociatedObject.Inlines.Clear();

            base.OnDetaching();
        }

        protected void ClearResources()
        {
            ImageHelper.Dispose();
        }

        private void Update(string text)
        {
            if (_stopEvents || AssociatedObject == null || !AssociatedObject.IsLoaded)
            {
                return;
            }

            _stopEvents = true;

            try
            {
                var inlines = GetInlines(text);
                AssociatedObject.Inlines.Clear();
                AssociatedObject.Inlines.AddRange(inlines);
            }

            finally
            {
                _stopEvents = false;
            }
        }

        protected void Update()
        {
            if (AssociatedObject == null || !AssociatedObject.IsLoaded)
            {
                return;
            }

            var gif = AssociatedObject.Text;


            Update(AssociatedObject.Text);
        }

        protected abstract IEnumerable<Inline> GetInlines(string text);
    }
}