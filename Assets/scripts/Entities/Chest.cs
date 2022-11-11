using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Chest : MonoBehaviour
{
    [SerializeField]List<GameObject> objects = new List<GameObject>();
    bool canOpen = false, isOpened = false;

    void Update()
    {
        if ((Keyboard.current.eKey.wasReleasedThisFrame) && (canOpen) && (!isOpened))
        {
            OpenChest();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpen = false;
        }
    }

    private void OpenChest()
    {
        GetComponent<Animator>().SetTrigger("Open");
        isOpened = true;
    }

    private void DropContent()//called from anim
    {
        foreach(GameObject obj in objects)
        {
            GameObject content = Instantiate(obj, transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);
            content.transform.parent = transform.parent;
        }
    }

}
