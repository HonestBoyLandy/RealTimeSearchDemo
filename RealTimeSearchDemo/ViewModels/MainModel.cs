using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RealTimeSearchDemo.Models
{
    public class MainModel : ObservableObject
    {
        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
    }
}
