using TMPro;
using UnityEngine;
using Unity.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text livesText;

    void Update()
    {
        coinsText.text = DataContainer.Coins.ToString();
        livesText.text = DataContainer.Lives.ToString();

    }
}
