using Marchand.Render;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

//[assembly: ExportRenderer(typeof(CustomMap),typeof(CustomMapRenderer))]
namespace Marchand.Render
{
 public class CustomMapRenderer//: MapRenderer
    {
        //private MapControl _NaviveMap;
        //private List<CustomPin> _customPins;
        //private XamarinMapOverlay _mapOverlay;

        //protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        //{
        //    base.OnElementChanged(e);
        //    if (e.OldElement !=null)
        //    {
        //        _NaviveMap.MapElementClick = OnElementClick;
        //        _NaviveMap.Children.Clear();
        //        _mapOverlay = null;
        //        _NaviveMap = null;
        //    }
        //    if (e.NewElement != null)
        //    {

        //        var formsMap = (CustomMap)e.NewElement;
        //        _NaviveMap = Control as MapControl;
        //        _customPins = formsMap.CustomPins;

        //        _NaviveMap.Children.Clear();
        //        _NaviveMap.MapElementClick += OnMapElementClick;

        //        foreach (var pin in _customPins)
        //        {
        //            var snPosition = new BasicGeoposition { Latitude = pin.Pin.Position.Latitude, Logitude = pin.Pin.Position.Latitude };

        //            var snPoint = new Geopoint(snPosition);

        //            var mapIcon =new MapIcon
        //            {
        //                Image= RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///pin.png")),CollisionBehaviorDesired=MapElementCollisionBehavior.RemainVisible,Location=snPoint,
        //                NormalizedAnchorPoint=new Windows.Foundation.Point(0.5,1.0)

        //            }
        //        }
        //    }

        //}
    }

}
