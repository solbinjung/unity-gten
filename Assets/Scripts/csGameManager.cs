using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csGameManager : MonoBehaviour
{
    private float preY;
    public float maxVerSpeed = 5f;
    public GameObject ch;
    bool isFalling=false;

    public csCheckpoints csCheckpoints;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        CheckFalling();
    }
    void CheckFalling()
    {
        if (!isFalling) // 완전히 멈추고 체크 + 떨어지는 중이 아닐 때만 체크하도록
        {
            // '!' 주목! 플레이어에서 아래로 Raycast를 쐈을 때 아무 것도 없다면 추락 중인것이다. 
            // 추락 중이 아니라면 스테이지의 Plate 와 충돌되야 정상이다.
            if (!Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                Falling();
            }
        }
    }
    void Falling()
    {
        isFalling = true;
        AlmostDie();
    }
    void AlmostDie()
    {
        Invoke("Restart", 3f);
    }
    void Restart()
    {
        Debug.Log("Restart");
        gameObject.transform.position = csCheckpoints.cp;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
