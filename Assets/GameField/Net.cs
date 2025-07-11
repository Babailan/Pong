using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Net : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    enum PlayerNet
    {
        Player,
        Ai
    }
    Collider2D collider2D;
    void Start()
    {

        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        collider2D = GetComponent<Collider2D>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, collider2D.bounds.size);
    }
}
