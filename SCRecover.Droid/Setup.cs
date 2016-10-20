using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using SCRecover.Core.Interfaces;
using SCRecover.Droid.Database;
using Microsoft.WindowsAzure.MobileServices;
using SCRecover.Core.Database;
using SCRecover.Droid.Services;

namespace SCRecover.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<IProgressDialogService, ProgressDialogService>();
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<ISavedClaimsDatabase, SavedClaimsDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<IProvidersDatabase, ProvidersDatabase>();

            base.InitializeFirstChance();
        }

    }
}
