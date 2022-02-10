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
                case 1://¼¦°Ç
                case 2:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 3://±â°ü´ÜÃÑ
                case 4:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 5://µ¹°Ý¼ÒÃÑ
                case 6:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 7://¹Ì»çÀÏ Æø°Ý
                case 8:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 9://ÅÍ·§
                case 10:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 11://ÇÙ
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 12://½½·Î¿ì
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 13://Á¡¼ö 2¹è
                case 14:
                case 15:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 16://µ¥¹ÌÁö 2¹è
                case 17:
                case 18:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 19://Áß±â°üÃÑ
                case 20:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;
                case 21://·ÎÄ¹·±Ã³
                case 22:
                Instantiate(ItemMenu[RandomSpawn], ItemPosition, Quaternion.identity);
                    break;

                    
                


                

                default:
                    break;
            }
        }

    }
}
