using System;
using FluentAssertions;
using Xunit;

namespace IdleCore.Tests
{
    public class IdleTaskTests
    {
        [Theory]
        [InlineData(10, 1, 10, true)]
        [InlineData(10, 1000, 0.01f, true)]
        [InlineData(10, 100, 100, true)]
        [InlineData(10, 1, 1, false)]
        [InlineData(10, 1000, 0.0001f, false)]
        public void Tick_ConsumesDelta_ShouldHaveCorrectCompletionState(float taskTime, int times, float delta, bool expected)
        {
            bool completed = false;
            IdleTask idleTask = new IdleTask(taskTime, (_, _) => { completed = true; }, EventArgs.Empty);

            for (int i = 0; i < times; i++)
            {
                idleTask.Tick(delta);
            }

            completed.Should().Be(expected);
        }

        [Fact]
        public void OnCompletion_PassingArgs_ShouldUseArgsToInvoke()
        {
            Player player = new Player(new Random());
            bool completed = false;
            IdleTask idleTask = new IdleTask(1, OnCompletion, new SkillingArgs(player));
            idleTask.Tick(1);

            completed.Should().BeTrue();
            
            void OnCompletion(object o, EventArgs eventArgs)
            {
                eventArgs.Should().BeOfType<SkillingArgs>();
                ((SkillingArgs)eventArgs).Player.Should().Be(player);
                
                completed = true;
            }
        }
    }
}