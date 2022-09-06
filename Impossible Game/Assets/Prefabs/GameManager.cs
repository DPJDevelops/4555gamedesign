
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private bool gameHasEnded = false;
    public float restartdelay = 1f;

    public GameObject completeLevelUI;
    
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void Endgame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            Debug.Log("gameover");
            Restart();
            Invoke("Restart", restartdelay);
            // DontDestroyOnLoad(MusicOn);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
