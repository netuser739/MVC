using System;

namespace Game
{
    public interface ISaveData
    {
        public void Save(PlayerData player);

        public void Save(BonusData bonus);

        public PlayerData Load();

        public BonusData LoadBonus();

    }
}