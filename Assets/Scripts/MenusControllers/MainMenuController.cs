using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    public SceneInfo sceneInfo;

    public void OnReturnMenuButtonClick() {
        Debug.Log("Loading Main menu");
        SceneManager.LoadScene(0);
    }

    public void OnPlayButtonClick() {
        Debug.Log(sceneInfo.currentLevel);
        if(sceneInfo.currentLevel == 1)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        } else if(sceneInfo.currentLevel == 2){
            SceneManager.LoadScene(4);
            Time.timeScale = 1;
        }
    }
    // Start is called before the first frame update

    public void OnProfileButtonClick() {
        Debug.Log("Loading profile scene");
        SceneManager.LoadScene(3);
    }

    public void OnExitButtonClick() {
        Debug.Log("Closing Game");
        Application.Quit();
    }
}
