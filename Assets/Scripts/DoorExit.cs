using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] private Door door;
    private bool _finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Finish();
        }
    }

    public void Finish()
    {
        if (_finished || door == null || !door.IsOpen)
        {
            return;
        }

        _finished = true;
        UIController ui = FindFirstObjectByType<UIController>();
        if (ui != null)
        {
            ui.FinishSuccessGame();
        }
    }
}
