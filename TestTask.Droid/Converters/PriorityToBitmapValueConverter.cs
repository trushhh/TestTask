using Android.Graphics;
using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static TestTask.Core.Services.Enums;

namespace TestTask.Core.Converters
{
    public class PriorityToBitmapValueConverter : MvxValueConverter<Priority>
    {
        protected override object Convert(Priority value, Type targetType, object parameter, CultureInfo culture)
        {

            Bitmap bitmap = Bitmap.CreateBitmap(50,50, Bitmap.Config.Argb8888);
            using (Canvas canvas = new Canvas(bitmap))
            {
                canvas.DrawColor(GetColor(value));
            }
            return bitmap;
        }
        private Color GetColor(Priority priority)
        {
            switch (priority)
            {
                case Priority.Low:
                    return new Color(121, 196, 69);
                case Priority.Medium:
                    return new Color(247, 148, 22);
                case Priority.Top:
                    return new Color(255, 0, 0);
                default:
                    return new Color(247, 148, 22);
            }
        }
    }
}
