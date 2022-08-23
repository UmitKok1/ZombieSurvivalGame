using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunScriptable gunScriptable;
    private int damage;
    private float range;
    private float rateOfFire;
    public Camera fpsCamera;

    private void Start()
    {
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
        Debug.Log("BOOOOM");
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            Debug.Log("BOOOOM");
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("BOOOOM");
            }
        }


    }
}
