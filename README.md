# Console_PhoneBook
Console-based contact management and format converter application developed in C#. The app performs CRUD operations (Create, Read, Update, Delete), has full unit test coverage of it's functionality and supports import/export capabilities in four file formats: CSV, vCard, JSON, and XML.
This project was primarily intended as a learning vehicle, with a strong focus on clean, well-structured, and properly implemented coding principles and was developed as an honest effort to creatw something from a blank file trying to solve problems without any gide or tutorial.
Althought the app is very basic in functionality it was developed with SOLID coding principles in mind like single responsability, dependency inversion and open/closed principles which in conjunction with Unit test implementation forms a strong base for further develpment if anyone has the motivation to do so.

If you have ideas for new features, improvements, or feedback on the existing functionality, please feel free to share them by opening an issue in the issue tracker. I value your input and will do my best to consider and incorporate your suggestions into the project.

## Table of Contents:
- [Features](#Features)
- [Installation](#installation)
- [Usage](#usage)
- [Code Highlights]("Code-Highlights)
- [Tests](#tests)
- [How to contribute](#how-to-contribute)
- [Credits](#Credits)
- [License](#license)

## Features
1. **Add Contacts**: Allow users to add new contacts to the phonebook.

2. **View All Contacts**: Provide an option to display a list of all contacts stored in the phonebook.

3. **Search Contacts**: Gives users the ability to search contacts as you type by name, phone number, or any other property of the contact.

4. **Edit Contacts**: Allow users to modify any or all existing details of a contact.

5. **Delete Contacts**: Implement the ability to delete contacts from the phonebook.

6. **Import/Export Contacts**: Provide the ability to import from external sources (e.g., CSV, vCard, JSON and XML) and export your phonebook to any of these formats effectively turning into a CLI file convertion lybrary for contacts file types.

## Usage
User is greeted with a welcome screen:
![image](https://github.com/user-attachments/assets/d0b4225f-2c79-4340-8c84-249bf7847513)

Start-up options, if your testing the application it's suggested to choose option 1 so there's some data to demo the application:
![image](https://github.com/user-attachments/assets/e55ea84e-68ed-4dd1-a016-a33e05fde5df)

Main menu:
3![image](https://github.com/user-attachments/assets/9410d8c1-943a-4bd9-9342-bc682f921a91)

Search functionality:
![image](https://github.com/user-attachments/assets/13420c52-2a3a-48d2-aad4-697658f827ad)

Import Functionality:
![image](https://github.com/user-attachments/assets/2099aaad-4bf5-40ff-8f17-01ddfd06eb96)

Export functionality:
![image](https://github.com/user-attachments/assets/77610548-6696-48b4-9463-f27bf21e86c6)

## Code Highlights
Clear and well organized project structure: 

![image](https://github.com/user-attachments/assets/4ff3f3bd-8f73-47e1-a4f6-9d5d7662c694)

**Command pattern** for menus, The Dictionary<string, Action<IAppFunctionality>> acts as a command registry, each dictionary entry maps a command name (like "Demo PhoneBook") to an Action<IAppFunctionality> delegate that executes a specific method on the IAppFunctionality interface. This allows you to execute different functionalities based on the user's selection.

![image](https://github.com/user-attachments/assets/a7d994db-3eca-4072-ade6-20cfc612ea7f)

**Factory pattern** for handling different file formats, the "RepositoryFactory" class has a static method GetRepository that creates and returns instances of different IGenericRepository implementations based on the FileExtensions enum. IGenericRepository is the common interface that all the concrete handler classes (e.g., CSVHandler, VCFHandler, JSONHandler, XMLHandler) implement.

![image](https://github.com/user-attachments/assets/c20521dd-f974-4cba-a713-50d0f6d9ba30)

**Dependency Inversion Principle**, the ContactsRegister<TCollection> class uses generics to allow flexibility in the type of collection used. It follows the Dependency Inversion Principle by depending on abstractions (ICollection<IGenericContact>) rather than concrete implementations.The generic type and the new() constraint offer a form of factory-like behavior in determining the type of collection to use.
![image](https://github.com/user-attachments/assets/891f231f-40f9-4226-848f-aaa95a6c46a6)

**Repository / Template pattern**, GenericRepository provides methods for loading from and saving to files, abstracting away the specifics of data access. Parse and Serialize methods are abstract, allowing subclasses to implement specific parsing and serialization logic based on the file format or data type. GenericRepository provides methods for loading from and saving to files, abstracting away the specifics of data access.


# placeHOLDER FOR GENERIC REPOSITORY CLASS


## Tests
Test structure:                                                                                  
![image](https://github.com/user-attachments/assets/735fdba7-b8f3-4456-b86a-afb024848f05) 

Performace test comparison for different Collection types, made possible by applying dependency inversion principle:
![image](https://github.com/user-attachments/assets/5f8d3cc7-cf42-4cb3-91cc-94d1fe7583f7)

These tests can either be run from Visual Studio's "Test Explorer" tab or by using the "dotnet test" command in the project's folder.

## Installation
Console PhoneBook is a terminal application designed to be simple and straightforward to use. To get started, follow these steps:

**Download the Executable:** Navigate to the bin/Debug/net6.0 directory in this repository and download it's contents (a demo PhoneBook is included to get you started) just aswell as the executable file (ConsolePhoneBook.exe) itself.

**Run the Application:** Once you've downloaded the executable, open your terminal and navigate to the directory where you saved the file. Then, simply run the executable using the appropriate command for your operating system (./ConsolePhoneBook.exe on Unix-based systems or ConsolePhoneBook.exe on Windows). A simple double click on the .exe file will work fine aswell.

**Testing:** Within the bin/Debug/net6.0 directory, you'll find test files for all supported formats. These files can be used to conveniently test the application's functionality with various data formats.

## How to Contribute
Although I am currently the sole developer of this project, I encourage and welcome contributions and suggestions from the community. I'd be excited to see how other developers can help the project grow and evolve.

1. Fork the repository by clicking the Fork button on GitHub.
2. Clone your forked repository to your local machine by running the following command:
git clone https://github.com/your-username/your-repository.git

3.Open the project in your preferred IDE or text editor (e.g., Visual Studio, Visual Studio Code).



## Credits
I would like to thank Krystyna Ślusarczyk for her amazing Udemy course <a href="(https://www.udemy.com/course/ultimate-csharp-masterclass)" target="Ultimate C# Masterclass for 2024">Link Text</a>, though the app is original in conception and implementation the concepts and principals thought on this course gave me a much deeper fundation to be able to devolop this project.

## License
This project is licensed under the [MIT License](LICENSE).

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

The MIT License is a permissive open-source license that allows users to do whatever they want with the project, as long as they include the original copyright notice and disclaimer of warranty.
