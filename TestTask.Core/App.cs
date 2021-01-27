using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using TestTask.Core.ViewModels;

namespace TestTask.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<TicketsViewModel>();
        }
    }
}