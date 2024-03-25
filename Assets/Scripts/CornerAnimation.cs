using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class CornerAnimation : MonoBehaviour
    {
        public GameObject cornerObject;
        public GameObject FSCanvas;
        public GameObject placement;
        public AudioSource cornerAudio;
        private Animator animator;
        private bool hasPlayed = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (cornerObject.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                cornerAudio.Play();
                hasPlayed = true;
                FSCanvas.SetActive(false);
                placement.SetActive(false);

            }
            else if (!cornerAudio.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                FSCanvas.SetActive(true);
                placement.SetActive(true);
                cornerObject.SetActive(false);
            }
        }
    }
}
