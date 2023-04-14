using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject PlayerPivot;
    Camera viewCamera;
    Vector3 velocity;
    public ProjectileController projectileController;
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));


        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        //받아온 피봇이 마우스를 보게 한다.
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            projectileController.FireProjectile();
        }

    }
    
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
        //GetComponet -> 소스가 있는 게임오브젝트에서 <> 안에 있는 컴퍼넌트를 접근
    }
}
