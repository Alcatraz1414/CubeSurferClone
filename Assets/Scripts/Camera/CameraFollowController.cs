using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{

    [SerializeField] private Transform HeroTransform;
    private Vector3 offset;
    private Vector3 newPosition;
    [SerializeField] private float lerpValue;


    void Start()
    {
        offset= transform.position - HeroTransform.position;  //kamera ile hero arasýndaki mesafe
    }

    // Update is called once per frame
    void LateUpdate()// normal Update ve FixedUpdate den daha sonra çalýþtýðý için genelde kameralarda öneriliyor.
    {
        setCameraSmoothFollow();
    }

    private void setCameraSmoothFollow()
    {
        newPosition=Vector3.Lerp(transform.position, new Vector3(0f,HeroTransform.position.y, HeroTransform.position.z)+offset, lerpValue*Time.deltaTime);
        transform.position = newPosition;
    }

}
