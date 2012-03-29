// Learn more about F# at http://fsharp.net

module Code

type Point = 
    | Zero
    | Fifteen
    | Thirty
    | Forty

type Player = 
    | A
    | B

type Scores =
    | Points of Point*Point
    | Deuce
    | Advantage of Player
    | Game of Player


let increment fromPoint =
    match fromPoint with
    | Zero -> Fifteen
    | Fifteen -> Thirty
    | Thirty -> Forty
    | Forty -> failwith "Can't score higher than 40"

let score currentScore player =
    match currentScore with
    | Points (Forty,Thirty) when player = B -> Deuce
    | Points (Thirty,Forty) when player = A -> Deuce
    | Points (a,b) when player= A -> Points (increment a,b)
    | Points (a,b) when player= B -> Points (a,increment b)
    | Deuce -> Advantage(player)
    | Advantage winner when player = winner  -> Game player
    | Advantage winner when player <> winner -> Deuce
    | Game winner -> Game winner
    | _ -> failwith "should not happen"
    
 
let playMatch whoScores  = whoScores |> Seq.scan score (Points(Zero,Zero))





