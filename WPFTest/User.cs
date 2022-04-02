namespace WPFTest {
  public class User : NotifyPropertyChanged {

    private string _firstName;
    public string FirstName {
      get => this._firstName;
      set {
        this._firstName = value;
        OnPropertyChanged(nameof(this.FirstName));
      }
    }

  }
}
