using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrailEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Ground" && dustTrailEffect)
        {
            dustTrailEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && dustTrailEffect)
        {
            dustTrailEffect.Stop(true);
        }
    }
}
