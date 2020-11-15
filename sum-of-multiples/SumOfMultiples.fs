module SumOfMultiples

let isMultipleOf (x: int) (n: int) =
    match (x, n) with
    | (0, 0) -> true
    | (x, 0) when x > 0 -> false
    | (_, 1) -> true
    | (x, n) -> x % n = 0

let isListMultipleOf (xs: int list) (m: int) =
    List.exists (fun x -> isMultipleOf m x) xs

let sum (numbers: int list) (upperBound: int): int =
    [ 1 .. upperBound - 1 ]
    |> List.filter (fun x -> isListMultipleOf numbers x)
    |> List.distinct
    |> List.sum
