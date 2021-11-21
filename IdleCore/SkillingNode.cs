using System;
using System.Collections.Generic;

namespace IdleCore
{
    public class SkillingNode
    {
        private readonly List<IRequirement> _requirements;
        private DropTable _rewardDropTable;
        private bool PlayerHasRequirements(Player player) => _requirements.TrueForAll(requirement => requirement.HasRequirements(player));

        private IdleTask _currentIdleTask;

        public SkillingNode(List<IRequirement> requirements, DropTable rewardDropTable)
        {
            _requirements = requirements;
            _rewardDropTable = rewardDropTable;
        }
        
        public void Enter(Player player)
        {
            if (PlayerHasRequirements(player))
            {
                _currentIdleTask = new IdleTask(10, CompletedTask, new SkillingArgs(player));
            }
        }

        private void CompletedTask(object sender, EventArgs eventArgs)
        {
            _rewardDropTable.Roll(((SkillingArgs)eventArgs).Player.LootRandomizer);
        }
    }
}