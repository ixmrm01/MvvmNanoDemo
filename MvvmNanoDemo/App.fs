namespace MvvmNanoDemo

open MvvmNano
open MvvmNano.Forms
open MvvmNano.Ninject

type App() =
    inherit MvvmNanoApplication()

    member this.SetUpDependencies =
        MvvmNanoIoC.Register<IClubRepository, MockClubRepository>()

    override this.OnStart() =
        base.OnStart()
        this.SetUpDependencies
        this.SetUpMainPage<LoginViewModel>()

    override this.SetUpPresenter() =
        MvvmNanoIoC.RegisterAsSingleton<IPresenter>(new DemoPresenter(this))

    override this.GetIoCAdapter() =
        new MvvmNanoNinjectAdapter() :> IMvvmNanoIoCAdapter
