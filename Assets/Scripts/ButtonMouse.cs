using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ButtonMouse : MonoBehaviour
{
    [SerializeField]
    private bool Spawn;
    [SerializeField]
    public bool grounded;
    [SerializeField]
    private bool one;
    [SerializeField]
    private bool two;
    [SerializeField]
    private bool three;
    public Rigidbody2D rb;
    [SerializeField]
    private float move;
    [SerializeField]
    private float SPED = 5;
    [SerializeField]
    private float jumpheight = 5;
    [SerializeField]
    private GameObject SP1;
    [SerializeField]
    private GameObject SP2;
    [SerializeField]
    private GameObject SP3;
    [SerializeField]
    private GameObject wall1;
    [SerializeField]
    private GameObject wall2;
    [SerializeField]
    private GameObject wall3;
    [SerializeField]
    private GameObject wall4;
    [SerializeField]
    private GameObject wall5;
    [SerializeField]
    private GameObject wall6;
    [SerializeField]
    private GameObject wall7;
    [SerializeField]
    private GameObject wall8;
    [SerializeField]
    private GameObject wall9;
    [SerializeField]
    private GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        SPED = 5;
        Spawn = SP3;
        rb = GetComponent<Rigidbody2D>();
        // makes the walls for level 2 and 3 to not exist
        wall4.SetActive(false);
        wall5.SetActive(false);
        wall6.SetActive(false);
        wall7.SetActive(false);
        wall8.SetActive(false);
        wall9.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * SPED * Time.deltaTime;

        // To make the player jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            // move character up
            rb.velocity += Vector2.up * jumpheight;
        }
    }

    // For when the player is touching something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When you hit an object
        switch (collision.gameObject.tag)
        {
            // object tag ground
            case "Ground":
                {
                    grounded = true;
                }
                break;
            // object tag Wall1
            case "Wall1":
                {
                    //moveing the player to the next section
                    transform.position = SP1.transform.position;
                    SPED = -SPED;
                    //changing normal spawn to new spawn
                    Spawn = SP1;
                }
                break;
            // object tag Wall2
            case "Wall2":
                {
                    transform.position = SP2.transform.position;
                    SPED = Mathf.Abs(SPED);
                    Spawn = SP2;
                }
                break;
            // object tag Wall3
            case "Wall3":
                {
                    transform.position = SP3.transform.position;
                    SPED = SPED + 1;
                    wall1.SetActive(false);
                    wall2.SetActive(false);
                    wall3.SetActive(false);
                    wall4.SetActive(true);
                    wall5.SetActive(true);
                    wall6.SetActive(true);
                    Spawn = SP3;
                }
                break;
            // object tag Wall4
            case "Wall4":
                {
                    transform.position = SP1.transform.position;
                    SPED = -SPED;
                    Spawn = SP1;
                }
                break;
            // object tag Wall5
            case "Wall5":
                {
                    transform.position = SP2.transform.position;
                    SPED = Mathf.Abs(SPED);
                    Spawn = SP2;
                }
                break;
            // object tag Wall6
            case "Wall6":
                {
                    transform.position = SP3.transform.position;
                    SPED = SPED + 1;
                    wall4.SetActive(false);
                    wall5.SetActive(false);
                    wall6.SetActive(false);
                    wall7.SetActive(true);
                    wall8.SetActive(true);
                    wall9.SetActive(true);
                    Spawn = SP3;
                }
                break;
            // object tag Wall7
            case "Wall7":
                {
                    transform.position = SP1.transform.position;
                    SPED = -SPED;
                    Spawn = SP1;
                }
                break;
            // object tag Wall8
            case "Wall8":
                {
                    transform.position = SP2.transform.position;
                    SPED = Mathf.Abs(SPED);
                    Spawn = SP2;
                }
                break;
            // object tag Wall9
            case "Wall9":
                {
                    transform.position = SP3.transform.position;
                    SPED = SPED + 1;
                    wall7.SetActive(false);
                    wall8.SetActive(false);
                    wall9.SetActive(false);
                    wall1.SetActive(true);
                    wall2.SetActive(true);
                    wall3.SetActive(true);
                    Spawn = SP3;
                }
                break;
            // When the player hits an obstacle and dies
            // object tag death
            case "Death":
                {
                    Spawn = SP3;
                    Time.timeScale = 0;

                    death.SetActive(true);
                }
                break;
        }

    }
    // when not colliding
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Grounded is false
        grounded = false;
    }
}