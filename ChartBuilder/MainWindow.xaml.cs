using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DronovsCharts.Analyze;
using DronovsCharts.Visualize;
using Microsoft.Win32;

namespace ChartBuilder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            XSource.AppendText("Paste your code here!");
            
        }

        string GetString(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        string Select(RichTextBox rtb, int index, int length)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            if (textRange.Text.Length >= (index + length))
            {
                TextPointer start = textRange.Start.GetPositionAtOffset(index, LogicalDirection.Forward);
                TextPointer end = textRange.Start.GetPositionAtOffset(index + length, LogicalDirection.Backward);
                rtb.Selection.Select(start, end);
            }
            return rtb.Selection.Text;
        } 

        private void XBuild_OnClick(object sender, RoutedEventArgs e)
        {
            CPPFileAnalyzer analyzer;
            try
            {
                analyzer = new CPPFileAnalyzer(GetString(XSource));
            }
            catch
            {
                MessageBox.Show("Error parsing code! Please check your code before building chart!", "CChart error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Visualizer visualizer = new Visualizer(analyzer.Result);
                SaveFileDialog sfd=new SaveFileDialog();
                sfd.DefaultExt = ".png";
                sfd.Filter = "Images (.png)|*.png"; 
                if (sfd.ShowDialog().Value)
                {
                    visualizer.Image.Save(sfd.FileName);
                }

            }
            catch 
            {
                MessageBox.Show("Error building chart!", "CChart error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool first = true;
        private void XSource_OnGotFocus(object sender, RoutedEventArgs e)
        {
           if(first) XSource.Document.Blocks.Clear();
        }
    }
}
