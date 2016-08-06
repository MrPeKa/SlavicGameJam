using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera
{
    public class ZoomInCameraWhileInTrigger : MonoBehaviour
    {
        public GameObject cameraObject;
        public GameObject triggerSource;
        public float cameraSize;
        public float scaleDuration;

        private bool animationStarted;
        private float previousCameraSize;
        private Coroutine currentScaling;

        void OnTriggerEnter2D(Collider2D collider)
        {
            //Debug.Log("Triggered");
            var collidingObj = collider.gameObject;
            if(collidingObj.CompareTag(triggerSource.tag))
            {
                var camera = cameraObject.GetComponent<UnityEngine.Camera>();
                previousCameraSize = camera.orthographicSize;
                currentScaling = StartCoroutine(SmoothCameraSizeChangeCoroutine(camera, scaleDuration, cameraSize));
            }

        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (currentScaling != null)
            {
                StopCoroutine(currentScaling);
                currentScaling = null;
            }
            var cam = cameraObject.GetComponent<UnityEngine.Camera>();
            //cam.orthographicSize = previousCameraSize;
            StartCoroutine(SmoothCameraSizeChangeCoroutine(cam, scaleDuration, previousCameraSize));
        }

        private IEnumerator SmoothCameraSizeChangeCoroutine(UnityEngine.Camera camera, float duration, float endVal)
        {
            animationStarted = true;

            float originalOrtographicSize = camera.orthographicSize;
            float startDiff = Mathf.Abs(endVal - originalOrtographicSize);
            float timeElapsed = .0f;
            float sign = (originalOrtographicSize < endVal) ? 1 : -1;
        
            while(timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;
                float factor = Mathf.Min(timeElapsed / duration, 1);
                camera.orthographicSize = originalOrtographicSize + factor * startDiff * sign;
                yield return null;
            }

            animationStarted = false;
        }

    }
}
