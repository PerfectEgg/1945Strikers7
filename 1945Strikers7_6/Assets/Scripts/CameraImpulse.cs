using Unity.Cinemachine;
using UnityEngine;

public class CameraImpulse : MonoBehaviour
{
    public static CameraImpulse Instance;

    [SerializeField]
    CinemachineImpulseSource impulse;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
    }


    public void CameraShakeShow()
    {
        impulse.GenerateImpulse();
    }
}
