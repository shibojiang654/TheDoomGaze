using System.Collections.Generic;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject explosionObj;
    private Transform player;
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            StartCoroutine(ExplodeAndLoseGame());
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #endregion

    #region Coroutines
    IEnumerator ExplodeAndLoseGame()
    {
        Debug.Log("Boom");
        GameObject character = GameObject.FindWithTag("Player");
        Destroy(character);
        Instantiate(explosionObj, player.position, player.rotation);
        yield return new WaitForSeconds(0.6f);
        GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManager>().LoseGame();
    }
    #endregion
}
