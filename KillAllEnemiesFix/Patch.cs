using HarmonyLib;

namespace KillAllEnemiesFix
{
    [HarmonyPatch(typeof(PLMissionObjective_ReachSectorOfType), "GetNumEnemiesLeft")]
    class Patch
    {
        static bool Prefix(ref int __result)
        {
			int num = 0;
			foreach (PLShipInfoBase plshipInfoBase in PLEncounterManager.Instance.AllShips.Values)
			{
				if (plshipInfoBase != null && plshipInfoBase.TeamID == 1)
				{
					num++;
				}
			}
			foreach (PLPawnBase plpawnBase in PLGameStatic.Instance.AllPawnBases)
			{
				if (plpawnBase != null && !plpawnBase.IsDead && (plpawnBase.MyPlayer == null || plpawnBase.MyPlayer.TeamID == 1))
				{
					num++;
				}
			}
			//PulsarPluginLoader.Utilities.Logger.Info("Ran Prefix for GetNumEnemiesLeft with result " + num.ToString());
			__result = num;
			return false;
		}
    }
	/*[HarmonyPatch(typeof(PLSpawner), "DoSpawnStatic")]
	class Patch2
	{
		static void Postfix(ref bool ___HasSpawnedEnemyBeenSetup, string spawnType)
		{
			//PulsarPluginLoader.Utilities.Logger.Info("Ran DoSpawnStatic fix for a " + spawnType);
			___HasSpawnedEnemyBeenSetup = true;
		}
	}*/
}
