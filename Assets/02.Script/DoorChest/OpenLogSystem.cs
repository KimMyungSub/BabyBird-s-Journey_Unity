using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLogSystem : MonoBehaviour
{
    //키있을때 활성화
    public GameObject OpenGUI; //열기!
    public GameObject CloseGUI; //닫기!
    //키 없을떄 활성화
    public GameObject KeyInfo;

    //키 획득할때
    public GameObject PickUpKey;


    //문열기
    public void DoorOpen() 
    {
        OpenGUI.SetActive(true);
    }
    public void DoorClose()
    {
        OpenGUI.SetActive(false);
    }

    //키 있는가?
    public void KeyPlase()
    {
        KeyInfo.SetActive(true);
    }

    public void KeyOk()
    {
        KeyInfo.SetActive(false);
    }

    //열쇠 줍기
    public void KeyPickUp()
    {
        PickUpKey.SetActive(true);
    }

    public void PickUpCompelet()
    {
        PickUpKey.SetActive(false);
    }

    //문 닫기
    public void TryCloserDoor()
    {
        CloseGUI.SetActive(true);
    }

    public void CloserDoorComplert()
    {
        CloseGUI.SetActive(false);

    }
}