module vim.MonkeyCommand

open NUnit.Framework
open Swensen.Unquote
open System
open Commands

let readKey() = Console.ReadKey()

let isControlModifier (keyInfo: ConsoleKeyInfo) =
    (keyInfo.Modifiers &&& ConsoleModifiers.Control) = ConsoleModifiers.Control
let isShiftModifier (keyInfo: ConsoleKeyInfo) =
    (keyInfo.Modifiers &&& ConsoleModifiers.Shift) = ConsoleModifiers.Shift

let isModifier (keyInfo: ConsoleKeyInfo) =
    isControlModifier keyInfo || isShiftModifier keyInfo

let getModifier (keyInfo: ConsoleKeyInfo) =
    match keyInfo with
    | k when isShiftModifier k -> ConsoleModifiers.Shift
    | _ -> ConsoleModifiers.Control

let readKeys (readKey: unit -> ConsoleKeyInfo) =
    let rec getEnteredKeys keys =
        let key = readKey()
        match key with
        | k when isModifier k ->
            let modifier = getModifier k
            getEnteredKeys (keys@[Cm (modifier, key.Key)])
        | k when k.Key <> ConsoleKey.Enter ->
            getEnteredKeys (keys@[Ck key.Key])
        | _ -> keys

    getEnteredKeys []

let readKeysUntilEnter'() = readKeys readKey

let ckToString ck =
    match ck with
    | ck.Oem1 -> ":"
    | ck.Oem2 -> "/"
    | _ -> sprintf "%A" ck

let cmToString (cm, ck) =
    match (cm, ck) with
    | (cm.Shift, ck.D1) -> "!"
    | (cm.Shift, ck.D4) -> "$"
    | (cm.Shift, ck.D5) -> "%"
    | _ -> "$"

let printCkm (keyValue: ckm) =
    match keyValue with
    | Ck k -> sprintf "%s " (ckToString k)
    | Cm (f, s) -> sprintf "%A-%A " f (ckToString s)

let printCkmList (li : ckm list)=
    li |> Seq.fold (fun x y -> x + (printCkm y) ) String.Empty





