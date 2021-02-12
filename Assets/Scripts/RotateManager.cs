using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
   
    void Update()
    {
        if (gameObject.tag == "coin")
        {
            transform.Rotate(new Vector3(0, 0, 90), Time.deltaTime * 30);
        }
        else if (gameObject.tag == "food")
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 40);
        }
    }
}