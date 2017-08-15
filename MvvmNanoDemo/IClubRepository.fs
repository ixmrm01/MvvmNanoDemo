namespace MvvmNanoDemo

open System.Collections.Generic

type IClubRepository =
    abstract member All: unit -> List<Club>
