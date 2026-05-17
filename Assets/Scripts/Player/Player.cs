using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 5f;
    public float rotateSpeed = 8f;

    public int maxHp = 5;
    public int curHp = 5;

    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    float hAxis;
    float vAxis;

    bool jDown;
    bool isJump;

    public AudioSource damageAudio;

    AudioSource m_AudioSource;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    Vector3 m_Movement;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

        curHp = maxHp;

        
    }

    void Update()
    {
        GetInput();
        Run();
        Rotate();
        Jump();
        PlayerHeart();
    }
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");
    }
    void Run()
    {
        //Player 이동
        m_Movement = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += m_Movement * speed * Time.deltaTime;
        m_Animator.SetBool("isRun", m_Movement != Vector3.zero);
    }
    void Rotate()
    {
        //Player 회전
        if (hAxis == 0 && vAxis == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(m_Movement);
        m_Rigidbody.rotation = Quaternion.Slerp(m_Rigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }
    void Jump()
    {
        csObjsInteract cs = GameObject.FindObjectOfType<csObjsInteract>();
        bool isGrabbing = cs.isGrabbing;
        //Player 점프
        if (jDown && !isJump && !isGrabbing)
        {
            m_Rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            m_Animator.SetBool("isJump", true);
            m_Animator.SetTrigger("doJump");
            isJump = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Player 착지
        m_Animator.SetBool("isJump", false);
        isJump = false;

    }
    public void TakeDamage(int damage)
    {
        damageAudio.Play();
        curHp -= damage;

        Debug.Log("Player took damage. Current Health: " + curHp);
        if (curHp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player died");
    }

    public void PlayerHeart()
    {
        if (curHp > numOfHearts)
        {
            curHp = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < curHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
