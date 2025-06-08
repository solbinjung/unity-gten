using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSkybox : MonoBehaviour
{
    public Material newSkybox; // 변경할 Skybox의 머티리얼을 인스펙터에서 설정할 수 있도록 public 변수를 만듭니다.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와의 충돌을 확인합니다. 플레이어가 다른 태그를 가지고 있다면 해당 태그로 변경하세요.
        {
            ChangeSkybox();
        }
    }

    private void ChangeSkybox()
    {
        RenderSettings.skybox = newSkybox; // Skybox를 변경합니다.
    }
}
