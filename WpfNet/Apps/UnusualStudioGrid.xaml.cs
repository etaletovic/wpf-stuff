using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;

namespace WpfNet.Apps
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UnusualStudioGrid : UserControl
    {
        ColumnDefinition column1CloneForLayer0;
        ColumnDefinition column2CloneForLayer0;
        ColumnDefinition column2CloneForLayer1;

        public UnusualStudioGrid()
        {
            InitializeComponent();

            // Initialize dummy columns used when docking

            column1CloneForLayer0 = new ColumnDefinition();
            column1CloneForLayer0.SharedSizeGroup = "column1";

            column2CloneForLayer0 = new ColumnDefinition();
            column2CloneForLayer0.SharedSizeGroup = "column2";

            column2CloneForLayer1 = new ColumnDefinition();
            column2CloneForLayer1.SharedSizeGroup = "column2";
        }

        private void pane1Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            layer1.Visibility = Visibility.Visible;

            Grid.SetZIndex(layer1, 1);
            Grid.SetZIndex(layer2, 0);

            if (pane2Button.Visibility == Visibility.Visible)
                layer2.Visibility = Visibility.Collapsed;

        }

        private void pane2Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            layer2.Visibility = Visibility.Visible;

            Grid.SetZIndex(layer1, 0);
            Grid.SetZIndex(layer2, 1);

            if (pane1Button.Visibility == Visibility.Visible)
                layer1.Visibility = Visibility.Collapsed;
        }

        private void layer0_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (pane1Button.Visibility == Visibility.Visible)
                layer1.Visibility = Visibility.Collapsed;
            if (pane2Button.Visibility == Visibility.Visible)
                layer2.Visibility = Visibility.Collapsed;
        }
        private void pane1Pin_Click(object sender, RoutedEventArgs e)
        {
            if (pane1Button.Visibility == Visibility.Collapsed)
            {
                UndockPane(1);
            }
            else
            {
                DockPanel(1);
            }
        }

        private void DockPanel(int paneNumber)
        {
            if (paneNumber == 1)
            {
                pane1Button.Visibility = Visibility.Collapsed;
                pane1Pin.Content = "X";
                
                // Add cloned column to layer 0
                layer0.ColumnDefinitions.Add(column1CloneForLayer0);

                // Add the cloned column to layer 1 but only if pane 2 is docked

                if (pane2Button.Visibility == Visibility.Collapsed)
                    layer1.ColumnDefinitions.Add(column2CloneForLayer1);
            }
            else if (paneNumber == 2)
            {
                pane2Button.Visibility = Visibility.Collapsed;
                pane2Pin.Content = "X";

                //Add the cloned column to layer 0
                layer0.ColumnDefinitions.Add(column2CloneForLayer0);

                // Add the cloned column to layer 1, but only if pane 1 is docked
                if (pane1Button.Visibility == Visibility.Collapsed)
                    layer1.ColumnDefinitions.Add(column2CloneForLayer1);

            }
        }

        private void UndockPane(int paneNumber)
        {
            if (paneNumber == 1)
            {
                //layer1.Visibility = Visibility.Collapsed;
                pane1Button.Visibility = Visibility.Visible;
                pane1Pin.Content = "O";

                // Remove te cloned clumns from layer 0 and 1
                layer0.ColumnDefinitions.Remove(column1CloneForLayer0);
                layer1.ColumnDefinitions.Remove(column2CloneForLayer1);
            }
            else if (paneNumber == 2)
            {
                //layer2.Visibility = Visibility.Collapsed;
                pane2Button.Visibility = Visibility.Visible;
                pane2Pin.Content = "O";
                // Remove the cloned columns from layers 0 and 1
                layer0.ColumnDefinitions.Remove(column2CloneForLayer0);
                layer1.ColumnDefinitions.Remove(column2CloneForLayer1);
            }
        }

        private void pane2Pin_Click(object sender, RoutedEventArgs e)
        {

            if (pane2Button.Visibility == Visibility.Collapsed)
            {
                UndockPane(2);
            }
            else
            {
                DockPanel(2);
            }
        }

        private void pane1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (pane2Button.Visibility == Visibility.Visible)
            {
                layer2.Visibility = Visibility.Collapsed;
            }
        }

        private void pane2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (pane1Button.Visibility == Visibility.Visible)
            {
                layer1.Visibility = Visibility.Collapsed;
            }
        }
    }
}
