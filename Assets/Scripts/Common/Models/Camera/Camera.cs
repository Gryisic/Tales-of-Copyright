using Cinemachine;
using UnityEngine;

namespace Common.Models.Camera
{
    public abstract class Camera
    {
        protected readonly CinemachineBrain cameraBrain;
        protected readonly CinemachineVirtualCamera camera;

        public Camera(CinemachineBrain cameraBrain, CinemachineVirtualCamera camera)
        {
            this.camera = camera;
            this.cameraBrain = cameraBrain;
        }
        
        public void Focus(Transform focusOn)
        {
            Vector3 vector = focusOn.transform.position;
            vector.z = -10;
            
            camera.transform.position = vector;
        }

        public void Follow(Transform followTo) 
        {
            camera.Follow = followTo;
        }
    }
}