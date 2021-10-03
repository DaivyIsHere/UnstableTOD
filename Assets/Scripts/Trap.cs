using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float delay = 1f;
    public float lifeTime = 3f;
    
    private Vector3 startPos;
    private float targetY = 0;

    void Start()
    {
        startPos = transform.position;
        targetY = startPos.y;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(Perform());
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(startPos.x, targetY, startPos.z),0.3f);
    }

    public IEnumerator Perform()
    {
        yield return new WaitForSeconds(delay);
        targetY = 1;
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(lifeTime -0.1f);
        targetY = -0.5f;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        yield return 0;
    }
}
