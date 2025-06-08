using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csObjsInteract : MonoBehaviour
{
    // Obj 콜라이더에 Player 콜라이더가 enter된 채로 마우스를 클릭 Obj가 Player안에 들어감 ?
    // 마우스 클릭 해제하면 원상복귀 ?
    //Raycast로 물건 인식후 'E'키를 누르면 캐릭터 애니메이션 재생, 물건은 invokerepeating함수를 이용하여 자연스러운 위치 변경, 이후 물건을 캐릭터의 자식으로 지정하여 캐릭터와 함께 움직이도록함.

    Animator animator;
    private GameObject colObj;
    private GameObject ch;

    private bool isColliding = false;
    public bool isGrabbing = false;

    private GameObject Raydir;

    private Rigidbody rb;
    public float jumpPower = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ch = gameObject;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Raydir = GameObject.FindGameObjectWithTag("RayDir");
        //Debug.Log(Vector3.Distance(ch.transform.position, Raydir.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast를 통해 충돌 체크
        Ray ray = new Ray(ch.transform.position + new Vector3(0, 0.2f, 0), (Raydir.transform.position - ch.transform.position).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 0.7f);
            Debug.DrawRay(ch.transform.position + new Vector3(0, 0.2f, 0), (Raydir.transform.position - ch.transform.position).normalized, Color.red, 2f);
            // 충돌한 콜라이더의 태그가 "InteractiveObj"이면 isColliding을 true로 설정
            if (hit.collider.CompareTag("InteractiveObj"))
            {
                isColliding = true;
                colObj = hit.collider.gameObject;
            }
            else
            {
                isColliding = false;
                //colObj = null;
            }

        }
        else
        {
            isColliding = false;
            //colObj = null;
        }

        if (isGrabbing == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && isColliding)
            {
                animator.SetTrigger("PickObj");
                Debug.Log("colliding");
                Invoke("inGrab", 0.5f);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                outGrab();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }

    void inGrab()
    {
        isGrabbing = true;
        Debug.Log("isGrabbing=true");
        animator.SetBool("Grabbing", isGrabbing);
        Vector3 newP = ch.transform.TransformPoint(Vector3.forward * 0.4f + Vector3.up * 0.2f);
        colObj.transform.position = newP;
        colObj.GetComponent<Rigidbody>().isKinematic = true;
        colObj.transform.parent = ch.transform;
        rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX; // X 포지션 해제
        //rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
        rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;
    }

    void outGrab()
    {
        isGrabbing = false;
        Debug.Log("isGrabbing=false");
        animator.SetBool("Grabbing", isGrabbing);
        colObj.GetComponent<Rigidbody>().isKinematic = false;
        colObj.transform.parent = null;
        Debug.Log("분리완료");
        rb.constraints = rb.constraints & ~RigidbodyConstraints.FreezePositionX; // X 포지션 해제
        //rb.constraints = rb.constraints & ~RigidbodyConstraints.FreezePositionY;
        rb.constraints = rb.constraints & ~RigidbodyConstraints.FreezePositionZ;
    }
}
