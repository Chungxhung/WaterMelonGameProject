using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public GameObject foodGameObject; // ���� ���� ������Ʈ
    public int level; // ������ �ܰ�(����)
    public List<Food> foodList; // ���� ����Ʈ


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
        if (other.gameObject.CompareTag("food")) // ���ĵ��� �浹�� ���
        {
            
        }
    }
}
