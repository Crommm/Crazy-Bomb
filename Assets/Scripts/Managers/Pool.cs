using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
}
public class Pool : MonoBehaviour
{
    public static Pool instance;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

  public GameObject GetObject(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].gameObject.tag==tag)
            {
                return pooledItems[i];
            }
        }
        return null;
    }
}
