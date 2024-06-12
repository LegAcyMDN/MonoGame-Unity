using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCigars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localRotation.eulerAngles.y);
        transform.rotation = Quaternion.Euler(new Vector3(-90,0,0));
    }
}
