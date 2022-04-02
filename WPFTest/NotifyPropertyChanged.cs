using System.ComponentModel; 

namespace WPFTest {
  public abstract class NotifyPropertyChanged : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string property) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
  }
}
