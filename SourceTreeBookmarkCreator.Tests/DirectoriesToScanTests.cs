namespace SourceTreeBookmarkCreator.Tests;

public class DirectoriesToScanTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DirectoriesToScan).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(DirectoriesToScan sut)
    {
        sut.Should().BeAssignableTo<IDirectoriesToScan>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DirectoriesToScan).GetMethods().Where(method => !method.IsAbstract));
    }
}