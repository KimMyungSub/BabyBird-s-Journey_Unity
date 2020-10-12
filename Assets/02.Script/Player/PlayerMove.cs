using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float gravity;    // 캐릭터에게 작용하는 중력.

    Animator playerAni; //플레이어 애니메이션
    CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    Vector3 MoveDir;  // 캐릭터의 움직이는 방향.

    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        playerAni = GetComponent<Animator>();
    }

    void Update()
    {
        // 현재 캐릭터가 땅에 있는가?
        if (controller.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            MoveDir = new Vector3(horizontal, 0, vertical);
            MoveDir = transform.TransformDirection(MoveDir);
            MoveDir *= speed;

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;

            playerAni.SetBool("Waik", isWalking);

            if (Input.GetButton("Jump"))
            {
                MoveDir.y = jumpSpeed;
                playerAni.SetTrigger("Jump");
            }
        }
        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);  
        AttackAni();
        HappyAni();
        HelloAni();
    }

    void AttackAni()
    {
        if (Input.GetButton("Fire1")) playerAni.SetTrigger("Attack");
    }

    void HappyAni()
    {
        if (Input.GetKeyDown(KeyCode.G)) playerAni.SetTrigger("Happy");
    }

    void HelloAni()
    {
        if(Input.GetKeyDown(KeyCode.H))  playerAni.SetTrigger("Hello");
    }
}