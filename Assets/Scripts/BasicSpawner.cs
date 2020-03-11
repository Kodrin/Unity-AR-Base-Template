using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            GameObject obj = Instantiate(this.prefab, new Vector3(Random.value, Random.value, Random.value), Quaternion.identity);
        }        
    }

}
