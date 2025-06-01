using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 0.6f;
    Rigidbody2D rb2D;
    
    void Start()
    {
        rb2D =  GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rb2D.AddTorque(-torqueAmount);
        }
    }
}
