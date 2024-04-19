using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int points { get; private set; }

    public int[] keys { get; private set; } = new int[3];

    [SerializeField]
    private int timeToEnd;

    public bool gamePaused { get; private set; }
    public bool gameEnded { get; private set; }
    public bool gameWon { get; private set; }

    private AudioSource audioSorce;
    [SerializeField]
    private AudioSource pauseClip;
    [SerializeField]
    private AudioSource resumeClip;
    [SerializeField]
    private AudioSource winClip;
    [SerializeField]
    private AudioSource loseClip;

    public void AddKey(KeyColor keyColor)
    {
        keys[(int)keyColor]++;
        Debug.Log($"Red: {keys[0]}, Green: {keys[1]}, Blue: {keys[2]}");
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
        Debug.Log($"{points}");
    }
    public void FreezeTime(int FrizzeFor)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), FrizzeFor, 1);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameEnded = false;
        gameWon = false;

        audioSorce = GetComponent<AudioSource>();

        if (timeToEnd <= 0)
        {
            timeToEnd = 180;
        }
        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSorce.clip = playClip;
        audioSorce.Play();
    }

    private void Update()
    {
        PauseCheck();
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        if(gameWon)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("You lost!");
        }
    }

    private void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");

        if (timeToEnd <= 0)
        {
            gameEnded = true;
            gameWon = false;
        }

        if (gameEnded)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1;
        gamePaused = false;
    }

    private void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
