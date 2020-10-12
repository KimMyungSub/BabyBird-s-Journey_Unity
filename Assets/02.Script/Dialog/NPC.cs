using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(3, 7)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    //void Update()
    //{       
         ////주석지우면 대화NPC머리위로 표시되지만 위치가 이상하게 잡혀서 주석처리함     
    //    Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
    //    Pos.y += 115;
    //    ChatBackGround.position = Pos;
    //}

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        //충돌한 오브젝트의 tag가 Player일때만 활성화
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {     
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}