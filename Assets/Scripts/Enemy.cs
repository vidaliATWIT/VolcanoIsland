using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    //two speeds to pick a random value between
    public float minSpeed;
    public float maxSpeed;

    public ParticleSystem hitEffect;

    private float speed;
    public GameManager gm;
    public Vector3 direction= new Vector3(0.0f, -1.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        //pick random speed between min and max
        Vector3 player_pos = GameManager.instance().getPlayerVector();
        //print("PLAYER FACING: " + GameManager.instance().getPlayerFacing());
        player_pos.x += GameManager.instance().getPlayerFacing() * 3; // multiplier is how much to move the x from the player
        direction = player_pos - transform.position;

        direction = direction.normalized;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //translate this object down at speed
        if (gm==null)
        {
            gm=FindObjectOfType<GameManager>();
        }
        //print("direction: " + direction);
        this.transform.Translate(this.direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //reduce player health
            GameObject go = collision.gameObject;
            Player player = go.GetComponent<Player>();
            player.takeDamage(damage);
            ParticleSystem ps = Instantiate(hitEffect, this.transform.position, Quaternion.identity);

            //this.gameObject.SetActive(false);
            GameObject.Destroy(this.gameObject);
        } else if (collision.tag == "Ground")
        {
            ParticleSystem ps = Instantiate(hitEffect, this.transform.position, Quaternion.identity);
            //this.gameObject.SetActive(false);
            GameObject.Destroy(this.gameObject);
        }
    }

    public void setDirection(Vector3 v)
    {
        this.direction = v;
    }
}
