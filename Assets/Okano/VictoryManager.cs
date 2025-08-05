using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] ChefTask chefTask;
    [SerializeField] GameObject guestPanel;
    [SerializeField] GameObject cookPanel;

    private bool hasEnded = false;

    private void Update()
    {
        if (hasEnded) return;

        if (timeManager.isTimeUp)
        {
            HandleCookVictory();
        }
        else if (chefTask.IsGameOver)
        {
            HandleGuestVictory();
        }
    }

    private void HandleCookVictory()
    {
        Debug.Log("—¿—lŸ—˜");
        cookPanel.SetActive(true);
        EndGame();
    }

    private void HandleGuestVictory()
    {
        Debug.Log("‹qŸ—˜");
        guestPanel.SetActive(true);
        EndGame();
    }

    private void EndGame()
    {
        hasEnded = true;
        timeManager.StopTimer();
    }
}
