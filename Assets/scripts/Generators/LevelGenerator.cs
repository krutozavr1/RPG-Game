using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    int maxLevelQuantity = 3;
    int curLevelCnt = 0;
    [SerializeField]
    GameObject roomPrefab, startRoom;
    public static Vector2 nextRoomStartPos;
    List<GameObject> rooms = new List<GameObject>();
    void Start()
    {
        StartCoroutine(GenerateLevel());
    }

    void Update()
    {
    }

    IEnumerator GenerateLevel()
    {
        GenerateStartRoom();
        for (int i = 0; i < maxLevelQuantity; i++)
        {
            GenerateOneRoom();
            yield return new WaitForSeconds(.3f);
        }
    }

    void GenerateStartRoom()
    {
        GameObject room = Instantiate(startRoom, Vector3.zero, Quaternion.identity);
        rooms.Add(room);
        nextRoomStartPos = new Vector2(.25f, 1.7f + .5f);
    }

    void GenerateOneRoom()
    {
        
        GameObject room =  Instantiate(roomPrefab, nextRoomStartPos, Quaternion.identity);
        rooms.Add(room);
        if (curLevelCnt % 4 == 0)
        {
            room.GetComponent<BasicRoomGenerator>().hasShop = true;
        }
        curLevelCnt++;
    }

    public void ContinueLevel()
    {
        Destroy(rooms[0]);
        rooms.Remove(rooms[0]);
        GenerateOneRoom();
    }

    void ReloadLevel()
    {
        foreach (GameObject room in rooms)
        {
            Destroy(room);
        }
        rooms.Clear();
        Debug.ClearDeveloperConsole();
        StartCoroutine(GenerateLevel());
    }
}
