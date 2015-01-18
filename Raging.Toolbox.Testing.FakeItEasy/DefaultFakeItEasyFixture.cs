using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;

namespace Raging.Toolbox.Testing.FakeItEasy
{
    /// <summary> 
    ///     Provides anonymous object creation services by using FakeItEasy.
    /// </summary>
    /// <seealso cref="T:Ploeh.AutoFixture.Fixture"/>
    public class DefaultFakeItEasyFixture : Fixture
    {
        private const int DefaultRecursionDepth = 5;
        private const int DefaultRepeatCount    = 2;

        public DefaultFakeItEasyFixture() 
            : this(DefaultRecursionDepth, DefaultRepeatCount) { }

        public DefaultFakeItEasyFixture(int repeatCount) 
            : this(DefaultRecursionDepth, repeatCount) { }

        public DefaultFakeItEasyFixture(int recursionDepth, int repeatCount)
        {
            this.Customize(new AutoFakeItEasyCustomization());

            this.RepeatCount = repeatCount;

            if(recursionDepth > 0)
            {
                this.Behaviors.Clear();
                this.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
            }
        }
    }
}