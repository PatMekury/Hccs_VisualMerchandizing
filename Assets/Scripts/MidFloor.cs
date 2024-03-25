using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class MidFloor : MonoBehaviour
    {
        public GameObject MFCanvas;
        public GameObject MFAnimation;
        public AudioSource MFStart;
        public GameObject shelf2;
        public GameObject wallFixtures;
        public GameObject MFBlueprint;
        public GameObject placement;
        private Animator animator;
        private bool hasPlayed = false;


        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MFAnimation.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                shelf2.SetActive(true);
                wallFixtures.SetActive(true);
                MFBlueprint.SetActive(true);
                MFStart.Play();
                hasPlayed = true;
               

            }
            else if (!MFStart.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                MFAnimation.SetActive(false);
                MFCanvas.SetActive(true);
                placement.SetActive(true);
                GetComponent<MidFloor>().enabled = false;

            }
        }

        
    }
}
