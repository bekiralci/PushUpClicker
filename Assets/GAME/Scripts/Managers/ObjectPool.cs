using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public List<StickmanController> pooledObjects;
        public StickmanController objectPrefab;
        public int poolSize;
    }

    public Pool[] pools;

    private void Start()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new List<StickmanController>();
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                StickmanController obj = Instantiate(pools[j].objectPrefab);
                obj.gameObject.SetActive(false);
                pools[j].pooledObjects.Add(obj);
            }
        }
    }

    #region Event
    private void OnEnable()
    {
        EventManager.E_ObjectPool += GetThis;
    }
    private void OnDisable()
    {
        EventManager.E_ObjectPool -= GetThis;
    }
    private ObjectPool GetThis()
    {
        return this;
    }

    #endregion

    public StickmanController GetPooledObject(int charLevel)
    {
        if (pools[charLevel].pooledObjects.Count == 0)
        {
            return null;
        }

        StickmanController obj = pools[charLevel].pooledObjects[0];

        pools[charLevel].pooledObjects.Remove(obj);
        obj.gameObject.SetActive(true);

        EventManager.E_StickmansManager.Invoke().AddObj(obj);

        return obj;
    }
}
