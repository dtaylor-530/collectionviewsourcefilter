using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTest {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {
    private void Application_Startup(object sender, StartupEventArgs e) {
      ShellView view = new ShellView();
      view.DataContext = new ShellViewModel();
      this.MainWindow = view;
      this.MainWindow.ShowDialog();
    }
  }
}
