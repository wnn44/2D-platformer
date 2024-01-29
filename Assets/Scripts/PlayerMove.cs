using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 300f;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * Speed * Time.deltaTime);
    }
}
