using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Sprite playerUpSprite;
    [SerializeField] private Sprite playerSideSprite;
    [SerializeField] private Sprite playerDownSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMovement, yMovement).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;

        SetSprite(xMovement, yMovement);
    }

    private void SetSprite(float xMovement, float yMovement)
    {
        MoveDirection moveDirection = GetMoveDirection(xMovement, yMovement);
        switch (moveDirection)
        {
            case MoveDirection.UP:
                spriteRenderer.sprite = playerUpSprite;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case MoveDirection.DOWN:
                spriteRenderer.sprite = playerDownSprite;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case MoveDirection.RIGHT:
                spriteRenderer.sprite = playerSideSprite;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case MoveDirection.LEFT:
                spriteRenderer.sprite = playerSideSprite;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }

    private MoveDirection GetMoveDirection(float xMovement, float yMovement)
    {
        if(yMovement > 0)
        {
            return MoveDirection.UP;
        }else if(yMovement < 0)
        {
            return MoveDirection.DOWN;
        }
        else
        {
            if(xMovement > 0)
            {
                return MoveDirection.RIGHT;
            }else if(xMovement < 0)
            {
                return MoveDirection.LEFT;
            }
        }
        return MoveDirection.NONE;
    }

    private enum MoveDirection
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        NONE
    }

}
