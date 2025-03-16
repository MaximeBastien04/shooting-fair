using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    private Vector3 originalPosition;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;

    private int currentBulletAmount = 8;
    private int maxBullets = 8;

    // UI
    [SerializeField] private TextMeshProUGUI bulletAmountText;
    [SerializeField] private Image bulletStateImage;
    [SerializeField] private Sprite bulletAvailable;
    [SerializeField] private Sprite bulletUnavailable;

    void Start()
    {
        Debug.Log(currentBulletAmount);
        originalPosition = transform.localPosition;
        bulletAmountText.text = currentBulletAmount + "/" + maxBullets;

    }


    void Update()
    {

        // Shooting rate
        if (Input.GetMouseButton(0) && currentBulletAmount > 0)
        {
            Shoot();
        }
        
        if (currentBulletAmount <= 0)
        {
            bulletStateImage.sprite = bulletUnavailable;
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
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }

            currentBulletAmount--;
            bulletAmountText.text = currentBulletAmount + "/" + maxBullets;
            Destroy(bullet, 3f); // Destroy the bullet after 3 seconds to save memory
        }
    }
}
