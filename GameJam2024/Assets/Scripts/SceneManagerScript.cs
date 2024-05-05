using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
   #region Singleton
    public static SceneManagerScript Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }


    public void StartGame() //For the Main Menu
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestingCode");
    }


    public void ExitGame() //For the Main Menu
    {
        Application.Quit();
    }


    public void RestartGame() //For the Game Over Menu
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestingCode");
        Time.timeScale = 1;
    }

    public void ExitToMainMenu() //For the Game Over Menu
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
