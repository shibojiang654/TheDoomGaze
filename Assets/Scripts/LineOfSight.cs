using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    #region LOS
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            GetComponentInParent<Enemy>().player = coll.transform;
        }
    }
    #endregion
}
