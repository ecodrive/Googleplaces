using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Gms.Location.Places.UI;
using Android.Gms.Common.Apis;
using Android.Gms.Location.Places;
using static Android.Gms.Common.Apis.GoogleApiClient;
using Android.Gms.Common;
using Android.Gms.Maps.Model;
using Android.Util;

namespace GooglePLaces
{
    [Activity(Label = "GooglePLaces", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity, IPlaceSelectionListener, IOnConnectionFailedListener
    {
       

        public void OnConnectionFailed(ConnectionResult result)
        {
            throw new NotImplementedException();
        }

        public void OnError(Statuses status)
        {
            Log.Info("xamarin", "An error occurred: " + status);
        }

        public void OnPlaceSelected(IPlace place)
        {
            Log.Info("xamarin", "Place: " + place.NameFormatted);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var mGoogleApiClient = new GoogleApiClient
                .Builder(this)
                .AddApi(PlacesClass.GEO_DATA_API)
                .AddApi(PlacesClass.PLACE_DETECTION_API)
                .EnableAutoManage(this, this)
                .Build();

            PlaceAutocompleteFragment autocompleteFragment = (PlaceAutocompleteFragment)FragmentManager.FindFragmentById(Resource.Id.place_autocomplete_fragment);

            autocompleteFragment.SetOnPlaceSelectedListener(this);

            autocompleteFragment.SetBoundsBias(new LatLngBounds(
                new LatLng(4.5931, -74.1552),
                new LatLng(4.6559, -74.0837)));

        }
    }
}

