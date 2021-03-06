﻿using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Microsoft.Practices.Unity;
using QIQO.Business.Client.Core.UI;
using QIQO.Business.Client.Core;
using QIQO.Business.Client.Core.Infrastructure;
using QIQO.Common.Core.Logging;
using QIQO.Business.Module.Dashboard.Views;
using System;

namespace QIQO.Business.Module.Dashboard.ViewModels
{
    class DashboardRibbonViewModel : ViewModelBase, IRegionMemberLifetime
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator event_aggregator;
        private readonly IReportService _reportService;

        public DashboardRibbonViewModel()
        {
            event_aggregator = Unity.Container.Resolve<IEventAggregator>();
            _regionManager = Unity.Container.Resolve<IRegionManager>();
            _reportService = Unity.Container.Resolve<IReportService>();

            PrintCommand = new DelegateCommand(PrintSomething);
        }

        private void PrintSomething()
        {
            _reportService.ExecuteReport(Reports.OpenCompanyOrders);

        }

        public bool KeepAlive { get; } = false;

        public DelegateCommand PrintCommand { get; set; }

        private void DoNavigate(string view)
        {
            _regionManager.RequestNavigate(RegionNames.RibbonRegion, typeof(DashboardRibbonView).FullName);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.OpenOrderView);
        }

        private void NavigationComplete(NavigationResult result)
        {
            Log.Debug(result.Context.Uri.ToString());
        }
    }
}
