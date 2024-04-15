using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform mainCharacter;
    private Vector3 cameraInitPosition;
    private Vector3 cameraActualPosition;
    private Transform mainSpotlightTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraInitPosition = transform.position;
        cameraActualPosition = cameraInitPosition;
        GameObject mainSpotlight = GameObject.Find("MainSpotLight");
        if(mainSpotlight != null){
            mainSpotlightTransform = mainSpotlight.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraActualPosition.z = mainCharacter.position.z  - 7.5f;
        transform.position = cameraActualPosition;

        if(mainSpotlightTransform != null){
            Vector3 positionSpotLigth = mainSpotlightTransform.position;
            positionSpotLigth.z =  mainCharacter.position.z  - 10f;
            mainSpotlightTransform.position = positionSpotLigth;
        }
    }
}
