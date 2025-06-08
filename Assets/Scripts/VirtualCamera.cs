using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X" || axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis(axisName);
            }
            else
            {
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}