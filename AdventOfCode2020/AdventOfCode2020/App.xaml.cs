using AdventOfCode2020.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace AdventOfCode2020
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion("Day1Region", typeof(Day01.Views.Day1View));
            regionManager.RegisterViewWithRegion("Day2Region", typeof(Day02.Views.Day2View));
            regionManager.RegisterViewWithRegion("Day3Region", typeof(Day03.Views.Day3View));
            regionManager.RegisterViewWithRegion("Day4Region", typeof(Day04.Views.Day4View));
            regionManager.RegisterViewWithRegion("Day5Region", typeof(Day05.Views.Day5View));
            regionManager.RegisterViewWithRegion("Day6Region", typeof(Day06.Views.Day6View));
            regionManager.RegisterViewWithRegion("Day7Region", typeof(Day07.Views.Day7View));
            regionManager.RegisterViewWithRegion("Day8Region", typeof(Day08.Views.Day8View));
            regionManager.RegisterViewWithRegion("Day9Region", typeof(Day09.Views.Day9View));
        }
    }
}
