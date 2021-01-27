using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static TestTask.Core.Services.Enums;

namespace TestTask.Core.Converters
{
    public class PriorityToColorValueConverter : MvxColorValueConverter<Priority>
    {
        protected override MvxColor Convert(Priority value, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Priority.Low:
                    return new MvxColor(121, 196, 69);
                case Priority.Medium:
                    return new MvxColor(247, 148, 22);
                case Priority.Top:
                    return new MvxColor(255, 0, 0);
                default:
                    return new MvxColor(121, 196, 69);
            }
        }
    }
}
