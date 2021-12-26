using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    private Animator anim;

    public bool TriggerTile { get; set; }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Fall()
    {
        if (anim != null)
        {
            StartCoroutine(PlayAnimationFall());
        }
    }

    private IEnumerator PlayAnimationFall()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        anim.Play("Base Layer.TileFall", 0, 0.25f);
    }

    //link to animator
    private void DestroyAfterFall()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player && TriggerTile)
        {
            RoadGenerator
                roadGenerator = GameObject.Find("RoadGenerator").GetComponent<RoadGenerator>(); //исправить костыль
            roadGenerator.GenerateClusters(20);
        }
    }
}