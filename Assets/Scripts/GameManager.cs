using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //singleton part
    private static GameManager _instance = null;

    public void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    public Player player;
    private Spawner spawner;
    public Canvas gameOverCanvas;
    public Text healthText;

    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        onRestartClick();
    }

    public void onRestartClick()
    {
        player.reset();
        spawner.reset();
        healthText.text = "x" + player.maxHealth;
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void updateHealthText(int value)
    {
        healthText.text = "x" + value;
    }

    public void gameOverCanvasSwitch(bool state)
    {
        gameOverCanvas.gameObject.SetActive(state);
    }

    public void damagePlayer(int value)
    {
        this.player.takeDamage(value);
    }

    //Returns current player position as Vector3
    public Vector3 getPlayerVector()
    {
        return this.player.GetComponent<Player>().transform.position;
    }

    public int getPlayerFacing()
    {
        return this.player.GetComponent<Player>().facing;
    }

}
