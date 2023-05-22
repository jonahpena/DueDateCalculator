# Due Date Calculator

## Table of Contents

1. [Description](#description)
2. [Technologies](#technologies)
3. [Requirements](#requirements)
4. [Installation](#installation)
5. [Usage](#usage)
6. [Testing](#testing)
8. [Design and Approach](#design)
9. [Limitations and Future Improvements](#limitations)
9. [License](#license)
10. [Contact](#contact)

## Description <a name="description"></a>

This project implements a due date calculator for an issue tracking system. This calculator is designed to take a submit date/time and a turnaround time and to return the date/time when the issue is expected to be resolved, based on certain defined working hours and rules.


## Technologies <a name="technologies"></a>

- C#
- .NET 6.0
- NUnit

## Requirements <a name="requirements"></a>

To run this application, you need:

- .NET 6.0 SDK

## Installation <a name="installation"></a>

1. Clone the repository to your local machine using the command: `git clone https://github.com/jonahpena/DueDateCalculator.git`
2. Navigate to the project directory using: `cd DueDateCalculator`
3. Build the project using the .NET CLI: `dotnet build`

## Usage <a name="usage"></a>

This is a library that provides a `DueDateCalculator` class. You can create an instance of this class and call its `CalculateDueDate` method, passing in the submit date and turnaround time (in hours), to calculate the due date.

## Testing <a name="testing"></a>

The `DueDateCalculator.Tests` project contains unit tests for the application. These tests are designed to cover various scenarios, such as:

- Submitting a task during working hours on a working day
- Submitting a task outside of working hours
- Providing negative turnaround time
- Testing for large turnaround times
- Submitting a task at the start of a workday and expecting a due date on the same day

To run the tests, use the .NET CLI with the command `dotnet test`.

## Design and Approach <a name="design"></a>

The solution is designed around two main components, `DueDateCalculator` and `WorkingHours`, both implementing interfaces `IDueDateCalculator` and `IWorkingHours` respectively. The `DueDateCalculator` uses the `WorkingHours` to determine whether a given date/time falls within defined working hours or on a weekend. The `CalculateDueDate` method then calculates the due date based on the provided turnaround time, skipping non-working hours and days as required.

The code has been written with the intent of it being clean, readable, and maintainable. Each class and method has a single responsibility, and dependencies are injected where possible to allow for easier testing and potential future extension.


## Limitations and Future Improvements <a name="limitations"></a>

The solution assumes that the submit date/time and turnaround time will always be valid inputs. In a future version, it could be useful to add more robust error handling and input validation. 



## License <a name="license"></a>

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE) file.

## Contact <a name="contact"></a>

Jonah Pena
- Email: jonahrpena@gmail.com
