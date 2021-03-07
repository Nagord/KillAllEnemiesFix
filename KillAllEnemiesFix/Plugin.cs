using PulsarPluginLoader;

namespace KillAllEnemiesFix
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Fixes bug involving missions detecting enemies which don't exist.";

        public override string Name => "KillAllEnemiesFix";

        public override string HarmonyIdentifier()
        {
            return "Dragon.KillAllEnemiesFix";
        }
    }
}
