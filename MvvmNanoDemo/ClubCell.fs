namespace MvvmNanoDemo

open Xamarin.Forms

type ClubCell() =
    inherit TextCell()

    override this.OnBindingContextChanged() =
        base.OnBindingContextChanged()

        let club = (this.BindingContext :?> Club)

        this.Text <- club.Name
        this.Detail <- club.Country
