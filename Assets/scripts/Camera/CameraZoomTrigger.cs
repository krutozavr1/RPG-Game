using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomTrigger : MonoBehaviour
{

    [SerializeField] float size, yOffset;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<CameraZoom>().ZoomCamera(size, yOffset);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       /* if (collision.tag == "Player")
        {
            FindObjectOfType<CameraZoom>().ResetCamera();
        }*/
    }
}
