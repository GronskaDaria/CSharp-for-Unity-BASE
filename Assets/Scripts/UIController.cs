using TMPro;
using UnityEngine;
using Unity.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject finishSuccessUi;
    
    void Update()
    {
        coinsText.text = DataContainer.Coins.ToString();
        hpText.text = DataContainer.Hp.ToString();

    }
    
    public void FinishSuccessGame()
    {
        finishSuccessUi.gameObject.SetActive(true);
    }
}
