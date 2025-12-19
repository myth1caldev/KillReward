// Coded by @mythical.dev

using Oxide.Core;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("KillReward", "mythical.dev", "1.0.0")]
    [Description("Heals player and reloads weapon after a kill.")]
    public class KillReward : RustPlugin
    {
        void OnEntityDeath(BaseCombatEntity entity, HitInfo info)
        {
            var victim = entity as BasePlayer;
            if (victim == null) return;

            if (info?.Initiator is BasePlayer killer)
            {
                killer.health = killer.MaxHealth();

                var weapon = killer.GetActiveItem()?.GetHeldEntity() as BaseProjectile;
                if (weapon != null)
                {
                    weapon.primaryMagazine.contents = weapon.primaryMagazine.capacity;
                    weapon.SendNetworkUpdateImmediate();
                }
            }
        }
    }
}
