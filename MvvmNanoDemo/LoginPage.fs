namespace MvvmNanoDemo

open Xamarin.Forms
open MvvmNano.Forms

type LoginPage() as this =
    inherit MvvmNanoContentPage<LoginViewModel>()

    do
        this.Title <- "Login"
        this.Padding <- new Thickness(60.0)

        let nameEntry = new Entry()
        nameEntry.Placeholder <- "Your name"

        let passwordEntry = new Entry()
        passwordEntry.Placeholder <- "Your password"
        passwordEntry.IsPassword <- true

        let loginButton = new Button()
        loginButton.Text <- "Log in"

        let aboutButton = new Button()
        aboutButton.Text <- "About this App"

        this.BindToViewModel(nameEntry, Entry.TextProperty, (fun x -> x.Username :> obj))
        this.BindToViewModel(passwordEntry, Entry.TextProperty, (fun x -> x.Password :> obj))

        this.BindToViewModel(loginButton, Button.CommandProperty, (fun x -> x.LogInCommand :> obj))
        this.BindToViewModel(loginButton, VisualElement.IsEnabledProperty, (fun x -> x.IsFormValid :> obj))

        this.BindToViewModel(aboutButton, Button.CommandProperty, (fun x -> x.ShowAboutCommand :> obj))

        let stackLayout = new StackLayout()
        stackLayout.Children.Add(nameEntry)
        stackLayout.Children.Add(passwordEntry)
        stackLayout.Children.Add(loginButton)
        stackLayout.Children.Add(aboutButton)

        this.Content <- stackLayout
