using UnityEngine;

public class GunScript : MonoBehaviour
{
    private Vector3 originalPosition;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    // [SerializeField] private float fireRate = 2f;
    // [SerializeField] private float nextFireTime = 2f;

    private int currentBulletAmount = 8;
    private int maxBullets = 8;

    void Start()
    {
        Debug.Log(currentBulletAmount);
        originalPosition = transform.localPosition;
    }


    void Update()
    {

        // Shooting rate
        if (Input.GetMouseButton(0) && currentBulletAmount > 0) // Left mouse button
        {
            Shoot();
            // nextFireTime = Time.time + fireRate;
        }
    }

    public void FocusGun()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.localPosition = new Vector3(0, originalPosition.y, originalPosition.z);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = originalPosition;
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * bulletSpeed; // Move the bullet forward
            }

            currentBulletAmount--;
            Debug.Log(currentBulletAmount);
            Destroy(bullet, 3f); // Destroy the bullet after 3 seconds to save memory
        }
    }
}
