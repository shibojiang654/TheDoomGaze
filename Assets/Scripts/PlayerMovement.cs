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
    #endregion

    #region Animation_components
    Animator anim;
    #endregion

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        Move();
    }

    #region Movement_functions
    private void Move() {
        //anim.SetBool("Moving", true);
        if (x_input > 0) {
            PlayerRB.velocity = Vector2.right * movespeed;
            currDirection = Vector2.right;
        } else if (x_input < 0) {
            PlayerRB.velocity = Vector2.left * movespeed;
            currDirection = Vector2.left;
        } else if (y_input > 0) {
            PlayerRB.velocity = Vector2.up * movespeed;
            currDirection = Vector2.up;
        } else if (y_input < 0) {
            PlayerRB.velocity = Vector2.down * movespeed;
            currDirection = Vector2.down;
        } else {
            PlayerRB.velocity = Vector2.zero;
            //anim.SetBool("Moving", false);
        }
        //anim.SetFloat("DirX", currDirection.x);
        //anim.SetFloat("DirY", currDirection.y);
    }
    #endregion


}