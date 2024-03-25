using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FashionHouse
{
    public class WelcomeAnimation : MonoBehaviour
    {
        public GameObject IntroductionAnimation;
        public GameObject StoreLayout;
        public GameObject FPQuestTrigger;
        public AudioSource audioSource;
        private Animator animator;
        private bool hasPlayed = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (IntroductionAnimation.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                
                audioSource.Play();
                hasPlayed = true;
                StoreLayout.SetActive(true);
              
            }
            else if (!audioSource.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                
                StoreLayout.SetActive(false);
                FPQuestTrigger.SetActive(true);
                IntroductionAnimation.SetActive(false);
                GetComponent<WelcomeAnimation>().enabled = false;
            }
        }
    }
}
