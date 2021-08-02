using AddNewItem_Template.Shared;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace AddInterfaceVSIX
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(AddInterfaceVSIXPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(AddItemToolWindow))]
    public sealed class AddInterfaceVSIXPackage : AsyncPackage
    {
        /// <summary>
        /// AddInterfaceVSIXPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "b77eddb8-0283-454d-8620-5e3efd435a80";

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await AddItemToolWindowCommand.InitializeAsync(this);
            AddItemToolWindow.dte2 = GetGlobalService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as DTE2;
        }

        #endregion
    }
}
