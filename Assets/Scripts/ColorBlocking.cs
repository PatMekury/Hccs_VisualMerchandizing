using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class ColorBlocking : MonoBehaviour
    {
        public GameObject colorBlockingAnimation;
        public AudioSource colorBlockingAudio;
        public GameObject MQAnimation;
        public GameObject clothes; 

        private Animator animator;
        private bool hasPlayed = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {

        }

        void Update()
        {
            if (colorBlockingAnimation.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                colorBlockingAudio.Play();
                hasPlayed = true;
                clothes.SetActive(true);
            }
            else if (!colorBlockingAudio.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                colorBlockingAnimation.SetActive(false);
                MQAnimation.SetActive(true);
                GetComponent<ColorBlocking>().enabled = false;

            }
        }
    }
}
