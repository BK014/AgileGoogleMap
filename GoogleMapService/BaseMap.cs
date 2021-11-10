using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using System;

namespace GoogleMapService
{
    [Activity(Label = "BaseMap")]
    public class BaseMap : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        Button btnback;



        public void OnMapReady(GoogleMap googleMap)//HERE WE CAN CHANGE THE LIVE LOCATION OF THE MAP//
        {
            this.GMap = googleMap;
            LatLng latlng = new LatLng(Convert.ToDouble(-37.769503), Convert.ToDouble(175.277737));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 8);
            GMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Hamilton, New Zealand");
            GMap.AddMarker(options);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_base);
            btnback = FindViewById<Button>(Resource.Id.btnback);
            btnback.Click += (object sender, EventArgs e) =>
            {
                btnback_Click(sender, e);
            };

            SetUpMap();
        }
        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

    }
}
