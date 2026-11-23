using UnityEngine;

public static class DataContainer
{
    private const int StartHp = 3;

    public static int Coins;
    public static int Hp = StartHp;
    public static bool HasKey;

    public static void ResetData()
    {
        Coins = 0;
        Hp = StartHp;
        HasKey = false;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetOnPlayModeStart()
    {
        ResetData();
    }
}