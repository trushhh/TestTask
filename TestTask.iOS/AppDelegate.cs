using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace TestTask.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<Core.App>, Core.App>
    {
    }
}

