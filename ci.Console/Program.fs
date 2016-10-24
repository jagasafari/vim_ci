open System
open System.Threading

[<EntryPoint>]
let main argv =
    let workingPath = @"c:\vim_ci"
    while true do
        let outputDataHandler() = ci.BuildOutput.OutputDataHandler() 
        Process.build (ProcStartInfo.defaultProcStartInfo workingPath) (outputDataHandler().handle)
        |> ignore
        Thread.Sleep 3000
    Console.ReadKey() |> ignore
    0
