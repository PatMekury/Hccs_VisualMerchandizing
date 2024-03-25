using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class MidFloorChoice : MonoBehaviour
    {
        public GameObject colorBlockingAnimation;
        public GameObject tableAnimation;
        public GameObject gondolaAnimation;
        public GameObject theTable;
        public GameObject theGondola;
        public GameObject MFCanvas;
        public GameObject placement;
        public AudioSource tableAudio;
        public AudioSource gondolaAudio;
        private Animator animator;
        private bool hasPlayed = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            if (tableAnimation.activeSelf && !hasPlayed && !gondolaAnimation.activeSelf)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                tableAudio.Play();
                hasPlayed = true;
                theTable.SetActive(true);
                MFCanvas.SetActive(false);
                placement.SetActive(false);
            }
            else if (!tableAudio.isPlaying && hasPlayed && !gondolaAnimation.activeSelf)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                tableAnimation.SetActive(false);
                hasPlayed = false;
                colorBlockingAnimation.SetActive(true);
                GetComponent<MidFloorChoice>().enabled = false;
               

            }

           if (gondolaAnimation.activeSelf && !hasPlayed && !tableAnimation.activeSelf)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                gondolaAudio.Play();
                hasPlayed = true;
                theGondola.SetActive(true);
            }
            else if (!gondolaAudio.isPlaying && hasPlayed && !tableAnimation.activeSelf)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                gondolaAnimation.SetActive(false);
                hasPlayed = false;
                theGondola.SetActive(false);

            } 
        }
    }
}
