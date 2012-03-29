namespace Tennis.Tests

open Code
open NUnit.Framework
open FsUnit
open System

[<TestFixture>] 
type ``When incrementing points`` ()=
   
   [<Test>] member test.
    ``Scoring from 0 should give 15`` ()=
        increment Zero |> should equal Fifteen

   [<Test>] member test.
    ``Scoring from 15 should give 30`` ()=
        increment Fifteen |> should equal Thirty

    [<Test>] member test.
    ``Scoring from 30 should give 40`` ()=
        increment Thirty |> should equal Forty

    [<Test>] member test.
    ``Scoring from 40 should throw`` ()=
        (fun() -> increment Forty |> ignore) |> should throw typeof<Exception>


[<TestFixture>] 
type ``When Scoring`` ()=
   
   [<Test>] member test.
    ``Given a score of 0 0 when A score it should give 15 0`` ()=
        score (Points (Zero,Zero)) A |> should equal (Points(Fifteen,Zero))

   [<Test>] member test.
    ``Given a score of 0 15 when B score it should give 0 30`` ()=
        score (Points (Zero,Fifteen)) B |> should equal (Points(Zero,Thirty))

    [<Test>] member test.
    ``Given a score of 40 30 when B score it should give Deuce`` ()=
        score (Points (Forty,Thirty)) B |> should equal Deuce

    [<Test>] member test.
    ``Given a score of 30 40 when A score it should give Deuce`` ()=
        score (Points (Thirty,Forty)) A |> should equal Deuce

    [<Test>] member test.
    ``Given a deuce player score he has advantage`` ()=(
        score Deuce A |> should equal (Advantage A)
        score Deuce B |> should equal (Advantage B))

    [<Test>] member test.
    ``Given a Advantage for A if B scores back to Deuce`` ()=
        score (Advantage A) B |> should equal Deuce

    [<Test>] member test.
    ``Given a Advantage for A if A scores is score Game`` ()=
        score (Advantage A) A |> should equal (Game A)

    [<Test>] member test.
    ``Given a Game for A scrore remains Game A`` ()=(
        score (Game A) A |> should equal (Game A)
        score (Game A) B |> should equal (Game A))

[<TestFixture>] 
type ``When playing match`` ()=

    [<Test>] member test.
     ``Given a sequence of point winner a match can be played `` ()=(
        let firstGame = seq{
            yield Points(Zero,Zero)
            yield Points(Fifteen,Zero)
            yield Points(Fifteen,Fifteen)
            yield Points(Thirty,Fifteen)
            yield Points(Thirty,Thirty)
            yield Points(Forty,Thirty)
            yield Deuce
            yield Advantage A
            yield Deuce
            yield Advantage B
            yield Game B}
        playMatch [A;B;A;B;A;B;A;B;B;B] |> should equal firstGame )



   
   



