using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public Leaderboard leaderboard;
   public void MainMenu()
    {
        leaderboard.SaveLeaderboard();
        SceneManager.LoadScene("MainMenu");
    }

    public void Reset()
    {
        leaderboard.SaveLeaderboard();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
