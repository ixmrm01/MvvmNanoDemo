namespace MvvmNanoDemo

open Xamarin.Forms.Xaml
open MvvmNano.Forms

type ClubPage() =
    inherit MvvmNanoContentPage<ClubViewModel>()
    let _ = base.LoadFromXaml(typeof<ClubPage>)
