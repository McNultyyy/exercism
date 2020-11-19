module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { direction: Direction
      position: Position }

type Action =
    | RotateLeft
    | RotateRight
    | Accelerate


let create direction position =
    { direction = direction
      position = position }




let turnLeft robot =
    let newDirection =
        match robot.direction with
        | North -> West
        | East -> North
        | South -> East
        | West -> South

    { robot with direction = newDirection }

let turnRight = turnLeft >> turnLeft >> turnLeft

let accelerate ({ direction = direction
                  position = (x, y) } as robot) =

    let newPosition =
        match direction with
        | North -> (x, y + 1)
        | East -> (x + 1, y)
        | South -> (x, y - 1)
        | West -> (x - 1, y)

    { robot with position = newPosition }

let toAction instruction =
    match instruction with
    | 'L' -> turnLeft
    | 'R' -> turnRight
    | 'A' -> accelerate

let move instructions robot =
    instructions
    |> Seq.map toAction
    |> Seq.fold (|>) robot
