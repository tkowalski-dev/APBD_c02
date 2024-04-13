using System.Diagnostics;

namespace LegacyAppTests;

public class UnitTest1
{
    [Fact]
    public void Test_AlwaysTrue()
    {
        Assert.Equal(true, true);
    }
    
    [Fact]
    public void TestAddUser_WithoutAt_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "Kowalski", "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Null_FirstName_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser(null, "Kowalski", "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Empty_FirstName_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("", "Kowalski", "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Empty_LastName_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "", "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Null_LastName_Should_()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", null, "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Email_Not_Containing_At_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "Kowalski", "test*gmail.com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Email_Not_Containing_Dot_Should_Be_False()
    {
        var userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "Kowalski", "test*gmail///com", new DateTime(1999, 3, 7), 1);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Age_Less_Then_21_Should_Be_False_v1()
    {
        var userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "Kowalski", "Kowalski.tomasz@gmail.com", new DateTime(2024, 4, 13), 2);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Age_Less_Then_21_Should_Be_False_v2()
    {
        var userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Tomasz", "Kowalski", "Kowalski.tomasz@gmail.com", new DateTime(2003, 4, 20), 2);
        Assert.False(value);
    }
    
    [Fact]
    public void TestAddUser_Age_Less_Then_21_Should_Be_False_v3()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        Assert.Throws<ArgumentException>(() =>
        {
            userService.AddUser("Tomasz", "Kowalski", "Kowalski.tomasz@gmail.com", new DateTime(1999, 4, 20), -200);
        });
    }



    [Fact] public void TestAddUser_Client_id2_VeryImportantClient_Should_Be_True()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Jan", "Malewski", "malewski@gmail.com", new DateTime(1990, 4, 20), 2);
        Assert.True(value);
    }
    
    [Fact] public void TestAddUser_Client_id1_NormalClient_Should_Be_False()
    {
        LegacyApp.UserService userService = new LegacyApp.UserService();
        bool value = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(1990, 4, 20), 1);
        Assert.False(value);
    }
    
    // [Fact]
    // public void TestAddUser_()
    // {
    //     var userService = new LegacyApp.UserService();
    //     bool value = userService.AddUser("Tomasz", "Kowalski", "test*gmail.com", new DateTime(1999, 3, 7), 1);
    //     Assert.False(value);
    // }
}