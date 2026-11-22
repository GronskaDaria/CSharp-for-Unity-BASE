using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private Coin[] coins;
    private UIController _uiController;
    
    private void Awake()
    {
        DataContainer.ResetData();
    }

    private void Start()
    {
        _uiController = FindFirstObjectByType<UIController>();
    }

    public void AddCoin()
    {
        DataContainer.Coins++;

        if (DataContainer.Coins >= coins.Length)
        {
            _uiController.FinishSuccessGame();
        }
    }
}