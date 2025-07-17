using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GoalNet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject gameField;
    private Collider2D collider2D;
    private AudioSource gameOverAudio;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        gameOverAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            GameField gameFieldScript = gameField.GetComponent<GameField>();
            gameFieldScript.EndGame();
            gameOverAudio.Play();
        }
    }
    void OnDrawGizmos()
    {
        collider2D = GetComponent<Collider2D>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, collider2D.bounds.size);
    }
}
