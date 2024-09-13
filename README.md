# Console_PhoneBook
Console-based contact management and format converter application developed in C#. The app performs CRUD operations (Create, Read, Update, Delete), has full unit test coverage of it's functionality and supports import/export capabilities in four file formats: CSV, vCard, JSON, and XML.
This project was primarily intended as a learning vehicle, with a strong focus on clean, well-structured, and properly implemented coding principles and was developed as an honest effort to develop something from a blank file trying to solve problems without any gide or tutorial.
Althought the app is very basic in functionality it was developed with SOLID coding principles in mind like single responsability, dependency inversion and open/closed principles which in conjunction with Unit test implementation forms a strong base for further develpment if anyone has the motivation to do so.

## Table of Contents (Optional)

- [Features](#Features)
- [Installation](#installation)
- [Usage](#usage)
- [Tests](#tests)
- [License](#license)

##Features
1.ADD CONTACT: Allow users to add new contacts to the phonebook.

2.VIEW ALL CONTACTS: Provide an option to display a list of all contacts stored in the phonebook.

3.SEARCH CONTACTS: Allow users to search as you type by contacts by name, phone number, or any other later added criteria. Provides a search functionality that returns matching contacts.

4.EDIT CONTACTS: Allow users to modify existing contact information. They should be able to update any or all details associated with a contact.

5.DELETE CONTACT: Implement the ability to delete contacts from the phonebook.

6.IMPORT / EXPORT CONTACTS: Provide the ability to import from external sources (e.g., CSV, vCard, JSON and XML) and export them to any of these formats effectively  turning into a CLI file convertion lybrary for contacts file types.


## Installation

Console PhoneBook is a terminal application designed to be simple and straightforward to use. To get started, follow these steps:

**Download the Executable:** Navigate to the bin/Debug/net6.0 directory in this repository and download it's contents (a demo PhoneBook is included to get you started) just aswell as the executable file (ConsolePhoneBook.exe) itself.

**Run the Application:** Once you've downloaded the executable, open your terminal and navigate to the directory where you saved the file. Then, simply run the executable using the appropriate command for your operating system (./ConsolePhoneBook.exe on Unix-based systems or ConsolePhoneBook.exe on Windows). A simple double click on the .exe file will work fine aswell.

**Testing:** Within the bin/Debug/net6.0 directory, you'll find test files for all supported formats. These files can be used to conveniently test the application's functionality with various data formats.


## Usage

User is greeted with a welcome screen:
![image](https://github.com/user-attachments/assets/d0b4225f-2c79-4340-8c84-249bf7847513)

Start-up options, it's suggested to choose option 1 so there's some data to demo the application:
![image](https://github.com/user-attachments/assets/e55ea84e-68ed-4dd1-a016-a33e05fde5df)

Main menu:
3![image](https://github.com/user-attachments/assets/9410d8c1-943a-4bd9-9342-bc682f921a91)

Search functionality:
![image](https://github.com/user-attachments/assets/13420c52-2a3a-48d2-aad4-697658f827ad)

Import Functionality:
![image](https://github.com/user-attachments/assets/2099aaad-4bf5-40ff-8f17-01ddfd06eb96)

export functionality:
![image](https://github.com/user-attachments/assets/77610548-6696-48b4-9463-f27bf21e86c6)


## Credits

List your collaborators, if any, with links to their GitHub profiles.

If you used any third-party assets that require attribution, list the creators with links to their primary web presence in this section.

If you followed tutorials, include links to those here as well.



---



## How to Contribute

While I'm currently the sole developer working on this project, I welcome contributions / suggestions.

### Getting Started

1. Fork the repository by clicking the "Fork" button on GitHub.
2. Clone your forked repository to your local machine:
3. git clone https://github.com/your-username/your-repository.git
4. Open the project in your preferred IDE or text editor (e.g., Visual Studio, Visual Studio Code).

###Contributing Ideas and Feedback
If you have ideas for new features, improvements, or feedback on the existing functionality, please feel free to share them by opening an issue in the issue tracker. I value your input and will do my best to consider and incorporate your suggestions into the project.

###Code Contributions
While I'm primarily responsible for writing and maintaining the codebase, I'm open to accepting code contributions from other learners who are interested in practicing their coding skills. If you'd like to contribute code changes, please follow these steps:

1.Create a new branch for your changes:
    `git checkout -b feature/my-feature`
2.Make your changes to the codebase. Feel free to experiment and learn as you go.
3.Test your changes locally to ensure they work as expected.
4.Commit your changes with clear and descriptive commit messages:
    `git commit -m "Add feature X"`
5.Push your changes to your forked repository:
    `git push origin feature/my-feature`
6.Submit a pull request from your branch to the main repository's master branch on GitHub. Be sure to provide a detailed description of your changes and any relevant context.


## Tests

Test structure:
![image](https://github.com/user-attachments/assets/735fdba7-b8f3-4456-b86a-afb024848f05)


Performace test comparison for different Collection types, made possible by applying dependency inversion principle:
![image](https://github.com/user-attachments/assets/5f8d3cc7-cf42-4cb3-91cc-94d1fe7583f7)


Go the extra mile and write tests for your application. Then provide examples on how to run them here.

## License
This project is licensed under the [MIT License](LICENSE).

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

The MIT License is a permissive open-source license that allows users to do whatever they want with the project, as long as they include the original copyright notice and disclaimer of warranty.
