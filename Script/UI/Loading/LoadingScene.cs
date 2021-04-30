using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public Transform LoadingBar;
    public Transform TextLoading;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    private void Update()
    {
        if(currentAmount <= 100)
        {
            currentAmount += speed + Time.deltaTime;
            TextLoading.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
        }   
        if(currentAmount >= 99)
        {
            ChangeGameScene();
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Game");
    }

}
