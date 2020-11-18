module KindergartenGarden

// TODO: define the Plant type

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets

let characterToPlant (character: string) =
    match character with
    | "R" -> Radishes
    | "C" -> Clover
    | "G" -> Grass
    | "V" -> Violets

let students =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ilena"
      "Joseph"
      "Kincaid"
      "Larry" ]


let plants (diagram: string) (student: string): (Plant list) =

    let studentIndex =
        List.findIndex (fun x -> x = student) students

    let answer =
        diagram.Split '\n'
        |> Seq.map (fun x -> x.Substring(studentIndex * 2, 2))
        |> Seq.reduce (+)
        |> Seq.map (fun c -> c.ToString() |> characterToPlant)

    answer |> List.ofSeq
