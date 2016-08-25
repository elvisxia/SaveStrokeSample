using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SaveStrokeSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            myCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse;
            myCanvas.InkPresenter.UpdateDefaultDrawingAttributes(CreateInkDrawingAttributesCore(new SolidColorBrush(Windows.UI.Colors.Red), 2));
            //if the mainpage resource exists then load the container
            if (Application.Current.Resources.ContainsKey("mainpage"))
            {
                var resource = Application.Current.Resources["mainpage"];
                myCanvas.InkPresenter.StrokeContainer = (InkStrokeContainer)resource;
            }
        }


        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.Add(new KeyValuePair<object, object>("mainpage", myCanvas.InkPresenter.StrokeContainer));
        }

        private void myBtn2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageOne));
        }

        private InkDrawingAttributes CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
        {

            InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
            inkDrawingAttributes.PenTip = PenTipShape.Circle;
            inkDrawingAttributes.IgnorePressure = false;
            SolidColorBrush solidColorBrush = (SolidColorBrush)brush;

            if (solidColorBrush != null)
            {
                inkDrawingAttributes.Color = solidColorBrush.Color;
            }

            inkDrawingAttributes.Size = new Size(strokeWidth, 2.0f * strokeWidth);
            inkDrawingAttributes.PenTipTransform = System.Numerics.Matrix3x2.CreateRotation(45.0f);

            return inkDrawingAttributes;
        }
    }
}
