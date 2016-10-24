module vim.Commands

open System
type ck = ConsoleKey
type cm = ConsoleModifiers
type ckm = | Ck of ck | Cm of cm * ck
let mapKeyboardChar ch =
    match ch with
    | 'h' -> Ck ck.H
    | 'l' -> Ck ck.L
    | ':' -> Cm (cm.Shift, ck.Oem1)
    | 's' -> Ck ck.S
    | 'x' -> Ck ck.X
    | '/' -> Ck ck.Oem2
    | 'y' -> Ck ck.Y
    | 'w' -> Ck ck.W  
    | 'q' -> Ck ck.Q
    | '!' -> Cm (cm.Shift, ck.D1)
    | 'e' -> Ck ck.E
    | ' ' -> Ck ck.Spacebar
    | 'f' -> Ck ck.F
    | '%' -> Cm (cm.Shift, ck.D5)
    | 'g' -> Ck ck.G
    | 'n' -> Ck ck.N
    | 'b' -> Ck ck.B
    | 'j' -> Ck ck.J
    | 'k' -> Ck ck.K
    | 'A' -> Cm (cm.Shift, ck.A)
    | 'd' -> Ck ck.D
    | '$' -> Cm (cm.Shift, ck.D4)
    | '0' -> Ck ck.D0
    | 'u' -> Ck ck.U
    | 'U' -> Cm (cm.Shift, ck.U)
    | 'p' -> Ck ck.P
    | '3' -> Ck ck.D3
    | 'c' -> Ck ck.C
    | '?' -> Cm (cm.Shift, ck.Oem2)
    | 'o' -> Ck ck.O
    | 'i' -> Ck ck.I
    | '4' -> Ck ck.D4
    | _ -> failwith "to do"

let mapControlCommand str =
    match str with 
    | "ctrl-r" -> Cm (cm.Control, ck.R)
    | "ctrl-f" -> Cm (cm.Control, ck.F)
    | "ctrl-b" -> Cm (cm.Control, ck.B)
    | "ctrl-e" -> Cm (cm.Control, ck.E)
    | "ctrl-v" -> Cm (cm.Control, ck.V)
    | "ctrl-o" -> Cm (cm.Control, ck.O)
    | "ctrl-i" -> Cm (cm.Control, ck.I)
    | "ctrl-g" -> Cm (cm.Control, ck.G)
    | _ -> failwith "to do"
let isCtrlCmd (str:string) = str.Contains("ctrl-")
let (|CtrlCmd|OneKeyCmd|) str = if isCtrlCmd str then CtrlCmd else OneKeyCmd
let mapCmd str =
    match str with
    | CtrlCmd -> [str |> mapControlCommand]
    | OneKeyCmd -> str |> Seq.map mapKeyboardChar |> Seq.toList
let getCommands() =
    [|
    "h", "go right"
    "l", "go left"
    ":s/x/y", "replace one accurance in line"
    ":s/x/y/g", "replace all x to y in line"
    ":w", "save"
    ":q", "quit"
    ":q!", "quit without saving"
    ":e f", "open file f"
    ":%s/x/y/g", "replace x by y filewide"
    ":h", "help"
    ":new", "new file"
    "ctrl-r", "redo of redo"
    "ctrl-f", "page down"
    "ctrl-b", "page up"
    "ctrl-e", "scroll line down"
    "ctrl-v", "block visual mode"
    "j", "go down"
    "k", "go up"
    "x", "remove char"
    "A", "insert at the end of line"
    "dw", "delete to beginnig of next word"
    "d$", "delete to end of line"
    "de", "delete to end of current word"
    "w", "move to beginning of next word"
    "e", "move to end of cuurrent word"
    "0", "move to beginnig of the current line"
    "dd", "delete line to registry"
    "u", "redo last command"
    "U", "redo changes in current line"
    "p", "paste after cursor/on line below cursor"
    "dd3jp", "delete line, move 3 lines down, paste below current line"
    "r", "replace character under cursor"
    "ce", "replace to end of word"
    "c$", "change to end of line"
    "ctrl-g", "show file status and location"
    "G", "go to end of file"
    "gg", "go to beginnig of file"
    "/x", "search forward for x"
    "/xn", "search forward for x and again search forward for x"
    "?x", "search for x backwards"
    "ctrl-o", "go back where you was"
    "ctrl-i", "go froward where you was"
    "%", "go to matching paranthesis"
    ":4,7s/x/y/gc", "change all accurance of x to y between line 4 and 7 and ask for confirmation"
    |]
