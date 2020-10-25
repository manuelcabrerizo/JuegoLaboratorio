using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    [Range (0.0f, 0.20f)]
    public float parallaxSpeed = 0.40f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;

    public GameObject Player;

    public enum GameState
    {
        IDLE,
        PLAYING
    };

    public GameState gameState = GameState.IDLE;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameState == GameState.IDLE)
        {
            gameState = GameState.PLAYING;
            uiIdle.SetActive(false);
            Player.SendMessage("UpdateState", "PlayerRun");
        }
        else if (gameState == GameState.PLAYING)
        {
            //Paralax();
            Player.SendMessage("SetPlayState", true);
        }


    }

    void Paralax()
    {
        float speed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + speed, 0.0f, 1.0f, 1.0f);
        platform.uvRect = new Rect((background.uvRect.x + speed) * 4, 0.0f, 1.0f, 1.0f);
    }


}
