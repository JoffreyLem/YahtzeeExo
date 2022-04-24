// See https://aka.ms/new-console-template for more information

using TestProjectYahtzee;

Console.WriteLine("Hello, World!");

ConsoleImplementation consoleImplementation = new ConsoleImplementation();

Yahtzee yahtzee = new Yahtzee(consoleImplementation);

yahtzee.Jouer();
