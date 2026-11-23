using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject finishSuccessUi;
    [SerializeField] private GameObject finishFailUi;
    [SerializeField] private TMP_Text successScoreText;
    [SerializeField] private TMP_Text failScoreText;
    [SerializeField] private string mainMenuScene = "MainMenu";
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private UnityEngine.UI.Image keyIcon;

    private static readonly Color KeyMissingColor = new Color(1f, 1f, 1f, 0.35f);
    private RewardSystem _rewardSystem;

    void Start()
    {
        _rewardSystem = FindFirstObjectByType<RewardSystem>();
    }

    void Update()
    {
        int totalCoins = _rewardSystem != null ? _rewardSystem.TotalCoins : 0;
        coinsText.text = FormatProgress(DataContainer.Coins, totalCoins);
        hpText.text = DataContainer.Hp.ToString();

        if (keyText != null)
        {
            keyText.text = FormatProgress(DataContainer.HasKey ? 1 : 0, 1);
        }

        if (keyIcon != null)
        {
            keyIcon.color = DataContainer.HasKey ? Color.white : KeyMissingColor;
        }
    }

    // "12/115" with the total a bit smaller, so it fits in the HUD.
    public static string FormatProgress(int collected, int total)
    {
        if (total <= 0)
        {
            return collected.ToString();
        }

        return $"{collected}<size=60%>/{total}</size>";
    }

    public void FinishSuccessGame()
    {
        ShowScore(successScoreText);
        finishSuccessUi.SetActive(true);
    }

    public static string GetNextLevelName(int buildIndex)
    {
        if (buildIndex < 0 || buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            return null;
        }

        string path = SceneUtility.GetScenePathByBuildIndex(buildIndex + 1);
        return System.IO.Path.GetFileNameWithoutExtension(path);
    }

    public void FinishFailGame()
    {
        if (finishFailUi == null)
        {
            Debug.LogWarning("UIController: finishFailUi is not assigned in the Inspector.");
            return;
        }

        ShowScore(failScoreText);
        finishFailUi.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    private void ShowScore(TMP_Text scoreText)
    {
        if (scoreText != null)
        {
            scoreText.text = DataContainer.Coins.ToString();
        }
    }
}