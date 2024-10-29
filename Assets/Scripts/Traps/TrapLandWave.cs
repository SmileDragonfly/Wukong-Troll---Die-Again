using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLandWave : TrapBase
{
    public float upSpeed = 1.0f;
    public float downSpeed = 1.0f;
    public float upMax = 1.0f;
    public float downMax = 1.0f;
    public float upPositionHoldTime = 1.0f;
    public float downPositionHoldTime = 1.0f;
    public int repeatTimes = 1;
    public bool isUpFirst = true;
    public override void PlayTrap()
    {
        Debug.Log("PlayTrap TrapLandWave");
        StartCoroutine(PlayTrapRepeat());
    }

    private IEnumerator DestroyTrap()
    {
        Debug.Log("DestroyTrap TrapLandWave");
        yield return new WaitForSeconds(5f);
        Debug.Log("DestroyTrap TrapLandWave");
        Destroy(gameObject);
    }

    private IEnumerator PlayTrapRepeat()
    {
        float heightChange = 0f;
        for (int i = 0; i < repeatTimes; i++)
        {
            if(isUpFirst)
            {
                // Up
                while (heightChange < upMax)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + upSpeed * Time.deltaTime);
                    heightChange += upSpeed * Time.deltaTime;
                    yield return null; // Wait next frame
                }

                // Hold in up position
                yield return new WaitForSeconds(upPositionHoldTime);
            }
            isUpFirst = true;
            // Down
            while (heightChange > -downMax)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - downSpeed * Time.deltaTime);
                heightChange -= downSpeed * Time.deltaTime;
                yield return null; // Wait next frame
            }

            // Hold in down position
            yield return new WaitForSeconds(downPositionHoldTime);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(DestroyTrap());
    }
}
