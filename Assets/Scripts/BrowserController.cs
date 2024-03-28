using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class BrowserController : MonoBehaviour
    {
        public GameObject m_PlayerObj; // The character object
        public Transform[] positionPoint; // The points the character will move towards
        public float timeToReachEnd; // The time it takes the player to reach the end of the path
        public bool isMoving = false;

        void Start()
        {
            // Assuming the character starts in an idle state
            m_PlayerObj.GetComponent<Animator>().SetBool("isWalking", false);
        }

        void Update()
        {
           if (isMoving)
            {
                MoveCharacter();
            } 
        }

        void MoveCharacter()
        {
            // Set the walking animation
            m_PlayerObj.GetComponent<Animator>().SetBool("isWalking", true);

            // Move the character along the path
            iTween.MoveTo(m_PlayerObj, iTween.Hash(
                "path", positionPoint,
                "time", timeToReachEnd,
                "easetype", iTween.EaseType.linear,
                "oncomplete", "OnComplete"
            ));
        }

        private void OnDrawGizmos()
        {
            iTween.DrawPath(positionPoint, Color.green);
        }

        void OnComplete()
        {
            // Set the idle animation when movement is complete
            m_PlayerObj.GetComponent<Animator>().SetBool("isWalking", false);
            
        }
    }
}
