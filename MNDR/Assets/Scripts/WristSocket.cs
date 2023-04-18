using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WristSocket : XRSocketInteractor
{

    //static public ToNextScene Script;
    // Sizing
    public float targetSize = 0.25f;//
    public float sizingDuration = 0.25f;
   
    

    // Runtime
    private Vector3 originalScale = Vector3.one;
    private Vector3 objectSize = Vector3.zero;

    // Prevents random objects from being selected
    private bool canSelect = false;

    protected override void OnHoverEntering(XRBaseInteractable interactable)
    {
        base.OnHoverEntering(interactable);

        // If the object is already selected, wrist can grab it
        if (interactable.isSelected)
        {
            canSelect = true; 
        }
    }
   
    protected override void OnHoverExiting(XRBaseInteractable interactable)
    {
        base.OnHoverExiting(interactable);

        // If the wrist didn't grab the object, we can no longer select
        if (!selectTarget)
        {
            canSelect = false;
        }
    }

    protected override void OnSelectEntering(XRBaseInteractable interactable)
    {
        // Store object when select begins
        base.OnSelectEntering(interactable);
        //StoreObjectSizeScale(interactable);
    }

    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        // Once select has occured, scale object to size
        base.OnSelectEntered(interactable);
        Destroy(interactable);
        //TweenSizeToSocket(interactable);
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        // Once the user has grabbed the object, scale to original size
       // base.OnSelectExited(interactable);
       // SetOriginalScale(interactable);
       // canSelect = false;
    }

    /*private void StoreObjectSizeScale(XRBaseInteractable interactable)
    {
        // Find the object's size
        objectSize = FindObjectSize(interactable.gameObject);
        originalScale = interactable.transform.localScale;
    }*/

   /* private Vector3 FindObjectSize(GameObject objectToMeasure)
    {
        Vector3 size = Vector3.one;

        // Assumes the interactable has one mesh on the root
      //  if(objectToMeasure.TryGetComponent(out MeshFilter meshFilter))
        
           // size = ColliderMeasurer.Instance.Measure(meshFilter.mesh);
        

        return size;
    }*/

   /* private void TweenSizeToSocket(XRBaseInteractable interactable)
    {
        // Find the new scale based on the size of the collider, and scale
        Vector3 targetScale = FindTargetScale();
        // Tween to our new scale
       interactable.transform.localScale = targetScale;
       
    }*/

   /* private Vector3 FindTargetScale()
    {
        // Figure out new scale, we assume the object is originally uniformly scaled
        float largestSize = FindLargestSize(objectSize);
        float scaleDifference = targetSize / largestSize;
        return Vector3.one * scaleDifference;
    }*/

   /* private void SetOriginalScale(XRBaseInteractable interactable)
    {
        // This isn't necessary, but prevents an error when exiting play
        if (interactable)
        {


            interactable.transform.localScale = originalScale;


            originalScale = Vector3.one;
            objectSize = Vector3.zero;
        }
        // Restore object to original scale

        // Reset just incase
        originalScale = Vector3.one;
        objectSize = Vector3.zero;
    }*/

   /* private float FindLargestSize(Vector3 value)
    {
        float largestSize = Mathf.Max(value.x, value.y);
        largestSize = Mathf.Max(largestSize, value.z);
        return largestSize ;
    }*/

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        // Move while ignoring physics, and no smoothing
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }

    // Is the socket active, and object is being held by different interactor
    public override bool isSelectActive => base.isSelectActive && canSelect;

    private void OnDrawGizmos()
    {
        // Draw the approximate size of the socketed object
        Gizmos.DrawWireSphere(transform.position, targetSize * 0.5f);
    }
}
