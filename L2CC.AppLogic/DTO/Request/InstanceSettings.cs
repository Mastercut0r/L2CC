namespace L2CC.AppLogic.DTO.Request
{
    class InstanceSettings
    {
        public bool ClanArena { get; private set; }
        public bool Antharas { get; private set; }
        public bool Baium { get; private set; }
        public bool Zaken { get; private set; }
        public bool DailyQuest { get; private set; }
        public ulong EntranceFee { get; private set; }

        public InstanceSettings(
            bool clanArena,
            bool antharas,
            bool baium,
            bool zaken,
            bool dailyQuest,
            ulong entranceFee)
        {
            ClanArena = clanArena;
            Antharas = antharas;
            Baium = baium;
            Zaken = zaken;
            DailyQuest = dailyQuest;
            EntranceFee = entranceFee;
        }
    }
}
