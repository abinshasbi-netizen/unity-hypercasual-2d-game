using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class Pooling : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int poolsize;

    List<GameObject>pool = new List<GameObject>();


    void Awake()
    {
        for (int i=0; i<poolsize; i++) { 

            GameObject obj= Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        
        }

    }

    public GameObject GetFromPool() {

        foreach (GameObject obj in pool) {

            if (!obj.activeInHierarchy)
            { 

                obj.SetActive(true);
                return obj;
            
            }
        
        }
        return null;
    
    }

    public void Return(GameObject obj) { 

        obj.SetActive(false );
    
    }
    
    void Update()
    {
        
    }
}
