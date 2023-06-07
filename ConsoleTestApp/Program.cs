// See https://aka.ms/new-console-template for more information
using LiteDB;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

try
{
    var db = new LiteDatabase(":memory:");
    //var col = db.GetCollection<PackageA>(nameof(PackageA));
    var col = db.GetCollection<PackageB>(nameof(PackageB));
    col.EnsureIndex(x => x.Parent);
}
catch (Exception ex)
{
    Debug.WriteLine(ex.Message);
    Debug.WriteLine(ex.StackTrace);
}

public class PackageB
{

    [BsonRef()]
    public PackageB Parent { get; set; }

    public List<PackageB> Childs { get; set; }

}
public class PackageA
{

    [BsonRef()]
    public PackageC Parent { get; set; }

    public List<PackageC> Childs { get; set; }
}
public class PackageC
{
    public string Field { get; set; } = "";

}