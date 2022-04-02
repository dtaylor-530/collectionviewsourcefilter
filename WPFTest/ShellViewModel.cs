using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFTest {
  public class ShellViewModel : NotifyPropertyChanged {


    private ObservableCollection<User> _users;
    public ObservableCollection<User> Users {
      get => this._users;
      set {
        this._users = value;
        OnPropertyChanged(nameof(this.Users));
      }
    }

    private ICommand _filterCommand;
    public ICommand FilterCommand {
      get => this._filterCommand;
    }


    public ShellViewModel() {
      this._users = new ObservableCollection<User>();
      this._users.Add(new User() { FirstName = "1" });
      this._users.Add(new User() { FirstName = "2" });
      this._users.Add(new User() { FirstName = "3" });
      this._users.Add(new User() { FirstName = "4" });
      this._users.Add(new User() { FirstName = "5" });
    
      this._filterCommand = new RelayCommand((a) => {
        ICollectionView collectionView = CollectionViewSource.GetDefaultView(this._users);
        collectionView.Filter += OnFilter;
        collectionView.Refresh();
      }, e => true);
    }

    private bool OnFilter(object obj) {
      User user = (User)obj;
      if(user.FirstName.Equals("1")) {
        return true;
      }
      return false;
    }
  }
}
