namespace MvvmNanoDemo

open Xamarin.Forms
open MvvmNano.Forms

type AboutPage() as this =
    inherit MvvmNanoContentPage<AboutViewModel>()

    do
        this.Title <- "About this App"
        this.Padding <- new Thickness(10.0)

        let stackLayout = new StackLayout()

        let label = new Label()
        label.Text <- "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet."

        stackLayout.Children.Add(label)

        this.Content <- stackLayout

        let _doneButton = new ToolbarItem()
        _doneButton.Text <- "Done"
        _doneButton.Clicked.Add(fun e -> this.doneAction)

        this.ToolbarItems.Add(_doneButton)

    member this.doneAction =
        this.Navigation.PopAsync() |> Async.AwaitTask |> ignore

    override this.Dispose() =
        base.Dispose()
