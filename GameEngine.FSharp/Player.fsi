﻿namespace GameEngine.FSharp

open System
open GameEngine.Common

type PlayerStatus =
    | ItIsYourTurn of int list
    | PlayerMadeChoice of TileType * int * bool
    | NoMoves   
    | GameOver  
    | GameStarted of TileType * BoardSerializable
    | BoardHasChanged of TileColor list

[<Sealed>]
type Player =
    member IdentifiesWith : Guid -> bool
    member GetId : unit -> Guid 
    interface System.IComparable
    override Equals : yobj:obj -> bool
    override GetHashCode : unit -> int


[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Player = 
    val Create          : System.Guid -> (PlayerStatus -> unit) -> Player
    val SendMessage     : Player -> PlayerStatus -> unit
