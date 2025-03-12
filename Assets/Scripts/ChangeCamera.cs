using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeCamera : MonoBehaviour
{

    [SerializeField] private ARCameraManager arCameraManager;
    [SerializeField] private ARSession aRSession;

    public void ChangeCameraDirection()
    {
        //if camera is facing the world, change it to face the user
        if(arCameraManager.currentFacingDirection == CameraFacingDirection.World)
        {
            arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }

        //if camera is facing the user, change it to face the world
        if (arCameraManager.currentFacingDirection == CameraFacingDirection.User)
        {
            arCameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }

        aRSession.Reset();
    }
}
