using Articulate.Models;
using SkiaSharp;
using System.Linq;
using Newtonsoft.Json;
using Models;

namespace Articulate.Helpers
{
 
  public class Writer
  {
    private Dictionary<string, string[]> _data = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText("src/data/articulate-data.json"));
    
    private Coordinates _coordinates = new Coordinates();
    private SKData _imageData;
    public (int x, int y) coordinates = (x: 150, y: 65);
    public int YIncrement = 96;

    public Dictionary<string, string[]> Data { get => _data; set => _data = value; }

    public void ToCard(Card card, int numberOfCards)
    {
      for (int index = 0; index < numberOfCards; index++)
      {
        WriteText(card, index);
        SaveCard(card, index);
      }
    }

   private void WriteText(Card card, int index)
   {
    using SKBitmap bitmap = SKBitmap.Decode(card.TemplatePath);
    using (SKCanvas canvas = new SKCanvas(bitmap))
    {
      using SKPaint paint = new SKPaint();
      paint.TextSize = 40;
      paint.Color = SKColors.Black;
      var fontManager = SKFontManager.Default;
      var spadeFont = fontManager.MatchCharacter("Calibri", '♠');      
      paint.Typeface = spadeFont;
      paint.FakeBoldText = true;

      canvas.DrawText(_data["person"][index % _data["person"].Length], _coordinates.Set["person"], paint);
      canvas.DrawText(_data["world"][index % _data["world"].Length], _coordinates.Set["world"], paint);
      canvas.DrawText(_data["object"][index % _data["object"].Length], _coordinates.Set["object"], paint);
      canvas.DrawText(_data["action"][index % _data["action"].Length], _coordinates.Set["action"], paint);
      canvas.DrawText(_data["nature"][index % _data["nature"].Length], _coordinates.Set["nature"], paint);
      canvas.DrawText(_data["random"][index % _data["random"].Length], _coordinates.Set["random"], paint);

      Random random = new Random();
      int addition = YIncrement * random.Next(1,6);
      _coordinates.Spade.Y = 65 + addition;
      canvas.DrawText("♠", _coordinates.Spade, paint);
    }

    _imageData = bitmap.Encode(SKEncodedImageFormat.Jpeg, 100);
  }

    private void SaveCard(Card card, int index) 
    {
      using (FileStream stream = File.OpenWrite(card.SaveAsPath + $"/{index}.jpeg"))
      {
        _imageData.SaveTo(stream);
      }
    }

    public void ShuffleAllData() 
    {
      foreach (var keyValuePair in Data)
      {
          Data[keyValuePair.Key] = ShuffleArray(keyValuePair.Value);
      }
    }


    private string[] ShuffleArray(string[] dataArray)
    {
      var random = new Random();
      var shuffledData = dataArray.OrderBy(x => random.Next()).ToArray();
      return shuffledData;
    }
  }
}