namespace MvvmNanoDemo

open System
open Xamarin.Forms
open MvvmNano.Forms

type TitleConverter() =
    interface IValueConverter with

        member this.Convert(value, targetType, parameter, culture) =
            // value.ToString() :> obj
            String.Format("Hi {0}!", value) :> obj

        member this.ConvertBack(value, targetType, parameter, culture) =
            raise (NotImplementedException())
            // new obj()


type WelcomePage() as this =
    inherit MvvmNanoContentPage<WelcomeViewModel>()

    let mutable _clubList = new ListView()

    do
        this.BindToViewModel(this, Page.TitleProperty, (fun x -> x.Username :> obj), converter = (new TitleConverter()))

        NavigationPage.SetBackButtonTitle(this, "")

    member this.ClubSelected(e: SelectedItemChangedEventArgs) =
        match e.SelectedItem with
        | null -> ()
        | _ ->
            _clubList.SelectedItem <- null
            // this.ViewModel.ShowClubCommand.Execute(e.SelectedItem :?> Club)
            this.ViewModel.ShowClubCommand.Execute(e.SelectedItem)

    override this.OnViewModelSet() =
        base.OnViewModelSet()

        _clubList.ItemsSource <- this.ViewModel.Clubs
        _clubList.ItemTemplate <- (new DataTemplate(typeof<ClubCell>))
        _clubList.ItemSelected.Add(fun e -> this.ClubSelected(e))

        let stackLayout = new StackLayout()

        stackLayout.Children.Add(_clubList)

        this.Content <- stackLayout

    override this.Dispose() =
        base.Dispose()
