module Quiz.TextToKeyboard


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
    | '7' -> Ck ck.D7
    | ',' -> Ck ck.OemComma
    | 'r' -> Ck ck.R
    | _ -> Ck ck.D8

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


let (|CtrlCmd|OneKeyCmd|) (str: string) = if str.Contains("ctrl-") then CtrlCmd else OneKeyCmd

let toKeyboardFormat str =
    match str with
    | CtrlCmd -> [str |> mapControlCommand]
    | OneKeyCmd -> str |> Seq.map mapKeyboardChar |> Seq.toList

