using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phasme : MonoBehaviour
{
    public float health=400f; 
    public float dommage=5;
    public GameObject stickbug; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
         void OnCollisionEnter(Collision trigger)
    {

        if (trigger.gameObject.CompareTag("bullet"))
        {


                // do something if it has that component on it!
                this.health-=playerScript.dommage;
                if(this.health<=0){
                    Destroy(stickbug);
                }
        }
        
    }
}
