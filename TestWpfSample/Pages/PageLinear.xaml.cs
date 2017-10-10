using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Transitions;

namespace TestWpfSample
{
    /// <summary>
    /// Interaction logic for PageLinear.xaml
    /// </summary>
    public partial class PageLinear : Page
    {
        public PageLinear()
        {
            InitializeComponent();
            textBlockTransitionType.Text = this.Name;
        }

        private void buttonLinear_Click(object sender, RoutedEventArgs e)
        {
            Transition.run(sender, "Margin.Left", 200, new TransitionType_Linear(1000));
        }
    }
}
