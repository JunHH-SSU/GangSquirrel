using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject itemGun;
    public GameObject itemAcorn;
    public GameObject itemFame;

    public int poolSize;

    GameObject[] itemGunPool;
    GameObject[] itemAcornPool;
    GameObject[] itemFamePool;

    public GameObject[] expPool;

    void Awake()
    {
        itemGunPool = new GameObject[poolSize];
        itemAcornPool = new GameObject[poolSize];
        itemFamePool = new GameObject[poolSize];

        GenerateInstant();
    }

    void GenerateInstant()
    {
        for(int index=0;index< poolSize; index++)
        {
            itemGunPool[index] = Instantiate(itemGun,transform);
            itemAcornPool[index] = Instantiate(itemAcorn, transform);
            itemFamePool[index] = Instantiate(itemFame, transform);
        }
    }

    public GameObject GetItem(GameManager.Type type)
    {
        GameObject instantObj = null;
        GameObject[] instantPool = null;
        switch (type)
        {
            case GameManager.Type.Gun:
                instantPool= itemGunPool;
                break;
            case GameManager.Type.Acorn:
                instantPool = itemAcornPool;
                break;
            case GameManager.Type.Fame:
                instantPool = itemFamePool;
                break;
            case GameManager.Type.Exp:
                instantPool = expPool;
                break;

        }
        foreach (GameObject item in instantPool)
        {
            if (!item.activeSelf) instantObj = item;
        }

        return instantObj;
    }
}
