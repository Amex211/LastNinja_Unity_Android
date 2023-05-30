using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canJump;
    private Rigidbody rigidbodyComponent;

    [SerializeField] private Transform gorundCheckTransform;
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                MoveLeft();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                MoveRight();
            }
        }
        if (Physics.OverlapSphere(gorundCheckTransform.position, 0.1f).Length == 1)
        { return; }

        if (Input.touchCount == 2 && canJump)
        {
            Jump();
        }
        else if (Input.touchCount < 2)
        {
            canJump = true;
        }


        if (Input.touchCount == 0){
            StopMoving();
        }
    }

    void Jump()
    {
        rigidbodyComponent.AddForce(Vector3.up * 7f, ForceMode.VelocityChange);
        canJump = false;
    }

    void MoveLeft()
    {
        rigidbodyComponent.velocity = new Vector3(-2f, rigidbodyComponent.velocity.y, 0f);
    }

    void MoveRight()
    {
        rigidbodyComponent.velocity = new Vector3(2f, rigidbodyComponent.velocity.y, 0f);
    }

    void StopMoving()
    {
        rigidbodyComponent.velocity = Vector3.zero;
    }
}