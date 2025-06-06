using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int pointsPerCoin = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameSession>().IncreaseScore(pointsPerCoin);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            Destroy(gameObject);


        }
    }
}
