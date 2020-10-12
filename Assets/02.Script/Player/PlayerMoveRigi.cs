using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRigi : MonoBehaviour
{
    //속도및 점프력 조정 변수
    public float walkSpeed;
    public float jumpForce;

    // 상태 변수
    private bool isRun = false;
    private bool isGround = true;

    //필요 컴포넌트들
    private CapsuleCollider capsuleCollider;
    private Rigidbody myRigid;
    private Animator playerAni; 

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();
    }

    void Update()
    {
        IsGround();
        Jump();
        Move();
        SpAni();
    }

    // 지면 체크.
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }

    // 점프
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
           myRigid.velocity = transform.up * jumpForce;
           playerAni.SetTrigger("Jump");
        }
    }

    //움직이기
    private void Move()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * horizontal;
        Vector3 _moveVertical = transform.forward * vertical;
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        playerAni.SetBool("Waik", isWalking);

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }


    private void SpAni()
    {
        if (Input.GetButton("Fire1")) playerAni.SetTrigger("Attack");
        if (Input.GetKeyDown(KeyCode.G)) playerAni.SetTrigger("Happy");
        if (Input.GetKeyDown(KeyCode.H)) playerAni.SetTrigger("Hello");
    }

}