using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallProtection : MonoBehaviour
{
    private GameObject playerObj = null;
    // Start is called before the first frame update
    void Start()
    {

        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Position: X = " + playerObj.transform.position.x + " --- Y = " + playerObj.transform.position.y + " --- Z = " + playerObj.transform.position.z);

        if (playerObj.transform.position.y < 0)
        {
            playerObj.transform.position = new Vector3(playerObj.transform.position.x, 5, playerObj.transform.position.z);
            //playerObj.transform.position.y = 10;
        }

    }
}
