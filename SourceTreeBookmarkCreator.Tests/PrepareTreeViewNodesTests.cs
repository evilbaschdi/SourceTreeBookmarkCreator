namespace SourceTreeBookmarkCreator.Tests;

public class PrepareTreeViewNodesTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(PrepareTreeViewNodes).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(PrepareTreeViewNodes sut)
    {
        sut.Should().BeAssignableTo<IPrepareTreeViewNodes>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(PrepareTreeViewNodes).GetMethods().Where(method => !method.IsAbstract));
    }
}