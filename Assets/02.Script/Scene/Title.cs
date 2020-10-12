using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "Loding";

    public static Title instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GameStart()
    {
        //시작버튼
        SceneManager.LoadScene(sceneName);
        gameObject.SetActive(false);
    }

    public void Exit()
     {
        //종료버튼
         Application.Quit();
     }
}