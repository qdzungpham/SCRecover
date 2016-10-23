using Android.App;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using MvvmCross.Droid.Views;
using SCRecover.Core.ViewModels;


namespace SCRecover.Droid.Views
{
    [Activity(Label = "Contact info", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ProviderMapView : MvxActivity, IOnMapReadyCallback

    {
        private delegate IOnMapReadyCallback OnMapReadyCallback();
        private GoogleMap map;
        
        ProviderMapViewModel vm;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ProviderMap);
            vm = ViewModel as ProviderMapViewModel;
            var mapFragment = FragmentManager.FindFragmentById(Resource.Id.map) as MapFragment;
            mapFragment.GetMapAsync(this);

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            AddWeatherPin();
            MoveToLocation();
            map.MyLocationEnabled = true;
            
        }

        private void MoveToLocation(float zoom = 18)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(vm.Provider.Location.Lat, vm.Provider.Location.Lng));
            builder.Zoom(zoom);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);
        }

        private void AddWeatherPin()
        {
            var markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(vm.Provider.Location.Lat, vm.Provider.Location.Lng));
            markerOptions.SetTitle(vm.Provider.Name);

            map.AddMarker(markerOptions);
        }
    }
}