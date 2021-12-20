using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crates : MonoBehaviour
{
    public Transform[] spawnSpots;
    public GameObject crate;
    private int randomSpawnSpot;
    private Transform PagePos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Shoot", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Shoot()
    {
        Instantiate(crate, spawnSpots[randomSpawnSpot].position, Quaternion.identity);
    }
}
