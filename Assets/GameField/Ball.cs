using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Rigidbody2D rd;
    Collider2D cd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rd.AddForce(Vector2.left * 100);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Vector2 b = (this.transform.position - collision.gameObject.transform.position);
            float angle = Mathf.Atan2(b.y, b.x);
            Vector2 redirectVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) / 2) + new Vector2(this.transform.position.x, this.transform.position.y);
            rd.linearVelocity = redirectVector.normalized;
        }
    }

}
