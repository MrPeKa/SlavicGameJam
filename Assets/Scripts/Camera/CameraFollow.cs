using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject ObjectToFollow;

        // Use this for initialization
        void Start()
        {
            UnityEngine.Camera.main.transform.position = 
                new Vector3(ObjectToFollow.transform.position.x, 
                ObjectToFollow.transform.position.y, 
                UnityEngine.Camera.main.transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            UnityEngine.Camera.main.transform.position =
                new Vector3(ObjectToFollow.transform.position.x,
                ObjectToFollow.transform.position.y,
                UnityEngine.Camera.main.transform.position.z);
        }
    }
}