using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera camera1;
    [SerializeField] Material cameraMat1;

    [SerializeField] Camera camera2;
    [SerializeField] Material cameraMat2;

    private void Start()
    {
        if(camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }
        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat1.mainTexture = camera1.targetTexture;
        
        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat2.mainTexture = camera2.targetTexture;
    }
}
