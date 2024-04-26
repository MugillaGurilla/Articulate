namespace Articulate.Models
{
  public class Folder
  {
    private string _id;
    private string _folderPath;

    public string Id { get => _id; set => _id = value; }
    public string FolderPath { get => _folderPath; set => _folderPath = value; }

    public Folder(int id)
    {
      Id = id.ToString();
    }

    public void Make() 
    {
      FolderPath = "./builds/" + _id + "_" + DateTime.Now.ToString("yyyy-MM-dd");
      Directory.CreateDirectory(FolderPath);
    }
  }
}