using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera
{
    public class CenterCameraOnObjectTrigger : MonoBehaviour
    {
        public GameObject objectToBeCenteredOn;
        public GameObject cameraObject;
        public float cameraSize;

        private Transform previousOwner;
        private float previousCameraSize;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Triggered");
            var collidingObj = collider.gameObject;

            previousOwner = cameraObject.transform.parent;
            cameraObject.transform.parent = null;
            //cameraObject.transform.rotation = Quaternion.Euler(Vector3.zero);

            var cam = cameraObject.GetComponent<UnityEngine.Camera>();
            //cam.transform.LookAt(objectToBeCenteredOn.transform);
            //cameraObject.transform.parent = objectToBeCenteredOn.transform;
            cameraObject.transform.position = Vector3.zero;
            cameraObject.transform.Translate(objectToBeCenteredOn.transform.position, Space.World);

            previousCameraSize = cam.orthographicSize;
            cam.orthographicSize = cameraSize;
            //StartCoroutine(SmoothCameraPositionChangeCoroutine(cam, .5f, cameraObject.transform, objectToBeCenteredOn.transform));
            //StartCoroutine(SmoothCameraSizeChangeCoroutine(cam, .5f, cameraSize));

        }

        void OnTriggerExit2D(Collider2D collider)
        {
            cameraObject.transform.parent = previousOwner;
            //cameraObject.transform.LookAt(previousOwner.transform);
            cameraObject.transform.localPosition = Vector3.zero;

            var cam = cameraObject.GetComponent<UnityEngine.Camera>();
            cam.orthographicSize = previousCameraSize;
        }

        private IEnumerator SmoothCameraSizeChangeCoroutine(UnityEngine.Camera camera, float duration, float endVal)
        {
            float originalOrtographicSize = camera.orthographicSize;
            float startDiff = endVal - originalOrtographicSize;
            float timeElapsed = .0f;
        
            while(timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;
                float factor = Mathf.Min(timeElapsed / duration, 1);
                camera.orthographicSize = originalOrtographicSize + factor * startDiff;
                yield return null;
            }
        }

        private IEnumerator SmoothCameraPositionChangeCoroutine(UnityEngine.Camera camera, float duration, Transform tr1, Transform tr2)
        {
            var tr1StartPosition = tr1.position;
            var trailingVectorFromTr1ToTr2 = tr2.transform.position - tr1.transform.position;
            var normalizedTrailingVector = trailingVectorFromTr1ToTr2.normalized;
            var lastTrailingVector = Vector3.zero;
            float elapsedTime = .0f;

            while (elapsedTime <= duration)
            {
                elapsedTime += Time.deltaTime;
                float factor = Mathf.Min(elapsedTime / duration, 1);
                tr1.Translate(trailingVectorFromTr1ToTr2 * factor - lastTrailingVector, Space.World);
                lastTrailingVector = trailingVectorFromTr1ToTr2 * factor;
                yield return null;
            }
        }
    }
}
