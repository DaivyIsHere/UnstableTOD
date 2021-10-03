using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityManager : MonoBehaviour
{
    public static RealityManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public GameObject projectileContainer;
    public GameObject projectilePref;
    public GameObject trapPref;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject NewProjectile(Vector3 offset, float Yrotation, float Speed)
    {
        GameObject p = Instantiate(projectilePref, new Vector3(0,1,0)+ offset, Quaternion.Euler(new Vector3(0,Yrotation,0)), projectileContainer.transform);
        p.GetComponent<Projectile>().spd = Speed;
        return p;
    }

    public GameObject NewTrap(Vector3 offset, float delay, float lifeTime)
    {
        GameObject p = Instantiate(trapPref, new Vector3(0,0.1f,0)+ offset, Quaternion.identity, projectileContainer.transform);
        p.GetComponent<Trap>().delay = delay;
        p.GetComponent<Trap>().lifeTime = lifeTime;
        return p;
    }

    public IEnumerator Card_IceBucket()
    {
        
        yield return 0;
    }

    
}
