using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class GoalNet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int score = 0;
    [SerializeField] GameObject displayScore;
    Collider2D collider2D;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {

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
        }
    }
    void OnDrawGizmos()
    {
        collider2D = GetComponent<Collider2D>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, collider2D.bounds.size);
    }

}
