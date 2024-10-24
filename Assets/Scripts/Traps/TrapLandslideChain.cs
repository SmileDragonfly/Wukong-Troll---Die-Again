using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLandslideChain : TrapBase
{
    public List<TrapLandSlide> listTraps;
    public float delayBetweenTrap = 1f;
    public override void PlayTrap()
    {
        Debug.Log("PlayTrap TrapLandslideChain");
        StartCoroutine(PlayTrapsWithDelay());
    }

    private IEnumerator DestroyTrap()
    {
        Debug.Log("DestroyTrap TrapLandslideChain");
        yield return new WaitForSeconds(5f);
        Debug.Log("DestroyTrap TrapLandslideChain");
        Destroy(gameObject);
    }

    private IEnumerator PlayTrapsWithDelay()
    {
        for (int i = 0; i < listTraps.Count; i++)
        {
            listTraps[i].PlayTrap();
            yield return new WaitForSeconds(delayBetweenTrap);
        }
    }
}
