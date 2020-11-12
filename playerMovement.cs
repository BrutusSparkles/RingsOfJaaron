using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //declare a variable to eventually store my speed
    public float speed;

    //declare a Rigidbody2D variable (for reference purposes we'll want to store our main charactors sprite)
    private Rigidbody2D myRigidbody;

    //make a reference to how much I want the players position to change
    private Vector3 change;

    //make a reference to the animator inside unity
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //complete the refence to animator
        animator = GetComponent<Animator>();

        //make myRigidbody equal to the main charactor sprite
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //once per frame set change to zero
        change = Vector3.zero;

        //find out if an input button was pressed and make change equal to the corisonding button press
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        //if change doesn't equal 0 then player isn't still and must move
        if(change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
        }
    }

    //create a function called move character
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime);
    }
}
