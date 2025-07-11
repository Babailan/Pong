using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] GameObject boundary;

    InputAction moveInputAction;
    InputAction omitBallAction;
    SpriteRenderer paddleSprite;
    SpriteRenderer boundarySprite;
    [SerializeField] GameObject ball;
    public float speed = 15.0f;
    void Start()
    {
        moveInputAction = InputSystem.actions.FindActionMap("Player").FindAction("Move");
        omitBallAction = InputSystem.actions.FindActionMap("Player").FindAction("OmitBall");
        paddleSprite = GetComponent<SpriteRenderer>();
        boundarySprite = boundary.GetComponent<SpriteRenderer>();
        positionThePaddle();
    }

    // Update is called once per frame
    void Update()
    {
        onMoveAction();
        onOmitBall();
    }

    private void onOmitBall()
    {
        if (omitBallAction.IsPressed())
        {
            Debug.Log("hellnah");
        }
    }
    private void onMoveAction()
    {
        if (moveInputAction.IsPressed())
        {

            Vector2 move = moveInputAction.ReadValue<Vector2>();
            Vector2 newPosition = transform.position + (new Vector3(move.x, move.y) * speed * Time.deltaTime);
            float paddleHalfHeight = paddleSprite.bounds.size.y / 2;
            float verticalDistanceFromCamera = Mathf.Abs(newPosition.y - Camera.main.transform.position.y) + paddleHalfHeight;
            if (verticalDistanceFromCamera > Math.Abs(this.boundary.transform.position.y - (boundarySprite.bounds.size.y / 2)))
            {
                return;
            }
            this.transform.SetPositionAndRotation(newPosition, this.transform.rotation);
        }
    }


    void positionThePaddle()
    {
        //Position the paddle to the edge of the boundary
        Vector2 newPosition = new Vector2(-Math.Abs(((boundarySprite.bounds.size.x / 2) - (this.paddleSprite.bounds.size.x / 2))), 0);
        this.transform.position = newPosition;
    }

    void OnDrawGizmos()
    {
        if (this.ball == null)
        {
            return;
        }
        SpriteRenderer paddle = GetComponent<SpriteRenderer>();
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, paddle.bounds.size.y / 2);
        Gizmos.color = Color.red;
        Vector2 b = (this.ball.transform.position - this.transform.position);
        Gizmos.DrawLine(this.transform.position, new Vector2(this.transform.position.x, this.ball.transform.position.y));
        Gizmos.DrawLine(this.transform.position, new Vector2(this.ball.transform.position.x, this.transform.position.y));
        float angle = Mathf.Atan2(b.y, b.x);
        Vector2 normalized = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) / 2) + new Vector2(this.transform.position.x, this.transform.position.y);
        Gizmos.DrawWireCube(b, Vector2.one);
        Gizmos.DrawLine(this.transform.position, normalized);
    }



}
