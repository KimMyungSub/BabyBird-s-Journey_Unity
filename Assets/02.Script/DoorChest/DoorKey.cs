using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DoorKey : MonoBehaviour
{
    bool inTrigger;
    private OpenLogSystem OpenLog;

    private void Start()
    {
        OpenLog = FindObjectOfType<OpenLogSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        OpenLog.KeyPickUp();
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        OpenLog.PickUpCompelet();
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DoorScripts.doorKey = true;
                OpenLog.PickUpCompelet();
                Destroy(this.gameObject);           
            }
        }
    }

}