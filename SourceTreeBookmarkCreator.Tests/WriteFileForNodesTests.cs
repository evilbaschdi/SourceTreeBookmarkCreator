namespace SourceTreeBookmarkCreator.Tests;

public class WriteFileForNodesTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WriteFileForNodes).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WriteFileForNodes sut)
    {
        sut.Should().BeAssignableTo<IWriteFileForNodes>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WriteFileForNodes).GetMethods().Where(method => !method.IsAbstract));
    }
}