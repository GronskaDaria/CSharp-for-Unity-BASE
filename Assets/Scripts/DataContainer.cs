using UnityEngine;

public static class DataContainer
{
    private const int StartHp = 3;

    public static int Coins;
    public static int Hp = StartHp;

    // Static fields survive scene reloads (and Play Mode restarts when Domain Reload is disabled),
    // so they have to be reset explicitly when a level starts.
    public static void ResetData()
    {
        Coins = 0;
        Hp = StartHp;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetOnPlayModeStart()
    {
        ResetData();
    }
}