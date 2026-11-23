using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string firstLevelScene = "Level1";
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text bestScoreText;

    void Start()
    {
        Play();
    }

    public void Play()
    {
        LoadLevel(firstLevelScene);
    }

    private static void LoadLevel(string scene)
    {
        DataContainer.ResetData();
        TutorialPopup.WasShown = false;
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
