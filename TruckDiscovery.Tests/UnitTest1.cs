using NUnit.Framework;
using TruckDiscovery.Models;

namespace TruckDiscovery.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        DateAttribute date = new DateAttribute();
        string result = date.currentYear;
        Assert.That(result, Is.EqualTo("01/01/2022"));
    }
    [Test]
    public void Test2()
    {
        DateAttribute date = new DateAttribute();
        string result = date.lastDayOfYear;
        Assert.That(result, Is.EqualTo("31/12/2022"));
    }
    [Test]
    public void Test3()
    {
        YearEndAttribute date = new YearEndAttribute();
        string result = date.lastDayOfNextYear;
        Assert.That(result, Is.EqualTo("31/12/2023"));
    }
}
