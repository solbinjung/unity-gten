using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBGM : MonoBehaviour
{
    public AudioClip start;
    public AudioClip tree;
    public AudioClip bear;
    public AudioClip universe;
    public AudioClip celebrate;

    private AudioSource audioSource;

    public Material Sky2;
    public Material Sky3;
    public Material Sky4;
    public Material Sky5;
    public Material GTen;

    private void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 처음 시작할 때 오디오 A 재생
        audioSource.clip = start;
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 플레이어인지 체크1인지 확인
        if (other.gameObject.name=="CheckPoint2")
        {
            // 오디오 A 멈추고 오디오 B 재생
            RenderSettings.skybox = Sky2;
            audioSource.Stop();
            audioSource.clip = tree;
            audioSource.Play();
        }
        if (other.gameObject.name == "CheckPoint3")
        {
            // 오디오 A 멈추고 오디오 B 재생
            RenderSettings.skybox = Sky3;
            audioSource.Stop();
            audioSource.clip = bear;
            audioSource.Play();
        }
        if (other.gameObject.name == "CheckPoint4")
        {
            // 오디오 A 멈추고 오디오 B 재생
            RenderSettings.skybox = Sky4;
            audioSource.Stop();
            audioSource.clip = universe;
            audioSource.Play();
        }
        if (other.gameObject.name == "CheckPoint5")
        {
            // 오디오 A 멈추고 오디오 B 재생
            RenderSettings.skybox = Sky5;
            audioSource.Stop();
            audioSource.clip = universe;
            audioSource.Play();
        }
        if (other.gameObject.name == "Goal")
        {
            // 오디오 A 멈추고 오디오 B 재생
            RenderSettings.skybox = GTen;
            audioSource.Stop();
            audioSource.clip = celebrate;
            audioSource.Play();
        }
    }
}
