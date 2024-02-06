using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public static GameMenager instance;
    [SerializeField] int timeToEnd;

    bool gamePause = false;
    bool endGame = false;
    bool win = false;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        InvokeRepeating("Stopper", 2, 1);
        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
    }
    private void Update()
    {
        pauseChesk();
    }
    void Stopper()
    {
       timeToEnd--;
        Debug.Log($"Time: {timeToEnd}");
       
        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePause = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePause = false;
    }
    void pauseChesk()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (gamePause) ResumeGame();
            else PauseGame();
        }
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Relode?");
        }
        else
        {
            Debug.Log("You Lose!!! Relode?");
        }
    }

}
