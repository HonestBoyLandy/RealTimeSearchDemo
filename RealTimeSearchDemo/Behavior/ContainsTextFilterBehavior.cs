using Microsoft.Xaml.Behaviors;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace RealTimeSearchDemo.Behaviors
{
    class ContainsTextFilterBehavior : Behavior<CollectionViewSource>
    {
        private PropertyInfo _propertyInfo;

        public string PropertyName      //属性名字，例如你需要通过它的名字or手机号搜索
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(ContainsTextFilterBehavior), new PropertyMetadata(null));

        public string FilterText        //过滤文本，指你输入在搜索框中的文字
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(ContainsTextFilterBehavior), new PropertyMetadata(null, OnFilterTextChanged));

        private static void OnFilterTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ContainsTextFilterBehavior)d).OnFilterTextChanged();
        }

        private void OnFilterTextChanged()
        {
            AssociatedObject.View.Refresh();
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Filter += CollectionViewSourceFilter;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Filter -= CollectionViewSourceFilter;
        }

        private void CollectionViewSourceFilter(object sender, FilterEventArgs e)
        {
            if (!string.IsNullOrEmpty(PropertyName))
            {
                if (_propertyInfo == null)
                {
                    _propertyInfo = e.Item.GetType().GetProperty(PropertyName);
                }

                var propertyValue = _propertyInfo.GetValue(e.Item);
                e.Accepted =
                    string.IsNullOrEmpty(FilterText) ||
                    (propertyValue != null && propertyValue.ToString().ToLowerInvariant().Contains(FilterText));
                //ToLowerInvariant() 将所有英文转为小写 类似于 Jeffery 你可以搜 j 就出来了
                //ToUpperInvariant() 将所有英文转为大写 类似于 jeffery 你可以搜 J 就有了
            }
        }
    }
}
