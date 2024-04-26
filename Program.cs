using System;
using Articulate.Helpers;
using Articulate.Models;
using Models;

namespace Articulate {
  class Program 
  {
    static void Main(string[] args) {
      if (args.Length == 0) 
      {
        Console.WriteLine("No Command Arguments provided.");
        return;
      }

      if (args.Length >= 2) 
      {
        Console.WriteLine("Too many arguments provided.");
        return;
      }

      if (!int.TryParse(args[0], out int numberOfCards)) 
      {
        Console.WriteLine("Invalid input. Please provide a number.");
        return;
      }

      if(numberOfCards > 10000) 
      {
        System.Console.WriteLine("Too many cards requested, your computer can't deal.");
        return;
      }

      Console.WriteLine($"The number provided was: {numberOfCards}");
      Execution execution = new Execution(numberOfCards);
      execution.Run();
    }
  }
}