
using Generic;

[TestFixture]
public class ComparablePairTest
{
    [Test]
    public void CompareTo_FirstPropertyDifferent_ReturnsCorrectComparison()
    {
        // Arrange
        var pair1 = new ComparablePair<int, string>(5, "Hello");
        var pair2 = new ComparablePair<int, string>(10, "World");

        // Act
        int result = pair1.CompareTo(pair2);

        // Assert
        Assert.Less(result, 0);
    }

    [Test]
    public void CompareTo_FirstPropertyEqual_SecondPropertyDifferent_ReturnsCorrectComparison()
    {
        // Arrange
        var pair1 = new ComparablePair<int, string>(5, "Hello");
        var pair2 = new ComparablePair<int, string>(5, "World");

        // Act
        int result = pair1.CompareTo(pair2);

        // Assert
        Assert.Less(result, 0);
    }

    [Test]
    public void CompareTo_BothPropertiesEqual_ReturnsZero()
    {
        // Arrange
        var pair1 = new ComparablePair<int, string>(5, "Hello");
        var pair2 = new ComparablePair<int, string>(5, "Hello");

        // Act
        int result = pair1.CompareTo(pair2);

        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void CompareTo_BothPropertiesDifferent_ReturnsCorrectComparison()
    {
        // Arrange
        var pair1 = new ComparablePair<int, string>(10, "Hello");
        var pair2 = new ComparablePair<int, string>(5, "World");

        // Act
        int result = pair1.CompareTo(pair2);

        // Assert
        Assert.Greater(result, 0);
    }
}
