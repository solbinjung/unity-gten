using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player;
    public GameObject gameStart; 
    public GameObject gameStory; 
    public GameObject restartButton;
    public GameObject playerHp;
    

    public CanvasGroup gameStartImageCanvasGroup;
    public CanvasGroup gameStoryImage_1CanvasGroup;
    public CanvasGroup gameStoryImage_2CanvasGroup;
    public CanvasGroup gameStoryImage_3CanvasGroup;
    public CanvasGroup gameEndingImageCanvasGroup;
    public CanvasGroup gameoverImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerDied;

    float m_Timer;

    void Start()
    {
        restartButton.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        Player playerScript = player.GetComponent<Player>();

        if (m_IsPlayerAtExit)
        {
            // 게임을 완수했을 때
            Invoke("EndLevelWithCanvasGroup", 5.0f);
        }
        else if (playerScript.curHp <= 0)
        {
            restartButton.SetActive(true); // 재시작 버튼 활성화
            // 게임 중간에 죽었을 때
            EndLevel(gameoverImageCanvasGroup);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup)
    {
        // 게임엔딩 
        playerHp.SetActive(false); 

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Invoke("GameEnd", 10f);
        }
    }
    void GameEnd()
    {
        SceneManager.LoadScene("GTen_final");
    }
    void EndLevelWithCanvasGroup()
    {
        EndLevel(gameEndingImageCanvasGroup);
    }
    public void OnClickRestart()
    {
        // 게임 재시작 버튼
        Debug.Log("Restart button clicked");
        SceneManager.LoadScene("GTen_final");
    }
    public void OnClickStart()
    {
        // 게임 시작 버튼
        StartCoroutine(FadeOut(gameStoryImage_1CanvasGroup, 3f));
        StartCoroutine(FadeOut(gameStoryImage_2CanvasGroup, 6f));
        StartCoroutine(FadeOut(gameStoryImage_3CanvasGroup, 9f));
    }
    IEnumerator FadeOut(CanvasGroup imageCanvasGroup, float time)
    {
        // 스토리 이미지 흐림 효과
        yield return new WaitForSeconds(time);

        while (imageCanvasGroup.alpha > 0)
        {
            imageCanvasGroup.alpha -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5f);

        gameStory.SetActive(false);
        playerHp.SetActive(true);
    }
}