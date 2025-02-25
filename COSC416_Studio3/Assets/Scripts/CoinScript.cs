using UnityEngine;

public class CoinScript: MonoBehaviour
{
    public float speed = 5f;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            scoreManager.incrememntScore();
        }
    }
}
