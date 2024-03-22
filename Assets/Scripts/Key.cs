using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    #region Key Functions
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up the key!");
            other.GetComponent<PlayerMovement>().haskey = true;
            Destroy(gameObject);
        }
    }
    #endregion
}
