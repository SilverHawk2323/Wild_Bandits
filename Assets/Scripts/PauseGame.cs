using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public bool gamePaused;
    [SerializeField] GameObject ResumeButton;
    [SerializeField] GameObject ExitButton;
    

    public void Start()
    {
        
    }

    public void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
       {
            Paused();
       }
       else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true)
       {
            Resume();
       }

       if (gamePaused == true)
       {
            Time.timeScale = 0;
       }
       else if (gamePaused == false)
       {
            Time.timeScale = 1;
       }

    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        gamePaused = false;
    }
    
    public void Paused()
    {
        PauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void ExitMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
