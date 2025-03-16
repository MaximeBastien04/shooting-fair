using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    private Vector3 originalPosition;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float reloadingTime = 2f;

    private int currentBulletAmount = 8;
    private int maxBullets = 8;
    private bool isReloading = false;

    // UI
    [SerializeField] private TextMeshProUGUI bulletAmountText;
    [SerializeField] private TextMeshProUGUI pressToReloadMessage;
    [SerializeField] private TextMeshProUGUI reloadingMessage;
    [SerializeField] private Image bulletStateImage;
    [SerializeField] private Sprite bulletAvailable;
    [SerializeField] private Sprite bulletUnavailable;

    void Start()
    {
        Debug.Log(currentBulletAmount);
        originalPosition = transform.localPosition;
        bulletAmountText.text = currentBulletAmount + "/" + maxBullets;
        pressToReloadMessage.gameObject.SetActive(false);
        reloadingMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentBulletAmount < maxBullets)
        {
            StartCoroutine(Reload());
        }

        // Shooting rate
        if (Input.GetMouseButton(0) && currentBulletAmount > 0 && !isReloading )
        {
            Shoot();
        }

        // Change bullet sprite when no bullets are available
        if (currentBulletAmount <= 0 && !isReloading )
        {
            bulletStateImage.sprite = bulletUnavailable;
            pressToReloadMessage.gameObject.SetActive(true);
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

    private IEnumerator Reload()
    {
        pressToReloadMessage.gameObject.SetActive(false);
        isReloading = true;
        reloadingMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(reloadingTime); // Wait for 2 seconds

        currentBulletAmount = maxBullets;
        reloadingMessage.gameObject.SetActive(false);
        bulletAmountText.text = currentBulletAmount + "/" + maxBullets;
        bulletStateImage.sprite = bulletAvailable;
        pressToReloadMessage.gameObject.SetActive(false);
        isReloading = false;
    }
}
