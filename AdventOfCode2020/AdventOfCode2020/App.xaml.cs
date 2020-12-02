﻿using AdventOfCode2020.Views;
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
        }
    }
}
