using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> _pool;

    public GameObject objectToPool;
    public int numberToPool;
    public bool canExpand;

    // Start is called before the first frame update
    void Start()
    {
        _pool = new List<GameObject>();
        for(int i=0; i<numberToPool; i++)
        {
            GameObject go = Instantiate(objectToPool,this.transform);
            go.SetActive(false);
            _pool.Add(go);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject go in _pool)
        {
            if(!go.activeInHierarchy)
            {
                return go;
            }
        }

        if (canExpand)
        {
            GameObject go = Instantiate(objectToPool, this.transform);
            go.SetActive(false);
            _pool.Add(go);
            return go;
        }
        return null;
    }
}
