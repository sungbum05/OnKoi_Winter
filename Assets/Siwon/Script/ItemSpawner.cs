using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ItemMenu = new List<GameObject>();

    Vector3 ItemPosition;
    Unit unit;
    public float Radius;
    


    void Start()
    {
       
    }
    void Update()
    {
        if (unit.Hp <= 0)
        {

        }
    }

    public void SpawnItem()
    {
        int RandomSpawn = Random.Range(0, 100);
        if(RandomSpawn <= 30)
        {
            switch (RandomSpawn)
            {
                case 1://����
                case 2:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 3://�������
                case 4:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 5://���ݼ���
                case 6:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 7://�̻��� ����
                case 8:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 9://�ͷ�
                case 10:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 11://��
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 12://���ο�
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 13://���� 2��
                case 14:
                case 15:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 16://������ 2��
                case 17:
                case 18:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 19://�߱����
                case 20:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 21://��Ĺ��ó
                case 22:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;

                    
                


                

                default:
                    break;
            }
        }

    }
}
