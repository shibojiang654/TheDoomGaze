using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    #region Health variables
    public float playerMaxHealth = 10f;
    public float playerCurrentHealth;
    #endregion

    #region Unity_functions
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Initialize player's health
        playerCurrentHealth = playerMaxHealth;
    }
    #endregion

    #region Scene_transitions
    public void StartGame() {
        SceneManager.LoadScene("Room1");
    }

    public void FirstClue() {
        SceneManager.LoadScene("FirstClue");
    }    

    public void SecondClue() {
        SceneManager.LoadScene("SecondClue");
    }    

    public void ThirdClue() {
        SceneManager.LoadScene("ThirdClue");
    }            
    public void Room2() {
        SceneManager.LoadScene("Room2");
    }

    public void Room3() {
        SceneManager.LoadScene("Room3");
    }   

    public void WinGame() {
        SceneManager.LoadScene("Victory");
    }

    public void LoseGame() {
        SceneManager.LoadScene("Lose");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region HP
    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;
    }
    #endregion
}