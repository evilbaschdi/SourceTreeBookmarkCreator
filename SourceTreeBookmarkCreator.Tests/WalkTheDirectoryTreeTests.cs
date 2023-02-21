using SourceTreeBookmarkCreator.Internal;

namespace SourceTreeBookmarkCreator.Tests;

public class WalkTheDirectoryTreeTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WalkTheDirectoryTree).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WalkTheDirectoryTree sut)
    {
        sut.Should().BeAssignableTo<IWalkTheDirectoryTree>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WalkTheDirectoryTree).GetMethods().Where(method => !method.IsAbstract));
    }
}