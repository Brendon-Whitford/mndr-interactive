using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlanarCamera : MonoBehaviour
{
    void Start()
    {
        // subscribe to render pipeline camera updates, used for disabling fog in reflections as it causes visual bugs
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
        
        // create the camera to be used for this texture
        GameObject reflectCam = new GameObject("ReflectionCamera");
        planarCamera = reflectCam.AddComponent<Camera>();
        planarCamera.CopyFrom(prefabCamera);
        planarCamera.cullingMask = defaultMask;

        // store screen height and width
        screenHeightLastFrame = Screen.height;
        screenWidthLastFrame = Screen.width;

        // calculate the aspect ratio
        float ratio = playerCamera.GetComponent<Camera>().aspect;

        if (ratio >= 1.7)
        {
            aspectX = 16;
            aspectY = 9;
        }
        else if (ratio >= 1.6)
        {
            aspectX =16;
            aspectY = 10;
        }
        else if (ratio >= 1.5)
        {
            aspectX = 3;
            aspectY = 2;
        }
        else if (ratio >= 1.3)
        {
            aspectX = 4;
            aspectY = 3;
        }
        else if (ratio >= 1.25)
        {
            aspectX = 5;
            aspectY = 4;
        }
        else
        {
            aspectX = Screen.width / 120;
            aspectY = Screen.height / 120;
        }
        
        // create the render texture
        RenderTextureDescriptor texStruct = new RenderTextureDescriptor(aspectX * resolutionMultiplier, aspectY * resolutionMultiplier);
        texStruct.depthBufferBits = 16;
        texStruct.colorFormat = RenderTextureFormat.ARGB32;
        texStruct.useMipMap = true;
        planarCamera.targetTexture = new RenderTexture(texStruct);
        
        // set texture in material
        if (isUniqueMaterial)
        {
            GetComponent<MeshRenderer>().material.SetTexture("ReflectionTex", planarCamera.targetTexture);
            GetComponent<MeshRenderer>().material.SetFloat("Resolution", resolutionMultiplier);
        }
        else
        {
            GetComponent<MeshRenderer>().sharedMaterial.SetTexture("ReflectionTex", planarCamera.targetTexture);
            GetComponent<MeshRenderer>().sharedMaterial.SetFloat("Resolution", resolutionMultiplier);
        }

        // initialize a plane to reflect across, based on the assigned object's position and direction
        reflectionPlane = new Plane(-transform.forward, transform.position);
        
        ReflectPlanarCamera();

        // calculate a plane to clip along
        Vector4 clipPlaneWorldSpace = new Vector4(reflectionPlane.normal.x, reflectionPlane.normal.y, reflectionPlane.normal.z, -Vector3.Dot(reflectionPlane.normal, transform.position));
        Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(planarCamera.GetComponent<Camera>().cameraToWorldMatrix) * clipPlaneWorldSpace;
        planarCamera.GetComponent<Camera>().projectionMatrix = planarCamera.GetComponent<Camera>().CalculateObliqueMatrix(clipPlaneCameraSpace);
    }

    void Update()
    {
        // check if resolution has changed and swap texture accordingly (if screen is resized, aspect ratio changed, etc)
        if (Screen.height != screenHeightLastFrame || Screen.width != screenWidthLastFrame)
            ChangeRenderTextureRes(resolutionMultiplier);
        
        // update screen variables
        screenHeightLastFrame = Screen.height;
        screenWidthLastFrame = Screen.width;
    }

    void LateUpdate()
    {
        // done in late update so reflection is not delayed on next frame
        
        // re-intialize the plane in case it is moving
        reflectionPlane = new Plane(transform.up, transform.position);
        
        ReflectPlanarCamera();

        // calculate a plane to clip along
        Vector4 clipPlaneWorldSpace = new Vector4(reflectionPlane.normal.x, reflectionPlane.normal.y, reflectionPlane.normal.z, -Vector3.Dot(reflectionPlane.normal, transform.position));
        Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(planarCamera.GetComponent<Camera>().cameraToWorldMatrix) * clipPlaneWorldSpace;
        planarCamera.GetComponent<Camera>().projectionMatrix = planarCamera.GetComponent<Camera>().CalculateObliqueMatrix(clipPlaneCameraSpace);
    }

    // disable fog for this camera
    void OnBeginCameraRendering(ScriptableRenderContext context, Camera renderCamera)
    {
        if (renderCamera == planarCamera)
        {
            oldFogState = RenderSettings.fog;
            RenderSettings.fog = false;
        }
    }

    // re-enable fog for main camera (or otherwise restore old fog settings)
    void OnEndCameraRendering(ScriptableRenderContext context, Camera renderCamera)
    {
        RenderSettings.fog = oldFogState;
    }

    // unsubscribe if this object is somehow destroyed
    void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }

    // functions
    // determine the new position of the reflection camera based on a reflection across the water plane
    void ReflectPlanarCamera()
    {
        Vector3 cameraDirectionWorldSpace = playerCamera.transform.forward;
        Vector3 cameraUpWorldSpace = playerCamera.transform.up;
        Vector3 cameraPositionWorldSpace = playerCamera.transform.position;

        // transform these vector's to the plane's space
        Vector3 cameraDirectionPlaneSpace = transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraUpPlaneSpace = transform.InverseTransformDirection(cameraUpWorldSpace);
        Vector3 cameraPositionPlaneSpace = transform.InverseTransformPoint(cameraPositionWorldSpace);

        // mirror the y vectors to invert the camera
        cameraDirectionPlaneSpace.y *= -1;
        cameraUpPlaneSpace.y *= -1;
        cameraPositionPlaneSpace.y *= -1;

        // transform back to world space
        cameraDirectionWorldSpace = transform.TransformDirection(cameraDirectionPlaneSpace);
        cameraUpWorldSpace = transform.TransformDirection(cameraUpPlaneSpace);
        cameraPositionWorldSpace = transform.TransformPoint(cameraPositionPlaneSpace);

        // set camera position and rotation
        planarCamera.transform.position = cameraPositionWorldSpace;
        planarCamera.transform.LookAt(cameraPositionWorldSpace + cameraDirectionWorldSpace, cameraUpWorldSpace);

    }

    // change res of target tex
    public void ChangeRenderTextureRes(int upsampleAmount)
    {
        // calculate the aspect ratio
        float ratio = playerCamera.GetComponent<Camera>().aspect;

        if (ratio >= 1.7)
        {
            aspectX = 16;
            aspectY = 9;
        }
        else if (ratio >= 1.6)
        {
            aspectX =16;
            aspectY = 10;
        }
        else if (ratio >= 1.5)
        {
            aspectX = 3;
            aspectY = 2;
        }
        else if (ratio >= 1.3)
        {
            aspectX = 4;
            aspectY = 3;
        }
        else if (ratio >= 1.25)
        {
            aspectX = 5;
            aspectY = 4;
        }
        else
        {
            aspectX = Screen.width / 120;
            aspectY = Screen.height / 120;
        }
        
        // set up render texture
        RenderTextureDescriptor texStruct = new RenderTextureDescriptor(aspectX * resolutionMultiplier, aspectY * resolutionMultiplier);
        texStruct.depthBufferBits = 16;
        texStruct.colorFormat = RenderTextureFormat.ARGB32;
        texStruct.useMipMap = true;
        planarCamera.targetTexture = new RenderTexture(texStruct);
        
        // set texture in material
        if (isUniqueMaterial)
        {
            GetComponent<MeshRenderer>().material.SetTexture("ReflectionTex", planarCamera.targetTexture);
            GetComponent<MeshRenderer>().material.SetFloat("Resolution", resolutionMultiplier);
        }
        else
        {
            GetComponent<MeshRenderer>().sharedMaterial.SetTexture("ReflectionTex", planarCamera.targetTexture);
            GetComponent<MeshRenderer>().sharedMaterial.SetFloat("Resolution", resolutionMultiplier);
        }

    }

    // initialize variables
    // game objects
    [SerializeField] Camera prefabCamera;
    [HideInInspector] public Camera planarCamera;
    [SerializeField] GameObject playerCamera;
    [SerializeField] bool isUniqueMaterial = false;
    Plane reflectionPlane;
    public LayerMask defaultMask;
    public LayerMask disableMask;

    // variables
    bool oldFogState = true;
    int aspectX;
    int aspectY;
    public int resolutionMultiplier = 120;
    int screenWidthLastFrame = 0;
    int screenHeightLastFrame = 0;

    // distances and positions (unused)
    /*
    float distanceToWater;
    Vector3 planarCameraPosition = new Vector3(0,0,0);
    Vector3 planarCameraLook;
    */
}
