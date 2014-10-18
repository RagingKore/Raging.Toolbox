using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Raging.Toolbox.Extensions;
using Raging.Toolbox.Testing.Moq;

namespace Raging.Toolbox.Tests.Extensions
{
    public static class FluentAssertionExtensions
    {
        public static void ShouldBeEquivalentTo<T>(
            this T subject,
            object expectation,
            string reason = "",
            params object[] reasonArgs)
        {
            ShouldBeEquivalentTo(subject, expectation, config => config, reason, reasonArgs);
        }

        public static void ShouldBeEquivalentTo<T>(
            this T subject,
            object expectation,
            Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config,
            string reason = "",
            params object[] reasonArgs)
        {
            var context = new EquivalencyValidationContext
            {
                Subject         = subject,
                Expectation     = expectation,
                CompileTimeType = typeof(T),
                Reason          = reason,
                ReasonArgs      = reasonArgs
            };

            var constructedOptions = config(EquivalencyAssertionOptions<T>.Default());

            constructedOptions
                .Using<DateTime>(ctx => ctx.Subject
                .Should()
                .BeCloseTo(ctx.Expectation))
                .WhenTypeIs<DateTime>();

            constructedOptions.AllowingInfiniteRecursion();

            new EquivalencyValidator(constructedOptions).AssertEquality(context);
        }
    }

    [TestFixture]
    public class SerializationExtensionsTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Auto.Fixture
                .Customize<Subject>(composer => composer
                .Do(subject => subject
                .SetPrivateSetter(Auto.Fixture.Create<string>())));
        }

        [Test, AutoMoqData]
        public void ToJson_ConvertsObject_WhenObjectIsValid(Subject example)
        {
            // act
            var result = example.ToJson().FromJson<Subject>();

            // assert
            result.ShouldBeEquivalentTo(example);
        }

        [Test, AutoMoqData]
        public void ToXml_ConvertsObject_WhenObjectIsValid(Subject example)
        {
            // act
            var result = example.ToXml().FromXml<Subject>();

            // assert
            result.ShouldBeEquivalentTo(example);
        }

        [Test, AutoMoqData]
        public void ToBinary_ConvertsObject_WhenObjectIsValid(Subject example)
        {
            // act
            var result = example.ToBinary().FromBinary<Subject>();

            // assert
            result.ShouldBeEquivalentTo(example);
        }

        public class Subject
        {
            public Guid Id { get; set; }

            public int SortOrder { get; set; }

            public string Name { get; set; }

            public DateTime CreatedOn { get; set; }

            public IEnumerable<ChildOfSubject> Children { get; set; }

            public Subject ParentSubject { get; set; }

            public TimeSpan TimeSpan { get; set; }

            public byte[] Data { get; set; }

            public virtual string PrivateSetter { get; private set; }

            public void SetPrivateSetter(string value)
            {
                PrivateSetter = value;
            }
        }

        public class ChildOfSubject
        {
            public long Id { get; set; }
        }
    }

}
