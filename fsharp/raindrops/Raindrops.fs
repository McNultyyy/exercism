module Raindrops

let positiveNumbers = Seq.unfold (fun n -> Some(n, n + 1)) 0

let isFactorOf (a: int) (b: int) = b % a = 0


let factorsOf n =
    [ 1 .. n - 1 ]
    |> List.map (fun x -> isFactorOf n x)

let dropMap =
    Map
        .empty
        .Add(3, "Pling")
        .Add(5, "Plong")
        .Add(7, "Plang")

let convert (number: int): string = ""


// todo
(*
let convert (number: int): string =
    dropMap
    |> Map.toSeq
    |> Seq.map fst
    |> factorsOf
*)
