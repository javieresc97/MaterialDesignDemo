using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MaterialDesignDemo.Droid
{
    [Activity(Label = "SearchActivity", Theme = "@style/DemoTheme")]
    public class SearchActivity : AppCompatActivity
    {
        EditText cajaBusqueda;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            var toolbar = FindViewById<Toolbar>(Resource.Id.searchToolBar);
            SetSupportActionBar(toolbar);

            //  Muestra la flecha hacia atrás en el toolbar
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //  Para jugar con el texto escrito
            cajaBusqueda = FindViewById<EditText>(Resource.Id.searchBox);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //  Si presiona "atrás", vuelve al activity anterior
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}