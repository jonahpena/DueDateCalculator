# Due Date Calculator

## Table of Contents

1. [Description](#description)
2. [Technologies and Languages Used](#technologies-and-languages-used)
3. [Requirements](#requirements)
4. [Installation](#installation)
5. [Usage](#usage)
6. [Testing](#testing)
7. [Reporting Bugs](#reporting-bugs)
8. [License](#license)
9. [Contact](#contact)
10. [Acknowledgments](#acknowledgments)

## Description <a name="description"></a>

This project is a .NET 6.0 application that calculates the due date for a task based on the submit date and turnaround time. It takes into account working hours (9 AM to 5 PM) and excludes weekends.

## Technologies and Languages Used <a name="technologies-and-languages-used"></a>

- C#
- .NET 6.0

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

## Reporting Bugs <a name="reporting-bugs"></a>

If you encounter any bugs or issues, please create an issue in the repository detailing the bug and steps to reproduce it.

## License <a name="license"></a>

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE) file.

## Contact <a name="contact"></a>

Jonah Pena
- Email: jonahrpena@gmail.com

## Acknowledgments <a name="acknowledgments"></a>

(Provide any acknowledgments if applicable)
