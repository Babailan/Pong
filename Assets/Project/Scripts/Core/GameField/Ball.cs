using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rd;
    [SerializeField] public float speed = 300f;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        MoveInRandomDirection();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 b = (this.transform.position - collision.gameObject.transform.position);
            float angle = Mathf.Atan2(b.y, b.x);
            Vector2 redirectVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) / 2);
            rd.linearVelocity = redirectVector.normalized * rd.linearVelocity.magnitude;
        }
    }

    public void MoveInRandomDirection()
    {
        // Choose base direction: left or right (add also a little bit of  angle)
        Vector2 baseDirection = Random.value > 0.5f ? Vector2.left : Vector2.right;

        float yOffset = Random.Range(-0.5f, 0.5f);

        Vector2 angledDirection = new Vector2(baseDirection.x, yOffset).normalized;

        // Apply force
        this.rd.AddForce(angledDirection * speed);
    }
}
