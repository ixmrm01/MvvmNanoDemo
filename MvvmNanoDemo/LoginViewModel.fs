namespace MvvmNanoDemo

open System
open MvvmNano

type LoginViewModel() =
    inherit MvvmNanoViewModel()

    let mutable _username = ""
    let mutable _password = ""

    member this.Username
        with get() =
            _username
        and set value =
            _username <- value
            this.NotifyPropertyChanged()
            this.NotifyPropertyChanged("IsFormValid")

    member this.Password
        with get() =
            _password
        and set value =
            _password <- value
            this.NotifyPropertyChanged()
            this.NotifyPropertyChanged("IsFormValid")

    member this.IsFormValid
        with get() =
            match (String.IsNullOrEmpty(_username), String.IsNullOrEmpty(_password)) with
            | (false, false) -> true
            | _ -> false

    member this.LogIn =
        match this.IsFormValid with
        | true ->
            this.NavigateToAsync<WelcomeViewModel, User>(new User(this.Username)) |> Async.AwaitTask |> ignore
        | _ -> ()

    member this.LogInCommand
        with get() =
            new MvvmNanoCommand(fun _ -> this.LogIn)

    member this.ShowAbout =
        this.NavigateTo<AboutViewModel>()

    member this.ShowAboutCommand
        with get() =
            new MvvmNanoCommand(fun _ -> this.ShowAbout)
