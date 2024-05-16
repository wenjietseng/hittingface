using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] hatPrefabs;
    public Transform spawner;
    public bool addOneHat;

    void Start()
    {
        // http://fledgling-game-develop.blogspot.com/2021/01/unity3d-mirror-using-camera-and.html

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        
    }

    public void AddNewHat()
    {
        int idx = Random.Range(0, hatPrefabs.Length);
        Instantiate(hatPrefabs[idx], spawner.position, Quaternion.identity);
    }
}
