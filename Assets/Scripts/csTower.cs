using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTower : MonoBehaviour
{
    public float climbSpeed = 5f; // 사다리를 타고 올라가는 속도

    private bool isClimbing = false;
    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isClimbing)
        {
            ClimbLadder();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 사다리에 접촉한 경우
        if (other.CompareTag("Tower"))
        {
            isClimbing = true;
            // 플레이어의 중력을 해제하여 중력에 의한 하강을 막음
            playerRigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 사다리에서 벗어난 경우
        if (other.CompareTag("Tower"))
        {
            isClimbing = false;
            // 플레이어의 중력을 다시 활성화
            playerRigidbody.useGravity = true;
        }
    }

    private void ClimbLadder()
    {
        // 플레이어를 위로 이동시키는 로직
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 climbMovement = new Vector3(0f, verticalInput * climbSpeed * Time.deltaTime, 0f);
        transform.Translate(climbMovement);
    }
}
