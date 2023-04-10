using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SceneReload : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    private string cameraTag = "mainVcam"; // The tag of the virtual camera to save and restore

    private void Start()
    {
        // Restore the camera's position and rotation
        CinemachineVirtualCamera virtualCamera = GetVirtualCameraWithTag(cameraTag);
        virtualCamera.transform.position = cameraPosition;
        virtualCamera.transform.rotation = cameraRotation;
    }

    // for later add a parameter to customize what camera tag is being searched for
    public void SaveCamPos()
    {
        // Save the camera's current position and rotation
        CinemachineVirtualCamera virtualCamera = GetVirtualCameraWithTag(cameraTag);
        cameraPosition = virtualCamera.transform.position;
        cameraRotation = virtualCamera.transform.rotation;
    }

    public void ReloadScene()
    {
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private CinemachineVirtualCamera GetVirtualCameraWithTag(string tag)
    {
        // Find the virtual camera with the specified tag
        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        ICinemachineCamera activeVirtualCamera = cinemachineBrain.ActiveVirtualCamera;
        CinemachineVirtualCamera virtualCamera = activeVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        /*
        while (virtualCamera != null && virtualCamera.GetComponent<CinemachineBrain>() == null)
        {
            if (virtualCamera.m_Lens.Tag == tag)
            {
                return virtualCamera;
            }
            else
            {
                virtualCamera = virtualCamera.ParentCamera as CinemachineVirtualCamera;
            }
        }*/

        Debug.LogWarning("No virtual camera with tag '" + tag + "' was found!");
        return null;
    }


}