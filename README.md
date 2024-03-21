# Console_PhoneBook
Console contacts management application developed in C#

FEATURES:

1.Add Contact: Allow users to add new contacts to the phonebook. They should be able to input the contact's name, phone number, email address, and any other relevant information.

2.View All Contacts: Provide an option to display a list of all contacts stored in the phonebook. This list should show basic information such as names and phone numbers.

3.Search Contacts: Allow users to search for specific contacts by name, phone number, or any other relevant criteria. Provide a search functionality that returns matching contacts.

4.Edit Contact: Allow users to modify existing contact information. They should be able to update the name, phone number, email address, and any other details associated with a contact.

5.Delete Contact: Implement the ability to delete contacts from the phonebook. Users should be able to remove unwanted or outdated contacts from the database.

6.Save/Load Contacts: Implement functionality to save the phonebook data to a file (e.g., a text file or a database) so that it can be loaded again later. This ensures that contacts are persisted between sessions.

7.Import/Export Contacts: Provide options to import contacts from external sources (e.g., CSV files, vCard files) and export contacts to various formats for backup or sharing purposes.

8.Sort Contacts: Allow users to sort the list of contacts based on different criteria such as name, phone number, or date added. This helps users quickly find the contact they are looking for.

9.Pagination: If the list of contacts is long, implement pagination or scrolling functionality to display a subset of contacts at a time, improving usability and performance.

10.User Interface Enhancements: Consider adding user-friendly features such as color-coding, interactive menus, and keyboard shortcuts to enhance the user experience.

11.Error Handling: Implement robust error handling to gracefully handle unexpected situations such as invalid input, file I/O errors, or database connectivity issues.

12.Data Validation: Validate user input to ensure that contact information is entered correctly and consistently. Provide feedback to users if any errors are detected.


# <Console PhoneBook>

## Description
Console PhoneBook is a personal learning project aimed at simplifying tasks of contact management and format conversion. The goal was to create a tool that would streamline contact managment processes without unnecessary complexity.

The idea was simple: provide a user-friendly console application capable of performing all the essential CRUD operations on a collection of contacts (adding, viewing, updating, and deleting) while also offering the convenience of format conversion between popular formats like CSV, VCF, JSON, and XML.

Through this project, I gained valuable insights into software development, including coding practices, design considerations, and the importance of user experience. But perhaps most importantly, I discovered that even modest projects like this one have the potential to teach us a great deal when approached with curiosity and dedication.

Console PhoneBook isn't meant to be the flashiest tool out there, but it's my hope that it can actually be a usefull tool for others facing similar challenges in managing their contacts and data formats.

Give it a try, share your feedback

## Table of Contents (Optional)

If your README is long, add a table of contents to make it easy for users to find what they need.

- [Installation](#installation)
- [Usage](#usage)
- [Credits](#credits)
- [License](#license)

## Installation

Console PhoneBook is a terminal application designed to be simple and straightforward to use. To get started, follow these steps:

**Download the Executable:** Navigate to the bin/Debug/net6.0 directory in this repository and download it's contents (some demo PhoneBooks are included to get you started) wswell as the executable file (ConsolePhoneBook.exe) itself.

**Run the Application:** Once you've downloaded the executable, open your terminal and navigate to the directory where you saved the file. Then, simply run the executable using the appropriate command for your operating system (./ConsolePhoneBook.exe on Unix-based systems or ConsolePhoneBook.exe on Windows). A simple double click on the .exe file will work fine aswell.

**Testing:** Within the bin/Debug/net6.0 directory, you'll find test files for all supported formats. These files can be used to conveniently test the application's functionality with various data formats.

Console PhoneBook is cross-platform and can be run on Windows, macOS, and Linux systems without the need for installation. There are no additional dependencies or requirements just download the executable and start managing your contacts effortlessly.



## Usage

Provide instructions and examples for use. Include screenshots as needed.

To add a screenshot, create an `assets/images` folder in your repository and upload your screenshot to it. Then, using the relative filepath, add it to your README using the following syntax:

    ```md
    ![alt text](assets/images/screenshot.png)
    ```

## Credits

List your collaborators, if any, with links to their GitHub profiles.

If you used any third-party assets that require attribution, list the creators with links to their primary web presence in this section.

If you followed tutorials, include links to those here as well.

## License

This project is licensed under the [MIT License](LICENSE).

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

The MIT License is a permissive open-source license that allows users to do whatever they want with the project, as long as they include the original copyright notice and disclaimer of warranty.

---

🏆 The previous sections are the bare minimum, and your project will ultimately determine the content of this document. You might also want to consider adding the following sections.

## Badges

![badmath](https://img.shields.io/github/languages/top/lernantino/badmath)

Badges aren't necessary, per se, but they demonstrate street cred. Badges let other developers know that you know what you're doing. Check out the badges hosted by [shields.io](https://shields.io/). You may not understand what they all represent now, but you will in time.

## Features

1. Add Contact
2. View All Contacts
3. Search Contacts
4. Edit Contact
5. Delete Contact
6. Save/Load Contacts
7. Import/Export Contacts
8. Error Handling


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

Go the extra mile and write tests for your application. Then provide examples on how to run them here.
