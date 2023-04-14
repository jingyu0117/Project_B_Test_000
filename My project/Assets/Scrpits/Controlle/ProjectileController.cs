using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 launchDirection;
    public GameObject Projecttile;
    // Start is called before the first frame update
    public void FireProjectile()
    {
        GameObject temp = (GameObject)Instantiate(Projecttile);

        temp.transform.position = this.gameObject.transform.position;
        temp.GetComponent<ProjectileMove>().launchDirection = transform.forward;

        Destroy(temp, 10f);
    }

}
