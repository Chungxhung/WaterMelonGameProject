using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public List<GameObject> fruitPrefabs; // ��ȯ�� ���� �����յ��� �����ϴ� ����Ʈ
    private Vector3 spawnPoint = new Vector3(0, 10, 0); // ������ ������ ��ġ
    public GameObject spawnedFruit; // ��ȯ�� ����
    public GameObject lastSpawnedFruit; // �������� ��ȯ�� ����
    public bool isDropped = true;// ������ ����߷ȴ��� �ȶ��� �߷ȴ��� Ȯ��
    public int fruitIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �������ٸ�
        if (isDropped == true && spawnedFruit.transform.position.y < 5) // ������ ������ ���̰� 5 ������ ��
        {
            SpawnFruit(); // ���� ����
            isDropped = false;

        }
        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��ٸ� ������ ��
        {
            ReleaseFruits(); // ���� ����߸���
            isDropped = true;
        }
    }

    // ���� ����
    public void SpawnFruit()
    {
        GameObject selectedFruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)]; // ���������� �� �������� ����
        spawnedFruit = Instantiate(selectedFruitPrefab, spawnPoint, Quaternion.identity); // ���õ� ������ �����ϱ�.
        spawnedFruit.GetComponent<Rigidbody>().isKinematic = true; // �����̽��ٸ� ������ ������ �������� �ʴ»��·� �α�
    }

    // ���� ����߸���
    void ReleaseFruits()
    {
        spawnedFruit.GetComponent<Rigidbody>().isKinematic = false; 
        isDropped = true;
    }


}
