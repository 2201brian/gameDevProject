using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform mainCharacter;
    [SerializeField] private Transform lightInFront;
    [SerializeField] private Transform ligthBehind;
    private Vector3 cameraInitPosition;
    private Vector3 cameraActualPosition;
    private Vector3 lightFrontInitPosition;
    private Vector3 lightFrontActualPosition;
    private Vector3 lightBehindInitPosition;
    private Vector3 lightBehindActualPosition;
    private Transform mainSpotlightTransform;
    // Start is called before the first frame update
    void Start()
    {
        //camera postion
        // cameraInitPosition = transform.position;
        // cameraActualPosition = cameraInitPosition;
        //lights follow caracther position
        lightFrontInitPosition = transform.position;
        lightFrontActualPosition = lightFrontInitPosition;
        lightBehindInitPosition = transform.position;
        lightBehindActualPosition = lightBehindInitPosition;

        GameObject mainSpotlight = GameObject.Find("MainSpotLight");
        if(mainSpotlight != null){
            mainSpotlightTransform = mainSpotlight.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // cameraActualPosition.z = mainCharacter.position.z  - 3f;
        // transform.position = cameraActualPosition;

        lightFrontActualPosition.x = mainCharacter.position.x - 1.91f;
        lightFrontActualPosition.y = mainCharacter.position.y - 10.31f;
        lightFrontActualPosition.z = mainCharacter.position.z - 22.92f;
        lightInFront.position = lightFrontActualPosition;
        
        lightBehindActualPosition.x = mainCharacter.position.x - 1.91f;
        lightBehindActualPosition.y = mainCharacter.position.y - 10.31f;
        lightBehindActualPosition.z = mainCharacter.position.z - 27f;
        ligthBehind.position = lightFrontActualPosition;

        if(mainSpotlightTransform != null){
            Vector3 positionSpotLigth = mainSpotlightTransform.position;
            positionSpotLigth.z =  mainCharacter.position.z  - 10f;
            mainSpotlightTransform.position = positionSpotLigth;
        }
    }
}
