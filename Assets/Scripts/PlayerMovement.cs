using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    float x_input;
    float y_input;
    #endregion

    #region Interact_variables
    Vector2 currDirection;
    public float Damage;
    public bool attacking = false;
    public bool haskey = false;
    #endregion

    #region Animation_components
    Animator anim;
    #endregion

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion

    #region Health
    [SerializeField] FloatingHealth healthbar;
    #endregion
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthbar = GetComponentInChildren<FloatingHealth>();
        healthbar.updateHealth(GameManager.Instance.playerCurrentHealth, GameManager.Instance.playerMaxHealth);
    }

    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.L)) {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            StartCoroutine(AttackCoroutine());
        }
        Move();
    }

    #region Movement_functions
    private void Move() {
        x_input = Input.GetAxisRaw("Horizontal") * movespeed;
        y_input = Input.GetAxisRaw("Vertical") * movespeed;
        PlayerRB.velocity = new Vector2(x_input, y_input);
        anim.SetBool("Moving", true);
        if (x_input > 0) {
            currDirection = Vector2.right;
        } else if (x_input < 0) {
            currDirection = Vector2.left;
        } else if (y_input > 0) {
            currDirection = Vector2.up;
        } else if (y_input < 0) {
            currDirection = Vector2.down;
        } else {
            anim.SetBool("Moving", false);
        }
        anim.SetFloat("DirX", currDirection.x);
    }
    #endregion

    #region Interact_functions
    private void Interact() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + currDirection, new Vector2(1f, 1f), 0f, Vector2.zero, 0f);
        foreach (RaycastHit2D hit in hits) {
            if (hit.transform.CompareTag("Lever")) {
                Debug.Log("Lever");
                hit.transform.GetComponent<Lever>().Interact();
            }
            if (haskey && hit.transform.CompareTag("Door")) {
                Debug.Log("Door");
                hit.transform.GetComponent<Door>().Interact();
            }
            if (hit.transform.CompareTag("Chest")) {
                Debug.Log("Chest");
                hit.transform.GetComponent<Chest>().Interact();
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        attacking = true;
        anim.SetTrigger("Attacktrig");
        yield return new WaitForSeconds(0.5f); 
        RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + currDirection, new Vector2(2f, 2f), 0f, Vector2.zero, 0f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(Damage);
            }
        }

        attacking = false;
    }
    #endregion

    public void TakeDamage(float value)
    {
        GameManager.Instance.TakeDamage(value);
        healthbar.updateHealth(GameManager.Instance.playerCurrentHealth, GameManager.Instance.playerMaxHealth);
        if (GameManager.Instance.playerCurrentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.LoseGame();
        }
    }

}
