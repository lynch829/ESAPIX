﻿#region

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using ESAPIX.Helpers;
using ESAPIX.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;

#endregion

namespace ESAPIX.AppKit
{
    public class ScriptBootstrapper<T> : UnityBootstrapper where T : Window
    {
        private readonly IEventAggregator _ea;
        private readonly DispatcherFrame _frame;

        //private EventAggregator _ea;
        private readonly IScriptContext _sc;

        public Window _vmsWindow;

        public ScriptBootstrapper(PluginContext ctx, DispatcherFrame frame)
        {
            XamlAssemblyLoader.LoadAssemblies();
            _sc = ctx;
            _ea = new EventAggregator();
            _frame = frame;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<T>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterInstance(_sc);
            Container.RegisterInstance(_ea);
            Container.RegisterInstance(Container);
        }

        protected override void InitializeShell()
        {
            var shell = (Window) Shell;
            shell.ShowDialog();
            _frame.Continue = false;
        }

        public void Run(Func<Window> getSplash = null)
        {
            var ui = new Thread(() =>
            {
                if (getSplash != null) getSplash().ShowDialog();
                base.Run();
            });
            ui.SetApartmentState(ApartmentState.STA);
            ui.Start();
        }
    }
}