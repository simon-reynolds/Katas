module Tests

open System
open Expecto
open Katas

[<Tests>]
let fizzBuzzTests =
    testList "FizzBuzz" [
        testCase "1 -> 100" <| fun _ ->
            let expected = @"1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz 67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 Buzz Fizz 97 98 Fizz Buzz"

            let actual = FizzBuzz.execute [1 .. 100]

            Expect.equal actual expected "Should be equal"
    ]

[<Tests>]
let tennisTests =
    testList "Tennis" [
        testCase "Game 1 - A wins every point" <| fun _ ->
            let game1 = seq { while true do yield Tennis.Player.One }

            let finalScore = game1 |> Seq.take 10 |> Tennis.scoreGame

            Expect.equal (Seq.last finalScore) (Tennis.Win Tennis.Player.One) "Player one wins"

        testCase "Game 2 - A and B swap points indefinitely" <| fun _ ->
            let game2 = seq { while true do
                                 yield Tennis.Player.One
                                 yield Tennis.Player.Two }

            let finalScore = game2 |> Seq.take 10 |> Tennis.scoreGame

            Expect.equal (Seq.last finalScore) (Tennis.Score.Deuce) "Should be Deuce"

        testCase "Game 3 - A and B trade points but B wins more points than A" <| fun _ ->
            /// A sample game -
            let game3 = seq { while true do
                                 yield Tennis.Player.One
                                 yield Tennis.Player.Two
                                 yield Tennis.Player.Two }

            let finalScore = game3 |> Seq.take 10 |> Tennis.scoreGame

            Expect.equal (Seq.last finalScore) (Tennis.Win Tennis.Player.Two) "Player two wins"
    ]
