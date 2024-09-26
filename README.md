# RetrainingScheduler Project

## Overview
The `RetrainingScheduler` project is designed to schedule conference talks into tracks and sessions. This project includes several classes such as `ConferenceScheduler`, `Session`, `Talk`, and `Track`, along with their respective unit tests.

## Prerequisites
- Visual Studio 2019 or later
- .NET SDK 5.0 or later

## Project Structure
- **RetrainingScheduler**: Contains the main scheduling logic.
- **RetrainingSchedulerTests**: Contains unit tests for the scheduling logic.

## Getting Started

### Cloning the Repository
1. Open a terminal or command prompt.
2. Clone the repository:
3. git clone https://github.com/yourusername/RetrainingScheduler.git
4. Navigate to the project directory:  cd RetrainingScheduler



### Opening the Project in Visual Studio
1. Open Visual Studio.
2. Select `File` > `Open` > `Project/Solution`.
3. Navigate to the `RetrainingScheduler` directory and select the `RetrainingScheduler.sln` file.

### Building the Project
1. In Visual Studio, go to `Build` > `Build Solution` or press `Ctrl+Shift+B`.
2. Ensure that the build completes successfully without any errors.

### Running the Tests
1. Open the `Test Explorer` window by going to `Test` > `Test Explorer`.
2. Click on `Run All` to execute all the tests.
3. The results will be displayed in the `Test Explorer` window.

### Running the Application
1. Set the `RetrainingScheduler` project as the startup project.
2. Press `F5` or click on the `Start` button to run the application.

## Project Details

### ConferenceScheduler
The `ConferenceScheduler` class is responsible for scheduling talks into tracks and sessions.

### Session
The `Session` class represents a session within a track, which can hold multiple talks.

### Talk
The `Talk` class represents an individual talk with a title and duration.

### Track
The `Track` class represents a track that contains a morning and an afternoon session.

## Unit Tests
The unit tests are located in the `RetrainingSchedulerTests` project. The tests cover various scenarios to ensure the correct functionality of the scheduling logic.

### Key Test Classes
- **ConferenceSchedulerTests**: Tests for the `ConferenceScheduler` class.
- **SessionTests**: Tests for the `Session` class.
- **TalkTests**: Tests for the `Talk` class.
- **TrackTests**: Tests for the `Track` class.

## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Contact
For any questions or issues, please open an issue on GitHub or contact the project maintainer.


    
