using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace SourceTreeBookmarkCreator.Tests
{
    public class BackupExistingBookmarksFileTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(BackupExistingBookmarksFile).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(BackupExistingBookmarksFile sut)
        {
            sut.Should().BeAssignableTo<IBackupExistingBookmarksFile>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(BackupExistingBookmarksFile).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}