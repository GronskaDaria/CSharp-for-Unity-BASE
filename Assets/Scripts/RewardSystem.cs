using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private Coin[] coins;

    public int TotalCoins => coins != null ? coins.Length : 0;

    public bool AllCoinsCollected => DataContainer.Coins >= TotalCoins;

    private void Awake()
    {
        DataContainer.ResetData();
    }

    public void AddCoin()
    {
        DataContainer.Coins++;
    }
}
