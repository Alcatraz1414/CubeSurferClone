using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{

    [SerializeField] private HeroInputController heroInputController;

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;

    private float newPositionX;



    // Update is called once per frame
    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()  //ilerleme kodu
    {
        transform.Translate(Vector3.down*forwardMovementSpeed*Time.fixedDeltaTime); //down dememizin sebebi modelleme hatas�, yani z pozisyonumuz gidece�imiz yere de�il yukar� bak�yor 
    }

    private void SetHeroHorizontalMovement()  // yanalra girme kodu ama gidece�i koordinat� HeroInpuControllerdan al�yor
    {
        newPositionX = transform.position.x + heroInputController.HorizonalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);  // newPositionX horizontalLimitValuenin - ve + de�erleri aras�nda kalms�n� sa�lar. Sebebi ise kutunun �eritten a�a�� ��kmams� i�in

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

}
