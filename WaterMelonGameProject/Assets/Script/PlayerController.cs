using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    private FruitSpawn fruitSpawn;
    public bool isDropped = true;// ������ ����߷ȴ��� �ȶ��� �߷ȴ��� Ȯ��

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       if (isDropped == true)
        {
            fruitSpawn.SpawnFruit();
            isDropped = false;

        }
       if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseFruits();
            isDropped = true;
        }
    }
    
    void ReleaseFruits()
    {
        fruitSpawn.spawnedFruit.GetComponent<Rigidbody>().isKinematic = false;
    }
}