using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleMovement : MonoBehaviour
{
    InputAction moveInputAction;
    public float speed = 15.0f;
    void Start()
    {
        moveInputAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInputAction.IsPressed())
        {
    
            Vector2 move = moveInputAction.ReadValue<Vector2>();
            Transform transform = GetComponent<Transform>();
            Vector2 newPosition = transform.position + (new Vector3(move.x, move.y) * speed * Time.deltaTime);
            SpriteRenderer paddleSprite = GetComponent<SpriteRenderer>();
            //limit the size based on the half size of paddleSprite:3 with offset a little bit of offset 1%
            if (Math.Abs(newPosition.y - Camera.main.transform.position.y) > Camera.main.orthographicSize - (((paddleSprite.bounds.size.y * 1.1) / 2)))
            {
                return;
            }
            transform.SetPositionAndRotation(newPosition, transform.rotation);
        }
    }




}
