module Common.ConsoleUtil

open System

let writeline (str: string) = Console.WriteLine(str)
let writeEmptyLine() = Console.WriteLine()
let write (str: string) = Console.Write(str)
let writelineColor (str:string) color =
    Console.ForegroundColor <- color; writeline str; Console.ResetColor()
let writelineRed (str: string) = writelineColor str ConsoleColor.Red
let writelinePurple (str:string) = writelineColor str ConsoleColor.DarkMagenta