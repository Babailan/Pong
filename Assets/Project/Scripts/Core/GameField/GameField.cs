using UnityEngine;
using UnityEngine.InputSystem;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ResultOverlayScreen;
    private InputAction playAgainAction;

    void Start()
    {
        playAgainAction = InputSystem.actions.FindAction("PlayAgain");
    }
    void Update()
    {
        if (playAgainAction.WasPressedThisFrame())
        {
            PlayAgain();
        }
    }

    void PlayAgain()
    {
        InputSystem.actions.FindActionMap("Player").Enable();
        SpawnBall();
    }
    void SpawnBall()
    {
        if (!GameObject.FindWithTag("Ball"))
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = this.transform.position;
            ResultOverlayScreen.SetActive(false);
        }
    }
}
