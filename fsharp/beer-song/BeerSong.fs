module BeerSong

(*
No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.

*)

let defaultNumberOfBottles = 99

let reciteForNone totalBottles =
    [ "No more bottles of beer on the wall, no more bottles of beer."
      sprintf "Go to the store and buy some more, %d bottles of beer on the wall." totalBottles ]

let reciteForOne =
    [ "1 bottle of beer on the wall, 1 bottle of beer."
      "Take it down and pass it around, no more bottles of beer on the wall." ]


let pluraliseBottle amount =
    match amount with
    | 1 -> "bottle"
    | _ when amount > 1 -> "bottles"

let reciteForX bottleNumber =
    let newBottleNumber = bottleNumber - 1

    [ sprintf "%d bottles of beer on the wall, %d bottles of beer." bottleNumber bottleNumber
      sprintf
          "Take one down and pass it around, %d %s of beer on the wall."
          newBottleNumber
          (pluraliseBottle newBottleNumber) ]

let _rectite (bottleNumber: int) (totalBottles: int) =
    match (bottleNumber, totalBottles) with
    | (0, _) -> reciteForNone defaultNumberOfBottles
    | (1, _) -> reciteForOne
    | (bottleNumber, _) -> reciteForX bottleNumber

let recite (totalBottles: int) (takeDown: int) =
    let final = (totalBottles - takeDown) + 1

    [ totalBottles .. -1 .. final ]
    |> List.map (fun bottleNumber -> _rectite bottleNumber totalBottles)
    |> List.reduce (fun x y -> x @ [ "" ] @ y)
