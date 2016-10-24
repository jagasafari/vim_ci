module Program

open vim
open MonkeyCommand
open Common.ConsoleUtil
open Commands

let askCommand (answer, (ask: string)) =
    ask |> writeline
    ">" |> write
    let givenAnswer = readKeysUntilEnter'()
    () |> writeEmptyLine
    let result = givenAnswer = answer
    if result |> not then
        sprintf "expected ( %s), but given ( %s)"
            (printCkmList answer) (printCkmList givenAnswer) |> writelineRed
    "####################" |> writelinePurple

let commands =
    let rnd = System.Random()
    let cmds = getCommands() |> Array.map (fun (x, y) -> (mapCmd x, y)) 
    let len = cmds.Length;
    Seq.initInfinite (fun _ -> cmds.[rnd.Next(0, len)])

[<EntryPoint>]
let main argv =
    commands |> Seq.iter askCommand
    System.Console.ReadKey() |> ignore
    0

