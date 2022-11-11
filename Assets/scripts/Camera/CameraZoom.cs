using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera virtCamera;
    float baseZoom, yOffset, duration = 1.5f, zoom1, zoom2;
    private float elapsed = 0.0f;
    private bool transition = false;
    CinemachineFramingTransposer camOffset;

    void Start()
    {
        Camera.main.orthographic = true;
        baseZoom = Camera.main.orthographicSize;
        camOffset = virtCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void Update()
    {
        if (transition)
        {
            elapsed += Time.deltaTime / duration;
            virtCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoom1, zoom2, elapsed);
            camOffset.m_TrackedObjectOffset = new Vector3(0, Mathf.Lerp(Mathf.Min(0, yOffset), Mathf.Max(0, yOffset), elapsed)) ;
            if (elapsed > 1.0f)
            {
                transition = false;
            }
        }
    }

    public void ZoomCamera(float zoomVal, float YOffset = 0)
    {
        zoom1 = virtCamera.m_Lens.OrthographicSize;
        zoom2 = zoomVal;
        transition = true;
        elapsed = 0.0f;
        yOffset = YOffset;
    }

    public void ResetCamera()
    {
        zoom1 = virtCamera.m_Lens.OrthographicSize;
        zoom2 = baseZoom;
        transition = true;
        elapsed = 0.0f;
        yOffset = 0;
    }
}
