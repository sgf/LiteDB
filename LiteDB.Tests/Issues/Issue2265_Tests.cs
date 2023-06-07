using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace LiteDB.Tests.Issues;

public class Issue2265_Tests
{

    [Fact]
    public void TestRefSelf()
    {
        try
        {
            var db = new LiteDatabase(":memory:");
            var col = db.GetCollection<Package>(nameof(Package));
            col.EnsureIndex(x => x.Parent);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }
        //col.EnsureIndex(x => x.Accounts2to1);
        //col.InsertBulk(this.GenerateItems());
        //col.DeleteAll();
        //col.InsertBulk(this.GenerateItems());
    }

}




public class Package
{

    [BsonRef()]
    public Package Parent { get; set; }

    public List<Package> Childs { get; set; }

}