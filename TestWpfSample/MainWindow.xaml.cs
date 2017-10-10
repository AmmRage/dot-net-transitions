using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace TestWpfSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Frame> frameDic = new Dictionary<string, Frame>();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void LoadFramesFromResource()
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType.Name == "Page"))
            {
                this.comboBoxTransTypes.Items.Add(t.Name);
                var f = new Frame
                {
                    Source = new Uri(string.Format("./Pages/{0}.xaml", t.Name), UriKind.RelativeOrAbsolute),                    

                    Margin = new Thickness(0, 50, 0, 0),
                    Width = this.Grd.ActualWidth,
                };
                this.frameDic.Add(t.Name, f);
            }
            this.comboBoxTransTypes.SelectedIndex = 0;
            this.stackPanel.Children.Add(this.frameDic[this.comboBoxTransTypes.SelectedValue.ToString()]);
        }

        private void ButtonLoadPages_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFramesFromResource();
        }

        private void comboBoxTransTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.stackPanel.Children.Add(this.frameDic[this.comboBoxTransTypes.SelectedValue.ToString()]);
            this.stackPanel.Children.RemoveAt(0);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.stackPanel.Children.Count != 0)
            {
                foreach (Frame f in this.frameDic.Values)
                {
                    f.Width = Grd.ActualWidth;
                }
            }
        }
    }
}
