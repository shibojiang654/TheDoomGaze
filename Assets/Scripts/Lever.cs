using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    #region GameObject_variables
    [SerializeField]
    [Tooltip("Lever")]
    #endregion


    #region Lever_Functions

    public void Interact() {
        GameObject gm = GameObject.FindWithTag("Blocker");
        Destroy(gm);
    }

    #endregion
}
