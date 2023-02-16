using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    private int health;
    public int maxHealth;
    private float input;

    public int facing; //-1 left, +1 right, 0 not moving

    private Rigidbody2D rb;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input==0)
        {
            anim.SetBool("isRunning", false);
        } else
        {
            anim.SetBool("isRunning", true);
        }

        if (input > 0 )
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            this.facing = 1;
        } else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            this.facing = -1;
        } else
        {
            this.facing = 0;
        }
        //print(input.ToString()); Debug to check input
    }

    //called once per physics frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input*speed, 0f);
    }

    public void reset()
    {
        health = maxHealth;
        Vector3 pos = new Vector3(0f, -3.8f, 0f);
        this.transform.position = pos;
        this.gameObject.SetActive(true);
    }

    public void takeDamage(int value)
    {
        health -= value;
        GameManager.instance().updateHealthText(health);
        if (health <=0)
        {
            //game over condition
            //play a sound/music
            //play a particle system
            //show the game over screen
            this.gameObject.SetActive(false);

            GameManager.instance().gameOverCanvasSwitch(true);
            this.gameObject.SetActive(false);
        }
    }
}
