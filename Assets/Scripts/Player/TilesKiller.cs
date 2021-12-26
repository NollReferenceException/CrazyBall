using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesKiller : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Tile tile = other.GetComponent<Tile>();
        bool fallen = false;

        float destroyDistance = 3f;

        float distanceX = transform.position.x - other.transform.position.x;
        float distanceZ = transform.position.z - other.transform.position.z;

        if (distanceX + distanceZ > destroyDistance )
        {
            if (!fallen)
            {
                tile.Fall();
            }
            
            fallen = true;
        }

        if (tile != null)
        {
            // Destroy(other.gameObject);
        }
    }
}