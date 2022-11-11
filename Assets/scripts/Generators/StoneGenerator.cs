using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : GameEntitiesGenerator
{

    private void Awake()
    {
        minQuantityOfEntities = 4;
        averageQuantityOfEntities = 5;
        maxQuantityOfEntities = 6;
    }


}
