using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Physics_components
    Rigidbody2D EnemyRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    #endregion

    #region Attack_variables
    public float explosionDamage;
    public float explosionRadius;
    public GameObject explosionObj;
    #endregion

    #region Health_variables
    public float maxHealth;
    float currHealth;
    [SerializeField] FloatingHealth healthbar;
    #endregion

    #region Unity_functions
    private void Awake() {
        EnemyRB = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealth>();
        currHealth = maxHealth;
    }


    private void Update() {
        if (player == null) {
            return;
        }

        Move();
    }
    #endregion   

    #region Movement_functions
    private void Move() {
        Vector2 direction = player.position - transform.position;

        EnemyRB.velocity = direction.normalized * movespeed;
    }
    #endregion

    #region Attack_functions
    private void Explode() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits) {
            if (hit.transform.CompareTag("Player")) {
                Debug.Log("Hit Player with explosion");
                Instantiate(explosionObj, transform.position, transform.rotation);
                hit.transform.GetComponent<PlayerMovement>().TakeDamage(explosionDamage);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            Explode();
        }
    }
    #endregion

    #region Health_functions
    public void TakeDamage(float value) {
        currHealth -= value;
        healthbar.updateHealth(currHealth, maxHealth);
        Debug.Log("Health is now " + currHealth.ToString());
        if (currHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(this.gameObject);
    }
    #endregion
}
