using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject resultOverlayScreen;
    [SerializeField] private GameObject pauseOverlayScreen;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] public float score = 0;
    [SerializeField] public GameObject titleScreen;

    public bool isPlaying;
    public bool isPause;
    private InputAction playAgainAction;
    private InputAction pauseAndResumeAction;

    void Start()
    {
        StartGame();
        playAgainAction = InputSystem.actions.FindAction("PlayAgain");
        pauseAndResumeAction = InputSystem.actions.FindAction("Pause/Resume");
    }
    void Update()
    {
        if (playAgainAction.WasPressedThisFrame())
        {
            StartGame();
        }
        if (pauseAndResumeAction.WasPressedThisFrame())
        {
            EitherPauseResumeGame();
        }
        if (isPlaying && !isPause)
        {
            score += 100 * Time.deltaTime;
            UpdateScoreBoard();
        }

    }


    void SpawnBall()
    {
        if (!GameObject.FindWithTag("Ball"))
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = this.transform.position;
        }
    }
    private void DisplayScoreResultOverlay()
    {
        TextMeshProUGUI titleScreenTextComponent = titleScreen.GetComponent<TextMeshProUGUI>();
        titleScreenTextComponent.text = "Score: " + ((int)score).ToString();
        resultOverlayScreen.SetActive(true);
    }
    public void UpdateScoreBoard()
    {
        TextMeshPro scoreBoardTxt = scoreBoard.GetComponent<TextMeshPro>();
        scoreBoardTxt.text = ((int)score).ToString();
    }
    private void DisablePlayerControl()
    {
        InputSystem.actions.FindActionMap("Player").Disable();
    }
    private void EnablePlayerControl()
    {
        InputSystem.actions.FindActionMap("Player").Enable();
    }
    public void EndGame()
    {
        isPlaying = false;
        DisablePlayerControl();
        DisplayScoreResultOverlay();
    }

    public void StartGame()
    {
        if (isPlaying)
        {
            return;
        }
        score = 0;
        isPlaying = true;
        isPause = false;
        EnablePlayerControl();
        resultOverlayScreen.SetActive(false);
        SpawnBall();
    }

    void EitherPauseResumeGame()
    {
        if (isPause)
        {
            Time.timeScale = 1f;
            isPause = false;
            pauseOverlayScreen.SetActive(false);
            return;
        }
        if (isPlaying)
        {
            Time.timeScale = 0f;
            isPause = true;
            pauseOverlayScreen.SetActive(true);
            return;
        }
    }
}
