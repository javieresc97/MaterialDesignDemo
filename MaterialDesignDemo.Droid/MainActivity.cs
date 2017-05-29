using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace MaterialDesignDemo.Droid
{
    [Activity(Label = "MaterialDesignDemo.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/DemoTheme")]
    public class MainActivity : AppCompatActivity
    {
        FloatingActionButton fab;
        Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolBar);
            toolbar.Title = "Material Design App";
            SetSupportActionBar(toolbar);

            fab = FindViewById<FloatingActionButton>(Resource.Id.floatingActionButton1);
            fab.Click += Fab_Click;
        }

        private void Fab_Click(object sender, System.EventArgs e)
        {
            Snackbar
                .Make(fab, "¡Hola!", Snackbar.LengthShort)
                .SetAction("Clic aquí", (view) =>
                {
                    MostrarAlertaImportante();
                })
                .Show();
        }

        private void MostrarAlertaImportante()
        {
            var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            builder.SetTitle("Alerta importante")
                    .SetMessage("Esta es una alerta de Material Design. ¿Quieres acción?")
                    .SetPositiveButton("Sí", delegate
                    {
                        Toast.MakeText(this, "Acción realizada", ToastLength.Short).Show();
                    })
                    .SetNegativeButton("No", delegate { });

            builder.Create().Show();
        }

        #region Configuración de íconos en el menú
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //  Revisar Resources > menu > MainMenu
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //  Identifica qué icono del menú fue seleccionado
            switch (item.ItemId)
            {
                case Resource.Id.action_edit:
                    Toast.MakeText(this, "You pressed edit action!", ToastLength.Short).Show();
                    break;
                case Resource.Id.action_search:
                    StartActivity(typeof(SearchActivity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        #endregion
    }
}

