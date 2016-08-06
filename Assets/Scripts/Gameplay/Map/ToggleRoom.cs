using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Map
{
    public class ToggleRoom : MonoBehaviour
    {
        public GameObject Room;
        public GameObject CorridorsToActivate;
        public GameObject CorridorsToDeactivate;
        public bool ActivateRoom;
        public Light Light;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(GameplayServices.Tags.Player))
            {
                if (ActivateRoom)
                    StartCoroutine(DisplayRoom());
                else
                    StartCoroutine(HideRoom());
            }
        }

        private IEnumerator DisplayRoom()
        {
            if (!CorridorsToActivate.activeSelf)
                CorridorsToActivate.SetActive(true);

            if (CorridorsToDeactivate.activeSelf)
                CorridorsToDeactivate.SetActive(false);

            if (Room.activeSelf)
                yield break;

            Light.range = 0;
            yield return new WaitForSeconds(0.1f);

            Room.SetActive(true);

            Light.range = 10;
            yield return new WaitForSeconds(0.1f);
            Light.range = 20;
            yield return new WaitForSeconds(0.1f);
            Light.range = 30;
            yield return new WaitForSeconds(0.1f);
            Light.range = 40;
        }

        private IEnumerator HideRoom()
        {
            if (!Room.activeSelf)
                yield break;

            yield return new WaitForSeconds(0.1f);
            Light.range = 30;
            yield return new WaitForSeconds(0.1f);
            Light.range = 20;
            yield return new WaitForSeconds(0.1f);
            Light.range = 10;
            yield return new WaitForSeconds(0.1f);
            Light.range = 0;

            Room.SetActive(false);
        }

    }
}