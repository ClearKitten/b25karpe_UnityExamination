using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for faking perspective through parallax while using an orthographic camera. Using this script together with a perspective camera is not advised.
// 
public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [Tooltip(
        "How much horizontal parallax? Higher value corresponds to the object being far away. Range between 0 and 1 for each element.")]
    [Range(0, 1)]
    [SerializeField] protected float parallaxFactorX = 0.25f;
    [Tooltip(
        "How much vertical parallax? Higher value corresponds to the object being far away. Range between 0 and 1 for each element.")]
    [Range(0, 1)]
    [SerializeField] protected float parallaxFactorY = 0f;

    protected Vector2 parallaxFactor;
    protected Vector3 previousCameraPosition;

    protected virtual void Start()
    {
        if (mainCamera == null)
        {
            // This requires the camera to be tagged as main-camera
            mainCamera = Camera.main;
        }
        parallaxFactor = new Vector2(parallaxFactorX, parallaxFactorY);
        previousCameraPosition = mainCamera.transform.position;
    }

    protected virtual void Update()
    {
        Vector3 currentCameraPosition = mainCamera.transform.position;
        Vector3 cameraDelta = currentCameraPosition - previousCameraPosition;
        Vector3 translation = new Vector3();
        translation.x = cameraDelta.x * parallaxFactor.x;
        translation.y = cameraDelta.y * parallaxFactor.y;
        
        transform.position += translation;
        previousCameraPosition = currentCameraPosition;
    }
}