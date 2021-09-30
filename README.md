# Mercury New Media - Coding Skills Test

You are working with a top-tier state university that needs help accessing their student and course data.

The university currently offers 350 different courses to over 10,000 students.

Currently, we have two rough C# interfaces, `IStudentAPI` and `ICourseAPI`, with only one method each.

## Refactoring

We would like to see how you would improve the example code. Please include a couple sentences describing your changes
along with the rationale, along with any additional changes you would have made given more time.

## API Design

Extend the `IStudentAPI` to include methods to satisfy the following criteria:

- Retrieve all students, ordered by last name, as a pageable result set
- Find all students enrolled in a specified course
- Find all students with a given last name

Extend the `ICourseAPI` to include methods to satisfy the following criteria:

- Retrieve all courses, ordered by course name, as a pageable result set
- Find a single course by name

Assume that the consumers of the interface will only receive the API specification, including any
documented assumptions, error conditions, and method parameters. Judicious use of XML comments on the interface
is encouraged.

Implement your newly added interface methods.

## Unit Testing

In order to validate your API, what unit tests would you need to ensure it works as specified? 

Implement those tests in the test project.

## Time

Please limit your time to 2 hours. Include a few sentences about the changes you made, or any
additional changes you would make given more time.
