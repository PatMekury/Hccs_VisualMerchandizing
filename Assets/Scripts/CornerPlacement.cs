using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class CornerPlacement : MonoBehaviour
    {
        public GameObject CornerAnimation;
        public GameObject MFAnimation;
        public Transform shelves;
        public GameObject theShelves;
        public GameObject FSCanvas;
        public GameObject placement;
        public AudioSource cornerAudio;
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
            if (CornerAnimation.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                cornerAudio.Play();
                hasPlayed = true;
                FSCanvas.SetActive(false);
                placement.SetActive(false);

                theShelves.SetActive(true);
                theShelves.transform.position = new Vector3(-51.70846f, -68.09712f, 20.28388f);
                theShelves.transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else if (!cornerAudio.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                CornerAnimation.SetActive(false);
                MFAnimation.SetActive(true);
                GetComponent<CornerPlacement>().enabled = false;
                
            }
        }
    }
}
