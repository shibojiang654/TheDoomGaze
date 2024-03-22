using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    #region Portal Functions
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            if (SceneManager.GetActiveScene().name == "Room1") {
                gm.GetComponent<GameManager>().SecondClue();
            }
            if (SceneManager.GetActiveScene().name == "Room2") {
                gm.GetComponent<GameManager>().ThirdClue();
            }
            if (SceneManager.GetActiveScene().name == "Room3") {
                gm.GetComponent<GameManager>().WinGame();
            }
        }
    }
    #endregion
}
