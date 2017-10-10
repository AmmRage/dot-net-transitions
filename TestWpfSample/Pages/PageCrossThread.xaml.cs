using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Transitions;

namespace TestWpfSample.Pages
{
    /// <summary>
    /// Interaction logic for PageCrossThread.xaml
    /// </summary>
    public partial class PageCrossThread : Page
    {
        public PageCrossThread()
        {
            InitializeComponent();
            textBlockTransitionType.Text = this.Name;
        }

        private void buttonCrossThread_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Transition.run((sender as Button), "Margin.Left", 200, new TransitionType_Linear(1000));
            });
        }
    }
}
