using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public List<GameObject> objects = new List<GameObject>();
    private GameObject noListedGO;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    //public void ShowTrack(Vector3 hit,Quaternion rot,float rateOfFire)
    //{

    //    objects[0].gameObject.SetActive(true);
    //    objects[0].gameObject.transform.position = hit;
    //    objects[0].transform.rotation = rot;
    //    noListedGO = objects[0];
    //    objects.RemoveAt(0);
    //    Invoke("GetToThePool", 0.5f);
    //}
    public void GetToThePool()
    {
        objects.Add(noListedGO);
        noListedGO.transform.position = this.transform.position;
        noListedGO.SetActive(false);
    }
}
