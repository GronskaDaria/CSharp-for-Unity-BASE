using TMPro;
using UnityEngine;
using Unity.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject finishSuccessUi;
    [SerializeField] private GameObject finishFailUi;
    
    void Update()
    {
        coinsText.text = DataContainer.Coins.ToString();
        hpText.text = DataContainer.Hp.ToString();

    }
    
    public void FinishSuccessGame()
    {
        finishSuccessUi.SetActive(true);
    }

    public void FinishFailGame()
    {
        if (finishFailUi == null)
        {
            Debug.LogWarning("UIController: finishFailUi is not assigned in the Inspector.");
            return;
        }

        finishFailUi.SetActive(true);
    }
}
