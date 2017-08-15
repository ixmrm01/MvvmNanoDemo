namespace MvvmNanoDemo

open MvvmNano.Forms

type DemoPresenter(app) =
    inherit MvvmNanoFormsPresenter(app)

    override this.OpenPageAsync(page) =
        match page with
        | :? AboutPage ->
            this.CurrentPage.Navigation.PushModalAsync(new MvvmNanoNavigationPage(page))
        | :? WelcomePage ->
            this.Application.MainPage <- new MvvmNanoNavigationPage(page)
            this.CurrentPage.Navigation.PopToRootAsync(false)
        | _ ->
            base.OpenPageAsync(page)
