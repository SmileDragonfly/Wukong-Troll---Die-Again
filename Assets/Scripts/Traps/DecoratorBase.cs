using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorBase : MonoBehaviour
{
    public TrapBase trap;
    public bool isRepeating;
    public int numberOfRepeating;
    public float onTime;
    public float offTime;
    // Private
    private bool isPlaying = false;
    public void Play()
    {
        isPlaying = true;
        if (!isRepeating)
        {
            gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(PlayRepeating());
        }
    }

    private IEnumerator PlayRepeating()
    {
        for (int i = 0; i < numberOfRepeating; i++)
        {
            if(isPlaying)
            {
                // On
                float elapsedTime = 0f;
                gameObject.SetActive(true);
                while (elapsedTime < onTime)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                // Off
                gameObject.SetActive(false);
                elapsedTime = 0f;
                while (elapsedTime < offTime)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                break;
            }
        }
    }

    public void Stop()
    {
        isPlaying = false;
        gameObject.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("DecoratorBase: OnTriggerEnter2D");
        }
    }
}
