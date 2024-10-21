using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapLandSlide : TrapBase
{
    public override void PlayTrap()
    {
        Debug.Log("On PlayTrap");
        //tilemap.SetTile(removedPostion, null);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(DestroyTrap());
    }

    private IEnumerator DestroyTrap()
    {
        Debug.Log("DestroyTrap");
        yield return new WaitForSeconds(5f);
        Debug.Log("DestroyTrap Done");
        Destroy(gameObject);
    }
}
