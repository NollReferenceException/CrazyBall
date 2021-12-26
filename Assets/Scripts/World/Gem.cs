using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // private void OnCollisionEnter(Collision collision)
    // {
    //     //add points
    //     Destroy(gameObject);
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
