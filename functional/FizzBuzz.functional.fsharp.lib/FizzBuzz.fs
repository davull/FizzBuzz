namespace FizzBuzz.functional.fsharp.lib

module FizzBuzz =
   
    let private Fizz = "Fizz"
    let private Buzz = "Buzz"
    let private FizzBuzz = Fizz + Buzz
    
    let GetFizzBuzz i =
        
        let isDivisibleBy divisor number = number % divisor = 0;
        // Curried functions
        let isDivisibleByThree = isDivisibleBy 3;
        let isDivisibleByFive = isDivisibleBy 5
        
        let isFizz i = isDivisibleByThree i
        let isBuzz i = isDivisibleByFive i
        let isFizzBuzz i = (isFizz i, isBuzz i)
        
        // Pattern match result tuple
        match isFizzBuzz i with
        | true, true -> FizzBuzz
        | true, _ -> Fizz
        | _, true -> Buzz
        | _ -> i.ToString()
