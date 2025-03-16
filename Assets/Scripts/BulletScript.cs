using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Bullet spawned");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Target hit!");
        }
    }
}
