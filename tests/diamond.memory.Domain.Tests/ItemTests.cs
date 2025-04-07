using diamond.memory.Domain.Catalog;

[TestClass]
public class ItemTests
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        var item = new Item("name", "Description", "Brand", 10.00m);
        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }

    [TestMethod]
    public void Can_Create_Add_Rating(){
        var item = new Item("name", "Description", "Brand", 10.00m);
        var rating = new Rating(5, "Name", "Review");
        item.AddRating(rating);
        Assert.AreEqual(rating, item.Ratings[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Item_With_Invalid_Name(){
        var item = new Item(null, "Description", "Brand", 10.00m);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Item_With_Invalid_Description(){
        var item = new Item("Name", null, "Brand", 10.00m);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Item_With_Invalid_Brand(){
        var item = new Item("Name", "Description", null, 10.00m);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Item_With_Invalid_Price(){
        var item = new Item("Name", "Description", "Brand", -1);
    }




}