using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class GoalNet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int score = 0;
    [SerializeField] private GameObject displayScore;
    [SerializeField] private bool isPlayerGoalNet;
    [SerializeField] private GameObject ResultOverlayScreen;
    [SerializeField] private GameObject TitleScreen;
    Collider2D collider2D;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            score++;
            TextMeshPro txtMeshProComponent = displayScore.GetComponent<TextMeshPro>();
            if (txtMeshProComponent)
            {
                txtMeshProComponent.SetText(score.ToString());
            }
            Destroy(collision.gameObject);
            ResultOverlayScreen.SetActive(true);
            TitleScreen.GetComponent<TextMeshProUGUI>().text = "you " + (isPlayerGoalNet ? "lose" : "win");
            InputSystem.actions.FindActionMap("Player").Disable();
        }
    }
    void OnDrawGizmos()
    {
        collider2D = GetComponent<Collider2D>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, collider2D.bounds.size);
    }
}
