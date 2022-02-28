using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using RealTimeSearchDemo.Behaviors;
using RealTimeSearchDemo.Models;
using System.Collections.ObjectModel;

namespace RealTimeSearchDemo
{
    //这个ViewModel相当于ListViewModel
    public class MainViewModel : ObservableRecipient    //ObservableRecipient 中文叫 可观察收件人，用来收到页面的消息，有Messenger
    {

        public ObservableCollection<MainModel> UserData { get; } = new ObservableCollection<MainModel>();

        private MainModel _selectedContact;
        public MainModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetProperty(ref _selectedContact, value); }
        }

        private string _filterName;
        public string FilterText
        {
            get => _filterName;
            set => SetProperty(ref _filterName, value);
        }

        public MainViewModel()
        {
            //制造假数据传输Model
            UserData = new ObservableCollection<MainModel>
            {
                new MainModel{ Image="E:/nuanrong/Demo/4.jpg" ,Name="张三",Phone="1114456448"},
                new MainModel{ Image="E:/nuanrong/Demo/5.jpg" ,Name="王四",Phone="43523123123"},
                new MainModel{ Image="E:/nuanrong/Demo/3.jpg" ,Name="Jeffery",Phone="12313123123"},
                new MainModel{ Image="E:/nuanrong/Demo/3.jpg" ,Name="李春秋",Phone="13311885758"},
                new MainModel{ Image="E:/nuanrong/Demo/2.jpg" ,Name="李小毛",Phone="19145632867"},
                new MainModel{ Image="E:/nuanrong/Demo/4.jpg" ,Name="张er",Phone="1114456448"},
                new MainModel{ Image="E:/nuanrong/Demo/5.jpg" ,Name="阿松大",Phone="43523123123"},
                new MainModel{ Image="E:/nuanrong/Demo/3.jpg" ,Name="自行车a",Phone="12313123123"},
                new MainModel{ Image="E:/nuanrong/Demo/3.jpg" ,Name="权威",Phone="13311885758"},
                new MainModel{ Image="E:/nuanrong/Demo/2.jpg" ,Name="卡现场",Phone="19145632867"}
            };

            Messenger.Register<MainViewModel, ActionMessage>(this, HandleActionMessage);
        }

        private void HandleActionMessage(MainViewModel recipient, ActionMessage message)    //用来点击AppCard显示详细内容
        {
            MainModel userData;

            if (message.TryExtract(ActionKind.SelectContact, out userData))
            {
                recipient.SelectedContact = userData;
            }
        }
    }
}
