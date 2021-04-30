using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CMainMenu : MonoBehaviour {

	public void PlayGame ()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Debug.Log("종료!");
        Application.Quit();
    }
}
