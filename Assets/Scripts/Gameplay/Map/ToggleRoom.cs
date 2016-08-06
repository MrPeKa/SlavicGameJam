using System.Collections;
using Assets.Scripts.NPC;
using Assets.Scripts.Sounds;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Map
{
    public class ToggleRoom : MonoBehaviour
    {
        public GameObject Room;
        public GameObject NPCs;
        public GameObject CorridorsToActivate;
        public GameObject CorridorsToDeactivate;
        public bool ActivateRoom;
        public Light Light;
        public RoomSound RoomIntroMusic;
        private AudioClip _clip;

//        private Sounds.Sounds _soundsManager;

        void Start()
        {
//            _soundsManager = GameObject.Find("Initialize Level").GetComponent<Sounds.Sounds>();
            _clip = SoundManager.PlayRoomIntroMusic(RoomIntroMusic);
        }

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

            if (Light.range > 0)
                yield break;

//            _soundsManager.PlayRoomIntroSound(RoomIntroMusic);

            Light.range = 0;
            yield return new WaitForSeconds(0.1f);

//            Room.transform.FindChild(GameplayServices.Constants.RoomBackgroundChild).gameObject.SetActive(true);
            Room.transform.FindChild("Environment").gameObject.SetActive(true);
            NPCs.GetComponent<HideNPCs>().Show();

            while (Light.range < 40)
            {
                Light.range = Mathf.Min(40, Light.range + 3);
                yield return new WaitForSeconds(0.1f);
            }
        }

        private IEnumerator HideRoom()
        {
            if (Light.range <= 0)
                yield break;

            while (Light.range > 0)
            {
                Light.range = Mathf.Max(0, Light.range - 3);
                yield return new WaitForSeconds(0.07f);
            }

//            Room.transform.FindChild(GameplayServices.Constants.RoomBackgroundChild).gameObject.SetActive(false);
            Room.transform.FindChild("Environment").gameObject.SetActive(false);
            NPCs.GetComponent<HideNPCs>().Hide();

//            _soundsManager.StopRoomIntroSound(RoomIntroMusic);
        }
    }
}