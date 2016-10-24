module TestUtil.AssertUtil

open NUnit.Framework
open Swensen.Unquote

let assertThrows<'a when 'a :> exn> func =
    Assert.Throws<'a>(fun () -> func() ) |> ignore
let todo () = false =! true
