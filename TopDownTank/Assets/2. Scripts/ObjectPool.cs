using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToPool;
    [SerializeField]
    protected int poolSize = 10;

    protected Queue<GameObject> objectPool;

    public Transform spwneObjectParent;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    public void Initialized(GameObject objectToPool, int poolSize = 10)
    {
        this.objectPool = objectPool;
        this.poolSize = poolSize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spwanedObject = null;
        if (objectPool.Count < poolSize)
        {
            spwanedObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            spwanedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectPool.Count;
            spwanedObject.transform.SetParent(spwneObjectParent);
        }
        else
        {
            spwanedObject = objectPool.Dequeue();
            spwanedObject.transform.position = transform.position;
            spwanedObject.transform.rotation = Quaternion.identity;
            spwanedObject.SetActive(true);
        }

        objectPool.Enqueue(spwanedObject);
        return spwanedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spwneObjectParent == null)
        {
            string name = "ObjectPool_" + objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spwneObjectParent = parentObject.transform;
            }
            else
            {
                spwneObjectParent = new GameObject(name).transform;
            }
        }
    }
}
