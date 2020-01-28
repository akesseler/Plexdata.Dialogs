using Plexdata.Dialogs;
using System;
using System.Windows;

namespace Plexdata.Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnShowMessageDialog(Object sender, RoutedEventArgs args)
        {
            String message = @"
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
".Replace(Environment.NewLine, String.Empty);

            DialogBox.Show(this, message);

        }
    }
}
