using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;
    public GameObject[] fruitPrefabs; //���� ������ ����
    bool isCombined = false;
    bool isDestroyed = false;

    private void OnCollisionEnter(Collision collision) // �浹 ����
    {
        if (isCombined) return;
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();
            if (otherFruit != null && otherFruit.level == level)
            {
                CombineFruits(otherFruit);
            }
        }

    }

    void CombineFruits(Fruit otherFruit) // ���� ��ġ��
    {
        level++;
        isCombined = true; // ���������� ����

        Destroy(otherFruit.gameObject);
        if (level < fruitPrefabs.Length)
        {
            GameObject nextFruitPrefab = fruitPrefabs[level]; // ���������� ���� ����
            GameObject nextFruit = Instantiate(nextFruitPrefab, transform.position, transform.rotation); // ������ ��ġ�� ��ȯ
            nextFruit.transform.position = transform.position; // ������ ��ġ�� ��ġ��
            nextFruit.transform.rotation = transform.rotation; // ���Ġ����� �����̼ǰ�

            Destroy(gameObject); // 
        }
        else
        {
            Debug.LogWarning("�� ������ �ִ� �����Դϴ�!");
        }

        if (!otherFruit.isDestroyed)
        {
            otherFruit.DestroyFruit();
        }
    }

    void DestroyFruit()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
