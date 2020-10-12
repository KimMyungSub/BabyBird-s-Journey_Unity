using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI; 

public class Doors : MonoBehaviour
{
    private Animator boorAni;
    private float count;
    private bool isOpen = false;
    private OpenLogSystem OpenLog;

    private AudioSource audioSource;

    void Start()
    {
        boorAni = GetComponent<Animator>();
        OpenLog = FindObjectOfType<OpenLogSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isOpen) count += 1f;
        if (Time.deltaTime * count >= 5)
        {
            boorAni.SetTrigger("Close");
            isOpen = false;
            count = 0;
        }
    }

    public void OnTriggerStay(Collider player)
    {
        if (!isOpen)
        {
            OpenLog.DoorOpen();
            if (player.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
                audioSource.Play();
                OpenLog.DoorClose();
                boorAni.SetTrigger("Open");
            }
        }
    }

    public void OnTriggerExit()
    {
        OpenLog.DoorClose();
    }
}
