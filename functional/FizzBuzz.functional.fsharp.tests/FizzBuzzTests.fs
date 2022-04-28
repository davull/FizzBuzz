module FizzBuzz.functional.fsharp.tests.FizzBuzzTests

open FizzBuzz.functional.fsharp.lib
open Xunit

let Fizz = "Fizz"
let Buzz = "Buzz"

[<Theory>]
[<InlineData(3)>]
[<InlineData(6)>]
[<InlineData(9)>]
let GetFizz(i : int) =
    // Act
    let actual = FizzBuzz.GetFizzBuzz i
    // Assert
    Assert.Equal(Fizz, actual)

[<Theory>]
[<InlineData(5)>]
[<InlineData(10)>]
[<InlineData(20)>]
let GetBuzz(i : int) =
    // Act
    let actual = FizzBuzz.GetFizzBuzz i
    // Assert
    Assert.Equal(Buzz, actual)
    
[<Theory>]
[<InlineData(15)>]
[<InlineData(30)>]
[<InlineData(45)>]
let GetFizzBuzz(i : int) =
    // Act
    let actual = FizzBuzz.GetFizzBuzz i
    // Assert
    Assert.Equal(Fizz + Buzz, actual)

[<Theory>]
[<InlineData(1)>]
[<InlineData(2)>]
[<InlineData(4)>]
let GetNumber(i : int) =
    // Act
    let actual = FizzBuzz.GetFizzBuzz i
    // Assert
    Assert.Equal(i.ToString(), actual)

[<Fact>]
let GetFizzBuzz_From1To100() =
    
    // Arrange
    let expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 " +
                   "FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 " +
                   "Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz " +
                   "Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 " +
                   "Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz " +
                   "67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz " +
                   "Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 " +
                   "Buzz Fizz 97 98 Fizz Buzz"
    // Act
    let actual = [|1..100|]
                 |> Array.map FizzBuzz.GetFizzBuzz
                 |> String.concat " "
                 
    // Assert
    Assert.Equal(expected, actual)