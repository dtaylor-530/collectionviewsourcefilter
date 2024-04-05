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

        public ShellViewModel()
        {

            this._users.Add(new User() { FirstName = "1" });
            this._users.Add(new User() { FirstName = "2" });
            this._users.Add(new User() { FirstName = "3" });
            this._users.Add(new User() { FirstName = "4" });
            this._users.Add(new User() { FirstName = "5" });
            collectionView = CollectionViewSource.GetDefaultView(this._users);



            this.FilterCommand = new RelayCommand((a) =>
            {
                collectionView.Filter += OnFilter;
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
            if (user.FirstName.Equals("1"))
            {
                return true;
            }
            return false;
        }
    }
}
