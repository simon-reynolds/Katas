namespace Katas

module Tennis =

    type Player =
        | One
        | Two

    type Points =
        | Love
        | Fifteen
        | Thirty
        | Forty

    type Score =
        | Point of (Points * Points)
        | Deuce
        | Advantage of Player
        | Win of Player

    let normaliseScore (score: Score) =
        match score with
        | Point (Forty, Forty) -> Deuce
        | _ -> score

    let nextPoint point =
        match point with
        | Love -> Fifteen
        | Fifteen -> Thirty
        | Thirty -> Forty
        | Forty -> failwith "No point score after Forty"

    let scorePoint score point =
        match score, point with
        | Advantage player1, player2 when player1 = player2 -> Win player1
        | Advantage _, _ -> Deuce
        | Deuce, player -> Advantage player
        | Point (Forty, _), One -> Win One
        | Point (_, Forty), Two -> Win Two
        | Point (a, b), One -> normaliseScore (Point(nextPoint a, b))
        | Point (a, b), Two -> normaliseScore (Point(a, nextPoint b))
        | Win (player), _ ->
            printfn "Game has been won by Player %A" player
            score

    let scoreGame (points: seq<Player>) =
        Seq.scan scorePoint (Point(Love, Love)) points
