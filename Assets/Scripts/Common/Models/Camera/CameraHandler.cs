using Cinemachine;
using UnityEngine;

namespace Common.Models.Camera
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain _cameraBrain;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        
        public CinemachineBrain CameraBrain => _cameraBrain;
        public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    }
}