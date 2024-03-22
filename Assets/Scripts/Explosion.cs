using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    #region Exp Destroy
	void Start () {
        Destroy(this.gameObject, 0.5f);
	}
	#endregion
}
