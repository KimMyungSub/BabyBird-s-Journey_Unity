using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isCamMove = true;
    public static bool isPause = false;
    public static bool isClear = false;

    public GameObject gameClear;
    public int PuzzleCount;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isPause || isClear)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCamMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCamMove = true;
        }

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if(PuzzleCount == 9)
            {
                PuzzleCount++;
                PuzzleClear();
            }
        }
    }

    public void PuzzleClear()
    {
        gameClear.SetActive(true);
    }
}