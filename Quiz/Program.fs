module Quiz.Program

open TextToKeyboard
open KeyboardInput
open Common.ConsoleUtil
open QuizData

let askCommand ((answer, answerKeyboardFormat), (ask: string)) =
    ask |> writeline
    ">" |> write
    let givenAnswer = readKeysUntilEnter()
    () |> writeEmptyLine
    if givenAnswer <> answerKeyboardFormat then
        sprintf "expected: ( %s )" answer |> writelineRed
    "####################" |> writelinePurple

let getQuiz() = getQuizData() |> Array.map (fun (x, y) -> ((x, toKeyboardFormat x), y)) 

let randomQuizQuestion() =
   let rnd = System.Random()
   let cmds = getQuiz() 
   cmds.[rnd.Next(0, cmds.Length)]
   
[<EntryPoint>]
let main argv =
    Seq.initInfinite ( fun _ -> randomQuizQuestion() )
    |> Seq.iter askCommand
    System.Console.ReadKey() |> ignore
    0

