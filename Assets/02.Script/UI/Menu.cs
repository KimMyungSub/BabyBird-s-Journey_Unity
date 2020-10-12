using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject BaseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!GameManager.isPause)
            {
                OpenMeun();
            }
            else
            {
                CloseMeun();
            }
        }
    }

    private void OpenMeun()
    {
        GameManager.isPause = true; //정지활성화
        BaseUI.SetActive(true); //매뉴창 캔버스 활성화
        Time.timeScale = 0f;
    }

    private void CloseMeun()
    {
        GameManager.isPause = false;
        BaseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickMenuClose()
    {
        CloseMeun();
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
