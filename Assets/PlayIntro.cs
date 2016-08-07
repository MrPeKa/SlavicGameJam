using UnityEngine;

namespace Assets
{
	public class PlayIntro : MonoBehaviour
	{
        public AudioClip Intro;

		// Use this for initialization
		void Start()
		{
			var audioSource = GetComponent<AudioSource>();
			audioSource.clip = Intro;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}