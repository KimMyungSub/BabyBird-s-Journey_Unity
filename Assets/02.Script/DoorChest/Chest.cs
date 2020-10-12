using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator ChestAni; //상자 애니
    private AudioSource SE; //상자 열때소리
    private bool isOpen = false; //열렸냐, 닫혔냐
    private OpenLogSystem OpenLog; //상자 여는키 보는거

    public GameObject objet;
    public AudioClip playSe;

    void Start()
    {
        ChestAni = GetComponent<Animator>();
        OpenLog = FindObjectOfType<OpenLogSystem>();
        SE = GetComponent<AudioSource>();
    }

    public void OnTriggerStay(Collider player)
    {
        if (!isOpen)
        {
            OpenLog.DoorOpen();
            if (player.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
                SE.clip = playSe;
                SE.Play();
                OpenLog.DoorClose();
                ChestAni.SetTrigger("Open");
            }
        }

        if(isOpen && objet != null)
        {
            objet.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        OpenLog.DoorClose();
    }
}