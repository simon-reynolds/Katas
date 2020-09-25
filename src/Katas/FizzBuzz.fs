namespace Katas

module FizzBuzz =

    let join separator (text : string seq) =  System.String.Join(separator, text)

    let matchNumber factor text i =
        match i with
        | x when i % factor = 0 -> text
        | _ -> ""

    let fizz i = matchNumber 3 "Fizz" i
    let buzz i = matchNumber 5 "Buzz" i

    let fizzBuzzNumber i =
        let result = (fizz i) + (buzz i)

        match result with
        | "" -> i.ToString()
        | _ -> result

    let execute (numbers : int seq) =
        numbers
        |> Seq.map fizzBuzzNumber
        |> join " "
