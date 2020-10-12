using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispMove : MonoBehaviour
{
    public GameObject MoveObj;
    public Transform firstPos;
    public Transform secondPos;
    public Transform endPos;
    public float speed;

    public GameObject RewardMark;
    public GameObject Chest;

    private bool pos1End = false;
    private bool pos2End = false;

    private float timing = 0;

    public void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (!pos1End)
            {
                MoveObj.transform.position = Vector3.Lerp(MoveObj.transform.position, firstPos.position, timing);
                timing += Time.deltaTime * speed;

                if (timing >= 0.1f)
                {
                    timing = 0;
                    pos1End = true;
                }
            }

            if (pos1End && !pos2End)
            {
                MoveObj.transform.position = Vector3.Lerp(MoveObj.transform.position, secondPos.position, timing);
                timing += Time.deltaTime * speed;

                if (timing >= 0.1f)
                {
                    timing = 0;
                    pos2End = true;
                }
            }

            if (pos1End && pos2End)
            {
                MoveObj.transform.position = Vector3.Lerp(MoveObj.transform.position, endPos.position, timing);
                timing += Time.deltaTime * speed;

                if (timing >= 0.1f)
                {
                    Destroy(MoveObj);                    
                    RewardMark.SetActive(true);
                    Chest.SetActive(true);
                }            
            }
        }
    }

    public void OnTriggerExit()
    {
        timing = 0;
    }
}