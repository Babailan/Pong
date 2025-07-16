using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject resultOverlayScreen;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] public float score = 0;
    [SerializeField] public GameObject titleScreen;

    public bool isPlaying = false;
    private InputAction playAgainAction;

    void Start()
    {
        StartGame();
        playAgainAction = InputSystem.actions.FindAction("PlayAgain");
    }
    void Update()
    {
        if (resultOverlayScreen.activeSelf && playAgainAction.WasPressedThisFrame())
        {
            PlayAgain();
        }
        if (isPlaying)
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
        isPlaying = true;
        EnablePlayerControl();
        resultOverlayScreen.SetActive(false);
    }
    void PlayAgain()
    {
        StartGame();
        SpawnBall();
        score = 0;
    }
}
