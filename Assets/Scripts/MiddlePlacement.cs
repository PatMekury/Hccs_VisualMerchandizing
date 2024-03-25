using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class MiddlePlacement : MonoBehaviour
    {
        public GameObject middleAnimation;
        public Transform shelves;
        public GameObject theShelves;
        public GameObject FSCanvas;
        public GameObject placement;
        public AudioSource middleAudio;
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
            if (middleAnimation.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                middleAudio.Play();
                hasPlayed = true;
                FSCanvas.SetActive(false);
                placement.SetActive(false);

                theShelves.SetActive(true);
                theShelves.transform.position = new Vector3(-50.257f, -68.09712f, 22.102f);
                theShelves.transform.rotation = Quaternion.Euler(0, 90, 0);

            }
            else if (!middleAudio.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playings
                animator.SetBool("IsTalking", false);
                FSCanvas.SetActive(true);
                placement.SetActive(true);
                middleAnimation.SetActive(false);
                hasPlayed = false;
                theShelves.SetActive(false);
                GetComponent<MiddlePlacement>().enabled = false;
            }
        }
    }
}
