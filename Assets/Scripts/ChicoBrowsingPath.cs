using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class ChicoBrowsingPath : MonoBehaviour
    {
        public GameObject m_PlayerObj;
        public Transform[] positionPoint;
        [Range(0, 1)]
        public float value;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            iTween.PutOnPath(m_PlayerObj, positionPoint, value);
        }

        private void OnDrawGizmos()
        {
            iTween.DrawPath(positionPoint, Color.green);
        }
    }
}
