using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRoomGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject exitBlockPrefab, blockPrefab, roomEnterTrigger, floorPrefab, wallTorchPrefab;
    int[] valsForRand = new int[] { -1, 1 };
    [SerializeField]
    int maxQuantityOfRows,minQuantityOfRows, rows, colomns, horCondition;
    [SerializeField]
    List<Sprite> wallSprites = new List<Sprite>(), floorSprites = new List<Sprite>();
    GameObject exitBlock;
    StoneGenerator stoneGen;
    EnemyGenerator enemyGen;
    InGameCollectablesGenerator collectablesGen;
    DecorationGenerator decGen;
    public Vector2 startPos;
    Vector2 exitBlockPos, exitPos;
    Vector3 firstBlockPos, lastBlockPos;
    string[,] matrix;
    float area = 0;
    public bool hasShop = false, playerEnteredTheRoom = false, enemiesSpawned = false;

    void Start()
    {
        startPos = transform.position;
        stoneGen = GetComponent<StoneGenerator>();
        enemyGen = GetComponent<EnemyGenerator>();
        collectablesGen = GetComponent<InGameCollectablesGenerator>();
        decGen = GetComponent<DecorationGenerator>();
        GenerateRandomMatrix();
        
    }

    private void Update()
    {
        if((playerEnteredTheRoom) && (!enemiesSpawned))
        {
            enemyGen.SetRoomMetrics(firstBlockPos, lastBlockPos, area);
            enemiesSpawned = true;
        }
    }

    void GenerateRandomMatrix()
    {
        DefineMetrics();
        CalculateArea();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colomns; j++)
            {
                if (((i == 0) || (i == rows - 1)) || ((j == 0) || (j == colomns - 1)))
                {
                    matrix[i, j] = "wall";

                }
                else matrix[i, j] = "floor"; 

            }
        }
        GenerateRoom();
    }

    void DefineMetrics()
    {
        rows = Random.Range(minQuantityOfRows, maxQuantityOfRows);
        colomns = Random.Range(minQuantityOfRows, maxQuantityOfRows);
        matrix = new string[rows, colomns];
    }

    void CalculateArea()
    {
        area = colomns * rows * .5f;
    }


    void GenerateRoom()
    {

        CreateWallsAndFloor();
        stoneGen.SetRoomMetrics(firstBlockPos, lastBlockPos, area);
        collectablesGen.SetRoomMetrics(firstBlockPos, lastBlockPos, area);
        decGen.SetRoomMetrics(firstBlockPos, lastBlockPos, area);
        if(hasShop)
        {
            collectablesGen.SpawnShop();
            hasShop = false;
        }
    }

    void CreateWallsAndFloor()
    {
        horCondition = valsForRand[Random.Range(0, 2)];//horizontal reversal depends on it
        startPos += new Vector2(-horCondition * .5f, 0);
        CreateExit();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colomns; j++)
            {

                if ((matrix[i, j] == "wall") && (exitBlockPos != new Vector2(i, j)))
                {
                    GameObject block = Instantiate(blockPrefab, startPos + new Vector2(i * .5f * horCondition, j * .5f), Quaternion.identity);
                    block.transform.parent = transform;
                    //finding room enter block
                    if (block.transform.position == (Vector3)(startPos + new Vector2(.5f * horCondition, 0)))
                    {
                        BoxCollider2D colider = gameObject.AddComponent<BoxCollider2D>();
                        colider.isTrigger = true;
                        colider.size /= 2;
                        Destroy(block);
                    }
                    else if (Random.Range(0, 10) == 0)
                    {
                        GameObject torch = Instantiate(wallTorchPrefab, block.transform.position, Quaternion.identity);
                        torch.transform.Rotate(new Vector3(0, 180 * Random.Range(0, 2), 0));
                        torch.transform.parent = gameObject.transform;
                    }
                    FindFirstAndLastBlocks(i, j, block);
                   //block.transform.parent = gameObject.transform;
                    block.GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, wallSprites.Count)];
                    
                }


            }


        }
        LevelGenerator.nextRoomStartPos = exitPos + new Vector2(0, .5f);

    }

    void CreateExit()
    {
        int i = Random.Range(1, rows - 2);
        int j = colomns - 1;
        exitPos = startPos + new Vector2(i * .5f * horCondition, j * .5f);
        exitBlockPos = new Vector2(i, j);
        exitBlock = Instantiate(exitBlockPrefab, exitPos, Quaternion.identity);
        exitBlock.transform.parent = gameObject.transform;
    }

    void FindFirstAndLastBlocks(int i, int j, GameObject block)
    {
        if ((i == 0) && (j == 0))
        {
            firstBlockPos = block.transform.position;
        }
        if ((i == rows - 1) && (j == colomns - 1))
        {
            lastBlockPos = block.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerEnteredTheRoom = true;
        }
    }

}
