using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;

    // Start is called before the first frame update
    public void StartFirstLevel()
    {
        
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {           
            gameSession.ResetGame();
        }
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (musicPlayer != null && gameSession != null)
        {
            musicPlayer.ResetMusicPlayer();
            gameSession.ResetGame();
        }
        SceneManager.LoadScene(0);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(LoadGameOverScreen());
    }

    IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
