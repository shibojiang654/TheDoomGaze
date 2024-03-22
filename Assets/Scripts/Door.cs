using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    #region GameObject_variables
    [SerializeField]
    [Tooltip("Door")]
    #endregion

    public void Interact() {
        GameObject gm = GameObject.FindWithTag("Door");
        Destroy(gm);    
    }
}
