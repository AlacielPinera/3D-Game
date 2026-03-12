using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRespawn : MonoBehaviour
{
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(-2.2f, 0, 8.89f);
        }
    }
}
