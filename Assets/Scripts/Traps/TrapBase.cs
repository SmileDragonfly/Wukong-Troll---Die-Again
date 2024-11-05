using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapBase : MonoBehaviour
{
    // Public
    public string trapName = string.Empty;
    public GameObject trapObject;
    public float activationDelay = 0;
    public List<DecoratorBase> listDecor;
    // Private
    public bool isActivated = false;
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            // Player has entered the trigger
            StartCoroutine(ActivateTrap());
        }
    }

    protected IEnumerator ActivateTrap()
    {
        isActivated = true;
        // Add your trap activation logic here, e.g., changing appearance, triggering animations, applying forces
        yield return new WaitForSeconds(activationDelay);
        // Add your trap deactivation logic here, if needed
        PlayTrap();
        if (listDecor != null)
        {
            for (int i = 0; i < listDecor.Count; i++)
            {
                if (listDecor[i] != null)
                {
                    listDecor[i].Play();
                }
            }
        }
    }

    public abstract void PlayTrap(); 
}
