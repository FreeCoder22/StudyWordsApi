# Study Words API

## Project Description

This application assists users in creating a list of English words and automatically translating them into French. Users can study this list, and once they've learned the words, they can transfer them to another list of learned words. The application also includes a small game for practicing translations.

## Technologies Used

- **.NET 8**
- **EntityFRamewordCore**
- **Autofixture**
- **Dependency Injection**
- **DB first**
- **DeepL.net**: Used for word translation.

## How It Works

When a user adds a word to the list, the application makes an API call to translate this word into French. Users can also play a small game to practice translations.

## Installation and Usage

1. Clone this repository on your local machine.

3. Create file appsettings.Development.json in root api
  ````
```
// You can have an ApiKey-DeepL for free or I can get an apiKey to do a test
{
  "ConnectionStrings": {
    "DefaultConnection": "your-mysql-connectionString;"
  },
  "DeepL": {
    "ApiKey": "Your-ApiKey-DeepL"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
````
7. Launch the application by running `Lauch api project`.
9. If you want frontend application Clone this repository [https://github.com/max8392/StudyWordsApi](https://github.com/max8392/StudyWords)https://github.com/max8392/StudyWords

## License

Open Source
