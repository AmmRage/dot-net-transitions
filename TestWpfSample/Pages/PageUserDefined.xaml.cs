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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Transitions;

namespace TestWpfSample.Pages
{
    /// <summary>
    /// Interaction logic for PageUserDefined.xaml
    /// </summary>
    public partial class PageUserDefined : Page
    {
        private TransitionType_UserDefined transition;

        public PageUserDefined()
        {
            InitializeComponent();
            textBlockTransitionType.Text = this.Name;

            transition = new TransitionType_UserDefined(new List<TransitionElement>(new TransitionElement[]
            {
                new TransitionElement(20, 100, InterpolationMethod.Linear),
            }), 1000);
        }        

        private void buttonUserDefined_Click(object sender, RoutedEventArgs e)
        {
            Transition.run((sender as Button), "Margin.Left", 200, transition);
        }
    }
}
