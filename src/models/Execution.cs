using Articulate.Helpers;
using Articulate.Models;

namespace Models 
{
  public class Execution 
  {
    public Folder Folder;
    public Card Card;
    public Writer Writer;
    public int NumberOfCards; 

    public Execution(int numberOfCards)
    {
      NumberOfCards = numberOfCards;
      Folder = new Folder(NumberOfCards);
      Card = new Card();
      Writer = new Writer();
    }

    public void Run() 
    {
      Folder.Make();
      Card.SaveAsPath = Folder.FolderPath;
      Writer.ShuffleAllData();
      Writer.ToCard(Card, NumberOfCards);
    } 
  }
}