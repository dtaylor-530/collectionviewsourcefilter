using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFTest
{
    public class ShellViewModel : NotifyPropertyChanged
    {
        private Collection<User> _users = new Collection<User>();

        public ICommand FilterCommand { get; }
        public ICommand ClearFilterCommand { get; }
        public ICollectionView collectionView { get; }

        Random random = new Random();
        string value;

        public ShellViewModel()
        {

            this._users.Add(new User() { FirstName = "1" });
            this._users.Add(new User() { FirstName = "2" });
            this._users.Add(new User() { FirstName = "3" });
            this._users.Add(new User() { FirstName = "4" });
            this._users.Add(new User() { FirstName = "5" });
            collectionView = CollectionViewSource.GetDefaultView(this._users);
            collectionView.Filter += OnFilter;
            value = (1 + random.Next(5)).ToString();

            this.FilterCommand = new RelayCommand((a) =>
            {
                value = random.Next(5).ToString();
                collectionView.Refresh();
            }, e => true);

            this.ClearFilterCommand = new RelayCommand((a) =>
            {
                collectionView.Filter += (_) => true;
                collectionView.Refresh();
            }, e => true);
        }

        private bool OnFilter(object obj)
        {
            User user = (User)obj;
            if (user.FirstName.Equals(value))
            {
                return true;
            }
            return false;
        }
    }
}
