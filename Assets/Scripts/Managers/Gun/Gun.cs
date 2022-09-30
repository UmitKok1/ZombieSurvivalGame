using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool = null;
    public GunScriptable gunScriptable;
    private int damage;
    private float range;
    private float rateOfFire;
    private Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public Transform muzzleTransform;
    public GameObject impactEffect;
    RaycastHit hit;
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
        muzzleFlash.Play();
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {               
                enemy.TakeDamage(damage);
            }
            if (hit.transform.gameObject.tag=="Objects")
            {
                ShowTrack();
            }
            
            //Pool.instance.ShowTrack(hit.transform.position, Quaternion.LookRotation(hit.normal), rateOfFire);
        }


    }
    void ShowTrack()
    {
        GameObject temp = objectPool.GetPooledObject(0);
        temp.gameObject.transform.position = hit.point;
        temp.transform.rotation = Quaternion.LookRotation(hit.normal);
    }
}
