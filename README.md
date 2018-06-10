# Kata04: http://codekata.com/kata/kata04-data-munging/

Note: This solution is built with the latest C# minor version (7.3) and targets .NET Core 2.0.

# Kata Questions:

1. To what extent did the design decisions you made when writing the original programs make it easier or harder to factor out common code?

The decisions I made writing the original programs made it easier to factor out the common code because the components were cohesive and decoupled enough that it
wasn't much trouble to add some generic types/interfaces to make them general purpose. Identifying and separating out the major components in the original programs was the most important part in creating a design that allowed code to be used for both types of data. I was able to reuse code either through inheritance and template patterns. Some of the renaming was tedious but nothing too difficult.

2. Was the way you wrote the second program influenced by writing the first?

Yes to the extent that I started the second program by copying all the files from the first and renaming the classes to something more appropriate. The design was good
enough that nothing needed to change except the names of classes and the underlying data type of the team record instead of a weather record. The application data flow stayed the same. In order to follow the steps of the exercise, I waited until step 3 to make the components generic.

3. Is factoring out as much common code as possible always a good thing? Did the readability of the programs suffer because of this requirement? How about the maintainability?

While I hesitate to use the absolute term "always", I do believe that factoring out as much common code as possible is usually a good thing assuming you continue to follow SOLID principles. The DRY principle exists for a reason because factoring out common code makes your code more maintainable because you change your code in one place only. In my opinion, readability can go down if the concept which you are factoring out doesn't translate well to a real-world concept. Names of methods, properties, method arguments, and variables can lose helpful meaning when they have to be converted to generic names (such as in my program when I refactored things as "Differentiables"). Refactoring the common code also introduced many type parameters that sacrifice readability for the benefits of code reuse and maintainability.