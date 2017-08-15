namespace MvvmNanoDemo

open MvvmNano

type ClubViewModel() =
    inherit MvvmNanoViewModel<Club>()

    let mutable _name = ""
    let mutable _country = ""

    member this.Name
        with get() =
            _name
        and set value =
            _name <- value
            this.NotifyPropertyChanged()

    member this.Country
        with get() =
            _country
        and set value =
            _country <- value
            this.NotifyPropertyChanged()

    override this.Initialize(parameter) =
        this.Name <- parameter.Name
        this.Country <- parameter.Country
