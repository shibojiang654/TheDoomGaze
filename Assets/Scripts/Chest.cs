using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    #region GameObject_variables
    [SerializeField]
    [Tooltip("key")]
    private GameObject key;
    #endregion

    #region Chest_functions
    IEnumerator DestroyChest() {
        yield return new WaitForSeconds(1f);
        Instantiate(key, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    public void Interact() {
        StartCoroutine("DestroyChest");
    }
    #endregion
}