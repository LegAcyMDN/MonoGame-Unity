using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarSpawner : MonoBehaviour
{

    public GameObject boiteCigar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-29, 64), 15, Random.Range(-50, 15));
            boiteCigar.transform.localScale = new Vector3(5f, 5f, 5f);
            boiteCigar.tag = "Cigars";
            Instantiate(boiteCigar, randomSpawnPosition, Quaternion.identity);

        }
    }
}
