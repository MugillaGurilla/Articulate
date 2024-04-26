namespace Articulate.Models
{ 
  public class Card 
  {
    private string _templatePath;
    private string _saveAsPath;

    public string SaveAsPath { get => _saveAsPath; set => _saveAsPath = value; }

    public string TemplatePath { get => _templatePath; set => _templatePath = value; }

    public Card() 
    {
      TemplatePath = "./src/img/template.jpeg";
    }
    public Card(string saveAsPath) 
    {
      TemplatePath = "../img/template.jpeg";
    }
  }
};