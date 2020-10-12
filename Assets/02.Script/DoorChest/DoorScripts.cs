using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
    public static bool doorKey;
    public bool open;
    public bool close = true;
    public bool inTrigger;

    private Animator DoorAni;
    private OpenLogSystem OpenLog;
    private AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        DoorAni = GetComponent<Animator>();
        OpenLog = FindObjectOfType<OpenLogSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        OpenLog.DoorClose();
        OpenLog.CloserDoorComplert();
        OpenLog.KeyOk();
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                        audioSource.clip = clip;
                        audioSource.Play();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }
        }
        DoorAni.SetBool("Open", open);
        DoorAni.SetBool("Close", close);
    }

    private void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                OpenLog.TryCloserDoor(); 
                OpenLog.KeyOk();
                OpenLog.DoorClose();
            }
            else
            {
                if (doorKey)
                {
                    OpenLog.DoorOpen();
                    OpenLog.KeyOk();
                    OpenLog.CloserDoorComplert();
                }
                else
                {
                    OpenLog.KeyPlase();
                    OpenLog.DoorClose();
                    OpenLog.CloserDoorComplert();
                }
            }
        }
    }
}
