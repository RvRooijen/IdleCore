using Xunit;

namespace IdleCore.Tests
{
    public class SkillTests
    {
        [Fact]
        public void NewSkill()
        {
            Skill skill = new Skill("Woodcutting");
        }
    }
}