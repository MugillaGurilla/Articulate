using SkiaSharp;

namespace Models 
{
  public class Coordinates 
  {
    private static int _yIncrement = 96;
    private Dictionary<string, SKPoint> _set =  new Dictionary<string, SKPoint>()
    {
      { "person", new SKPoint(150, 65 + (YIncrement * 0)) },
      { "world", new SKPoint(150, 65 + (YIncrement * 1)) },
      { "object", new SKPoint(150, 65 + (YIncrement * 2)) },
      { "action", new SKPoint(150, 65 + (YIncrement * 3)) },
      { "nature", new SKPoint(150, 65 + (YIncrement * 4)) },
      { "random", new SKPoint(150, 65 + (YIncrement * 5)) },
    };

    public SKPoint Spade =  new SKPoint(777, 0);
  

    public Dictionary<string, SKPoint> Set { get => _set; set => _set = value; }
    public static int YIncrement { get => _yIncrement; set => _yIncrement = value; }
  }
}