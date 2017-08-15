namespace MvvmNanoDemo

open System.Collections.Generic

type MockClubRepository() =
    interface IClubRepository with

        member this.All() =
            let list = new List<Club>()
            list.Add(new Club("FC Bayern München", "Germany"))
            list.Add(new Club("Borussia Dortmund", "Germany"))
            list.Add(new Club("Real Madrid", "Spain"))
            list.Add(new Club("FC Barcelona", "Spain"))
            list.Add(new Club("Manchester United", "England"))
            list
