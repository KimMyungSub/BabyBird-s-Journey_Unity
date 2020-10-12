using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTriggerOnly : MonoBehaviour
{
    public GameObject GameClearUI;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.isClear = true;
        GameClearUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
