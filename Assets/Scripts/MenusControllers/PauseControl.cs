using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public Camera mainCamera;
    public Camera pauseMenuCamera;

    void Start()
    {
        pauseMenu.SetActive(false); // Make sure the pause menu is hidden at start
        mainCamera.enabled = true;
        pauseMenuCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log(isPaused);
        Time.timeScale = isPaused? 0 : 1;
        pauseMenu.SetActive(isPaused);
        if(isPaused){
            mainCamera.gameObject.tag = "Untagged";
            mainCamera.enabled = false;
            pauseMenuCamera.gameObject.tag = "MainCamera";
            pauseMenuCamera.enabled = true;
        } else {
            mainCamera.gameObject.tag = "MainCamera";
            mainCamera.enabled = true;
            pauseMenuCamera.gameObject.tag = "Untagged";
            pauseMenuCamera.enabled = false;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        Time.timeScale = isPaused? 0 : 1;
        pauseMenu.SetActive(isPaused); // Show or hide the pause menu
    }
}