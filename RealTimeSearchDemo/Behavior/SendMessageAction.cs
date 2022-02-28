using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace RealTimeSearchDemo.Behaviors
{
    class SendMessageAction : TriggerAction<DependencyObject>
    {
        public string Token
        {
            get { return (string)GetValue(TokenProperty); }
            set { SetValue(TokenProperty, value); }
        }

        public static readonly DependencyProperty TokenProperty =
            DependencyProperty.Register("Token", typeof(string), typeof(SendMessageAction), new PropertyMetadata(null));

        public ActionKind Action
        {
            get { return (ActionKind)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(ActionKind), typeof(SendMessageAction), null);

        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(SendMessageAction), new PropertyMetadata(null));

        protected override void Invoke(object parameter)
        {
            var message = new ActionMessage(Action, Data);

            if (Token is null)
            {
                WeakReferenceMessenger.Default.Send(message);
            }
            else
            {
                WeakReferenceMessenger.Default.Send(message, Token);
            }
        }
    }
}
