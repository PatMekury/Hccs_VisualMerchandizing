using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class EntrancePlacement : MonoBehaviour
    {
        public GameObject entranceAnimationc;
        public Transform shelves;
        public GameObject theShelves;
        public GameObject FSCanvas;
        public GameObject placement;
        public AudioSource EnranceAudio;
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
            if (entranceAnimationc.activeSelf && !hasPlayed)
            {
                // Start the talking animation and audio when the IntroductionAnimation is activated
                animator.SetBool("IsTalking", true);
                EnranceAudio.Play();
                hasPlayed = true;
                FSCanvas.SetActive(false);
                placement.SetActive(false);

                theShelves.SetActive(true);
                theShelves.transform.position = new Vector3(-53.657f, -68.09712f, 19.199f);
                theShelves.transform.rotation = Quaternion.Euler(0, -90, 0);

            }
            else if (!EnranceAudio.isPlaying && hasPlayed)
            {
                // Switch back to idle animation when the audio stops playing
                animator.SetBool("IsTalking", false);
                FSCanvas.SetActive(true);
                placement.SetActive(true);
                entranceAnimationc.SetActive(false);
                hasPlayed = false;
                theShelves.SetActive(false);
                GetComponent<EntrancePlacement>().enabled = false;
            }

        }
    }
}
