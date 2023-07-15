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
        transform.Translate(Vector3.down*forwardMovementSpeed*Time.fixedDeltaTime); //down dememizin sebebi modelleme hatasý, yani z pozisyonumuz gideceðimiz yere deðil yukarý bakýyor 
    }

    private void SetHeroHorizontalMovement()  // yanalra girme kodu ama gideceði koordinatý HeroInpuControllerdan alýyor
    {
        newPositionX = transform.position.x + heroInputController.HorizonalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);  // newPositionX horizontalLimitValuenin - ve + deðerleri arasýnda kalmsýný saðlar. Sebebi ise kutunun þeritten aþaðý çýkmamsý için

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

}
