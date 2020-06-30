using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Tests.Config
{
    public static class TestDataGenerator
    {
        public static Material GetMaterial()
        {
            return new Material
            {
                Name = "TestMaterial",
                Specification = "TestSpec"
            };
        }
    }
}