namespace MvvmNanoDemo

open System.Collections.Generic
open MvvmNano

type WelcomeViewModel(clubs: IClubRepository) =
    inherit MvvmNanoViewModel<User>()

    let mutable _username = ""
    let mutable _clubs = new List<Club>()

    do
        _clubs <- clubs.All()

    member this.Username
        with get() =
            _username
        and set value =
            _username <- value
            this.NotifyPropertyChanged()

    member this.Clubs
        with get() =
            _clubs
        and set value =
            _clubs <- value

    member this.ShowClub(club) =
        this.NavigateToAsync<ClubViewModel, Club>(club) |> Async.AwaitTask |> ignore

    member this.ShowClubCommand
        with get() =
            new MvvmNanoCommand<Club>(fun e -> this.ShowClub(e))

    override this.Initialize(parameter) =
        this.Username <- parameter.Name
