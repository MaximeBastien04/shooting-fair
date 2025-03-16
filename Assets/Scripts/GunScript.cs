using UnityEngine;

public class GunScript : MonoBehaviour
{
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.localPosition;
        Debug.Log(originalPosition);
    }


    void Update()
    {
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
}
