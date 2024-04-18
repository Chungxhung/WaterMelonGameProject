using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public GameObject foodGameObject; // 음식 게임 오브젝트
    public int level; // 음식의 단계(레벨)
    public List<Food> foodList; // 음식 리스트


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("food")) // 음식들이 충돌한 경우
        {
            
        }
    }
}
