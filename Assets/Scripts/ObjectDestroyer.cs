using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }

        Destroy(gameObject);
    }
}
