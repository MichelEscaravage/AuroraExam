using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            startMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("EXITING GAME BIATCH");
    }
}
