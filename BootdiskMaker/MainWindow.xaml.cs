using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BootdiskMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //build a list of USB drives currently in the machine
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && (drive.DriveType == DriveType.Removable))
                {
                    USB_DRV_LST.Items.Add(drive.Name);
                }
            }
        }

        //refresh button clicked so clear the list and rebuild it
        private void button_Click(object sender, RoutedEventArgs e)
        {
            USB_DRV_LST.Items.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && (drive.DriveType == DriveType.Removable))
                {
                    USB_DRV_LST.Items.Add(drive.Name);
                }
            }
        }

        private void Browse_BTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".ISO";
            dlg.Filter = "ISO Files (*.ISO)|";
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                System.Windows.MessageBox.Show(dlg.FileName);
                string filename = dlg.FileName;
                ISO_file.Text = filename;
            }
        }
    }

}

