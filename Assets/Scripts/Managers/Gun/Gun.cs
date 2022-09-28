using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunScriptable gunScriptable;
    private int damage;
    private float range;
    private float rateOfFire;
    private Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public Transform muzzleTransform;
    private void Start()
    {
        fpsCamera = Camera.main;
        damage = gunScriptable.damage;
        range = gunScriptable.range;
        rateOfFire = gunScriptable.rateOfFire;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);
            }       
        }


    }
}
