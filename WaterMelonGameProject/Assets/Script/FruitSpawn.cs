using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public List<GameObject> fruitPrefabs; // 소환될 과일 프리팹들을 저장하는 리스트
    private Vector3 spawnPoint = new Vector3(0, 10, 0); // 과일이 스폰될 위치
    public GameObject spawnedFruit; // 소환된 과일
    public GameObject lastSpawnedFruit; // 마지막에 소환된 과일
    public bool isDropped = true;// 과일을 떨어뜨렸는지 안떨어 뜨렸는지 확인
    public int fruitIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        // 과일이 떨어졌다면
        if (isDropped == true && spawnedFruit.transform.position.y < 5) // 떨어진 과일의 높이가 5 이하일 때
        {
            SpawnFruit(); // 과일 생성
            isDropped = false;

        }
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 눌렀을 때
        {
            ReleaseFruits(); // 과일 떨어뜨리기
            isDropped = true;
        }
    }

    // 과일 생성
    public void SpawnFruit()
    {
        GameObject selectedFruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)]; // 과일프리팹 중 랜덤으로 선택
        spawnedFruit = Instantiate(selectedFruitPrefab, spawnPoint, Quaternion.identity); // 선택된 과일을 스폰하기.
        spawnedFruit.GetComponent<Rigidbody>().isKinematic = true; // 스페이스바를 누르기 전까지 떨어지지 않는상태로 두기
    }

    // 과일 떨어뜨리기
    void ReleaseFruits()
    {
        spawnedFruit.GetComponent<Rigidbody>().isKinematic = false; 
        isDropped = true;
    }


}
