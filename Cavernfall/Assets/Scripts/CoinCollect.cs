using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);

        }
    }
}
