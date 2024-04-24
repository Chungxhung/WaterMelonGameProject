using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;
    public GameObject[] fruitPrefabs; //과일 프리팹 저장
    bool isCombined = false;
    bool isDestroyed = false;

    private void OnCollisionEnter(Collision collision) // 충돌 감지
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

    void CombineFruits(Fruit otherFruit) // 과일 합치기
    {
        level++;
        isCombined = true; // 합쳐졌는지 여부

        Destroy(otherFruit.gameObject);
        if (level < fruitPrefabs.Length)
        {
            GameObject nextFruitPrefab = fruitPrefabs[level]; // 다음레벨의 과일 생성
            GameObject nextFruit = Instantiate(nextFruitPrefab, transform.position, transform.rotation); // 합쳐진 위치에 소환
            nextFruit.transform.position = transform.position; // 합쳐진 위치의 위치값
            nextFruit.transform.rotation = transform.rotation; // 합쳐젔을때 로테이션값

            Destroy(gameObject); // 
        }
        else
        {
            Debug.LogWarning("이 과일은 최대 레벨입니다!");
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
