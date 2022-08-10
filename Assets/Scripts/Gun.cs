using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 100f;

    public Camera fpsCamera;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


        void Shoot()
        {
            RaycastHit hit;

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
}
