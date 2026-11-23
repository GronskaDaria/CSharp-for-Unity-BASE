using UnityEngine;
public class TutorialPopup : MonoBehaviour
{
    public static bool WasShown;

    [SerializeField] private GameObject popup;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetOnPlayModeStart()
    {
        WasShown = false;
    }

    void Start()
    {
        if (WasShown)
        {
            Hide();
            return;
        }

        popup.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartLevel()
    {
        WasShown = true;
        Hide();
    }

    private void Hide()
    {
        popup.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
