using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 1f;
    public float range = 100f;
    public float fireRate = 5f;

    [Header("References")]
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;

    float nextTimeToFire = 0f;

    void Update()
    {
        // Shoot when left mouse button is pressed
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position,
                            playerCamera.transform.forward,
                            out hit,
                            range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Check if object can be destroyed
            DestroyOnShot destroyable = hit.collider.GetComponent<DestroyOnShot>();

            if (destroyable != null)
            {
                destroyable.DestroyObject();
            }
        }
    }
}