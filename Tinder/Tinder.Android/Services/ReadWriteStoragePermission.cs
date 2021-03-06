using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tinder.Droid.Services
{
    public class ReadWriteStoragePermission : Xamarin.Essentials.Permissions.BasePlatformPermission, IReadWritePermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
    {
        (Android.Manifest.Permission.ReadExternalStorage, true),
        (Android.Manifest.Permission.WriteExternalStorage, true)
    }.ToArray();
    }
}