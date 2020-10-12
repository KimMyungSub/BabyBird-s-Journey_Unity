using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject[] puzzle;    //퍼즐들 넣는곳~
    public GameObject gameManager; 
    public Material colorThis; //색상변경용 마테리얼 별도색 지정안해도 아래서 해줌
    public AudioClip playSE;
    public bool on = false; //퍼즐 켜졌냐 꺼졌냐!
    private int num; //퍼즐 순서들

    private GameManager GM; //게임 메니져용
    private AudioSource SE; //발판밟으면 나는 소리~

    public bool puzzleEnd; //아따 퍼즐들이 다 켜졌구만유

    private Color32 red = new Color32(255, 0, 0, 120); //빨강에 약간 투명
    private Color32 Blue = new Color32(0, 0, 255, 120); //파랑에 약간 투명

    void Start()
    {
        colorThis = GetComponent<MeshRenderer>().material;
        GM = gameManager.GetComponent<GameManager>();
        SE = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleEnd) return;
        
        for (int i = 0; i < puzzle.Length; ++i)
        {
            if (puzzle[i] == gameObject)
            {
                num = i;
                break;
            }
        }

        SE.clip = playSE;
        SE.Play();

        colorThis.color = !on ? Blue : red; 
        on = !on ? true : false;
        GM.PuzzleCount += on ? 1 : -1;

        if (num % 3 != 0)
        {
            Puzzle pz = puzzle[num - 1].GetComponent<Puzzle>();

            pz.colorThis.color = !pz.on ? Blue : red;
            pz.on = !pz.on ? true : false;
            GM.PuzzleCount += pz.on ? 1 : -1;
        }

        if (num % 3 != 2)
        {
            Puzzle pz = puzzle[num + 1].GetComponent<Puzzle>();
            pz.colorThis.color = !pz.on ? Blue : red;
            pz.on = !pz.on ? true : false;
            GM.PuzzleCount += pz.on ? 1 : -1;
        }

        if (num / 3 != 0)
        {
            Puzzle pz = puzzle[num - 3].GetComponent<Puzzle>();
            pz.colorThis.color = !pz.on ? Blue : red;
            pz.on = !pz.on ? true : false;
            GM.PuzzleCount += pz.on ? 1 : -1;
        }

        if (num / 3 < 2)
        {
            Puzzle pz = puzzle[num + 3].GetComponent<Puzzle>();
            pz.colorThis.color = !pz.on ? Blue : red;
            pz.on = !pz.on ? true : false;
            GM.PuzzleCount += pz.on ? 1 : -1;
        }

        if (GM.PuzzleCount >= 9) //다 켜질시에
        {
            GM.PuzzleClear();    
            foreach (GameObject pz in puzzle)
            {
                Puzzle pzS = pz.GetComponent<Puzzle>();
                pzS.puzzleEnd = true;
            }
        }
    }
}
