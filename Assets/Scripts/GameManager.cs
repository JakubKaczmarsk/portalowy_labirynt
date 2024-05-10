using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private AudioClip pauseClip;
    [SerializeField]
    private AudioClip resumeClip;
    [SerializeField]
    private AudioClip winClip;
    [SerializeField]
    private AudioClip loseClip;

    [SerializeField]
    private MusicScript musicScript;

    public Text timeText;
    public Text pointText;
    public Text redKeyText;
    public Text greenKeyText;
    public Text blueKeyText;
    public Image snowflake;

    public GameObject infoPanel;
    public Text infoText;
    public Text reloadInfo;
    public Text useInfo;

    private bool lessTime = false;

    public void PlayClip(AudioClip playClip)
    {
        if (playClip == null)
        {
            return;
        }
        audioSorce.clip = playClip;
        audioSorce.Play();
    }

    public void AddKey(KeyColor keyColor)
    {
        keys[(int)keyColor]++;
        if (keyColor == KeyColor.Red)
        {
            redKeyText.text = keys[(int)keyColor].ToString();
        }
        else if (keyColor == KeyColor.Green)
        {
            greenKeyText.text = keys[(int)keyColor].ToString();
        }
        else if (keyColor == KeyColor.Blue)
        {
            blueKeyText.text = keys[(int)keyColor].ToString();
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointText.text = points.ToString();
    }
    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
       timeText.text = timeToEnd.ToString();
    }
    public void FreezeTime(int FrizzeFor)
    {
        CancelInvoke(nameof(Stopper));
        snowflake.enabled = true;
        InvokeRepeating(nameof(Stopper), FrizzeFor, 1);
    }
    public void SetUseInfo(string info)
    {
        useInfo.text = info;
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

        snowflake.enabled = false;
        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        infoText.text = "Pause";
        reloadInfo.text = "";
        useInfo.text = "";

        audioSorce = GetComponent<AudioSource>();

        if (timeToEnd <= 0)
        {
            timeToEnd = 180;
        }
        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    public void lessTimeOn()
    {
        musicScript.PitchThis(1.5f);
    }

    public void lessTimeOff()
    {
        musicScript.PitchThis(1f);
    }

    private void Update()
    {
        PauseCheck();
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        infoPanel.SetActive(true);
        reloadInfo.text = "Press R to reload the game\nPress N to quit";
        Time.timeScale = 0;
        if (gameWon)
        {
            PlayClip(winClip);
            infoText.text = "You won!";
            reloadInfo.text = "Press R to reload the game";
        }
        else
        {
            PlayClip(loseClip);
            infoText.text = "You lost!";
            reloadInfo.text = "Press R to reload the game";
        }
    }

    private void Stopper()
    {
        timeToEnd--;
        timeText.text = timeToEnd.ToString();
        snowflake.enabled = false;

        if (timeToEnd <= 0)
        {
            gameEnded = true;
            gameWon = false;
        }

        if (gameEnded)
        {
            EndGame();
        }

        if (timeToEnd <= 30 && !lessTime)
        {
            lessTimeOn();
            lessTime = true;
        }
        else if (timeToEnd > 30 && lessTime)
        {
            lessTimeOff();
            lessTime = false;
        }
    }

    public void PauseGame()
    {
        PlayClip(pauseClip);
        infoPanel.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        PlayClip(resumeClip);
        infoPanel.SetActive(false);
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
    private void FixedUpdate()
    {
        PauseCheck();
        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Labirynt");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Application.Quit();
            }
        }
    }

    public void WinGame()
    {
        gameWon = true;
        gameEnded = true;
    }
}
