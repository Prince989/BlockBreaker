using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBrickCollision : MonoBehaviour
{
    public float checkRadius;
    public LayerMask WhatShouldIAvoid;
    public GameObject Bricks;
    private BoxCollider2D _Collider;

    private void Awake()
    {
        TryGetComponent(out _Collider);
    }
    private void Start()
    {
        Bricks = GameObject.Find("Bricks");
        StartCoroutine(Initialize());
        StartCoroutine(collisionOff());
    }
    IEnumerator collisionOff()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("OMSD");
        if(transform.childCount > 0)
            GetComponent<BoxCollider2D>().isTrigger = true;
        BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D comp in colliders)
        {
            comp.enabled = true;
        }
    }
    private IEnumerator Initialize()
    {
        // disable collider to avoid hitting itself when checking for collisions
        _Collider.enabled = false;
        while (true)
        {
            // check for collisions
            if (Physics2D.OverlapCircle(transform.position, checkRadius, WhatShouldIAvoid))
            {
                // if found, use RandomPointOnBox and Factory static variables to look for a new position
                //transform.position = ObjectFactory.RandomPointOnBox(ObjectFactory._SpawnCenter, ObjectFactory._SpawnBounds);
                transform.position = Bricks.GetComponent<SpawnBricks>().RandomSpawnInZone();
            }
            else
            {
                // else enable collider and break the loop
                _Collider.enabled = true;
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}