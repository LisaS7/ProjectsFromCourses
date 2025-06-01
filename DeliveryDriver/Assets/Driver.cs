using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 200f;
    [SerializeField] float moveSpeed = 13f;

    void Update()
    {
        float turnInput = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnInput);
        transform.Translate(0, moveInput, 0);
    }
}
