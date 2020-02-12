using UnityEngine;
using Valve.VR;

public class ShootWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public float nextTimeToFire = 0f;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public SteamVR_Input_Sources inputSource;
    public float shotPower = 100f;
    public GameObject casingPrefab;
    public Transform casingExitLocation;

    public void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }
    public void Shoot()
    {
        
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        Destroy(tempFlash, 0.5f);
        
        RaycastHit hit;
        if (Physics.Raycast(barrelLocation.transform.position, barrelLocation.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
   public void Bullet()
   {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Destroy(bullet, 0.7f);
   }
    public void Audio()
    {
        
        {
            GetComponent<AudioSource>().Play();
        }
    }
    public void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        Destroy(casing, 3f);
    }
}