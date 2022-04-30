using System;
using System.IO;
using System.Windows;

namespace Crc32_Checker
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

        private void FileDropGrid_Drop(object sender, DragEventArgs e)
        {
            Crc32OutputTextBox.Text = "";

            var crc32 = new Crc32();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string file = files[0];

                var hash = String.Empty;
                using (var fs = File.Open(file, FileMode.Open))
                    foreach (byte b in crc32.ComputeHash(fs)) 
                        hash += b.ToString("x2").ToLower();

                Crc32OutputTextBox.Text = hash;
                Clipboard.SetText(hash);
            }
        }
    }
}
