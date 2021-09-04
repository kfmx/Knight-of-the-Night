using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnRadius = 10;
    public List<Item> items = new List<Item>();
    void Start()
    {
        for(int i = 0; i < items.Count; i++)
        {
            for (int ii = 0; ii < items[i].spawnCount; ii++)
            {
                Instantiate(items[i].item, new Vector3(Random.Range(-spawnRadius / 2, spawnRadius / 2), Random.Range(-spawnRadius / 2, spawnRadius / 2), 0), Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class Item
    {
        [SerializeField]
        public GameObject item;
        [SerializeField]
        public int spawnCount = 10;
    }
}
