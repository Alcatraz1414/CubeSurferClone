using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeController : MonoBehaviour
{

    [SerializeField] private HeroStackController heroStackController;
    private bool isStack = false;
    private RaycastHit hit;
    private Vector3 direction = Vector3.back;

    void Start()
    {
        heroStackController=GameObject.FindObjectOfType<HeroStackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        Debug.DrawRay(transform.position, direction*10f,Color.blue);
        if (Physics.Raycast(transform.position,direction,out hit,1f))
        {
            if (!isStack)
            {
                isStack = true;
                heroStackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }

            if(hit.transform.name== "ObstacleCube")
            {
                heroStackController.DecreaseBlock(gameObject); 
            }
        }
    }


    private void SetDirection()
    {
        direction = Vector3.forward;
    }

}
