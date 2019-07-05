using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace TreeDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //for Revit api
            //var loc = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Assembly.LoadFrom($"{loc}/MahApps.Metro.dll");
            //Assembly.LoadFrom($"{loc}/ControlzEx.dll");
            //Assembly.LoadFrom($"{loc}/TreeListView.dll");

            var res = Application.LoadComponent(new Uri("/TreeDataGrid;component/Resources/Dictionary1.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(res);

            InitializeComponent();

            trv.ItemsSource = Enumerable.Range(0, 10)
                .Select(c => new TreeData
                {
                    Name = c.ToString(),
                    Children = Enumerable.Range(0, 3)
                    .Select(v => new TreeData
                    {
                        Name = $"{c}-{v}"
                    })
                });
        }
    }
    public class TreeData
    {
        public string Name { get; set; }
        public string Category { get; set; } = "Cat";
        public string Description { get; set; } = "Empty";
        public string IsVisible { get; set; }

        public IEnumerable<TreeData> Children { get; set; }
    }
}
