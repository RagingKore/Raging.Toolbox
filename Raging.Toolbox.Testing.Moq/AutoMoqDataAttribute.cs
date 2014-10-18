using Ploeh.AutoFixture.NUnit2;

namespace Raging.Toolbox.Testing.Moq
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(Auto.Fixture)
        {
        }
    }
}