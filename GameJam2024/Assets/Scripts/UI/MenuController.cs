using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    #region Singleton
    public static MenuController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject hudMenu;
    public GameObject pauseMenu;
    public bool showPauseMenu;
    public GameObject gameOverMenu;

    public CharacterChecks _characterChecks;
    public CharacterHealth _characterHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        //_characterHealth = GameObject.Find("Player").GetComponent<CharacterHealth>();
        //_characterChecks = GameObject.Find("Player").GetComponent<CharacterChecks>();
        hudMenu.SetActive(true);
        pauseMenu.SetActive(false);
        showPauseMenu = false;
        gameOverMenu.SetActive(false);   

        CharacterHealth.OnDie += GameOver;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }



    public void PauseGame()
    {
        showPauseMenu = !showPauseMenu;
        if(showPauseMenu)
        {
            _characterChecks.SetKeyBoardInput(false);
            _characterChecks.StopTime(true);
        }
        else
        {
            _characterChecks.SetKeyBoardInput(true);
            _characterChecks.StopTime(false);
        }
        pauseMenu.SetActive(showPauseMenu);
    }

    public void ResumeGame()
    {
        showPauseMenu = false;
        pauseMenu.SetActive(false);
        _characterChecks.SetKeyBoardInput(true);
        _characterChecks.StopTime(false);
    }


    public void GameOver()
    {
        StartCoroutine(TimeToShowGameOverMenu());
    }




    IEnumerator TimeToShowGameOverMenu()
    {
        yield return new WaitForSeconds(2.0f);
        gameOverMenu.SetActive(true);
    }
   

   void OnDestroy()
   {
       CharacterHealth.OnDie -= GameOver;
   }

}
