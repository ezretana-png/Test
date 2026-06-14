# lambda-list-validator

A C# console application that validates collections using lambda expressions and LINQ. This project demonstrates functional programming patterns in C# with concise, expressive list validation logic.

## Features

- Validate lists using lambda expressions (`=>`)
- Powered by LINQ for query and filter operations
- Clean separation of validation rules as predicates
- Console output with pass/fail results per rule
- Extensible — add new validators with minimal code

## Code Snippet

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Func<int, bool> isEven = n => n % 2 == 0;
Func<int, bool> greaterThanThree = n => n > 3;

var evenNumbers = numbers.Where(isEven);
var filtered = numbers.Where(greaterThanThree);

Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
Console.WriteLine("Greater than 3: " + string.Join(", ", filtered));
```

## How to Run

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

## Tech Stack

- **.NET** — Runtime and framework
- **C#** — Primary language
- **LINQ** — Query and transformation operations
- **Lambda Expressions** — Inline predicate definitions
