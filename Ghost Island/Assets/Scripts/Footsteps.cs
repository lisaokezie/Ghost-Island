using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Footsteps : MonoBehaviour
    {
        public List<GroundType> GroundTypes = new List<GroundType>();
        public FirstPersonController FPC;
        public string currentground;

        void Start()
        {
            setGroundType(GroundTypes[0]);
        }

        public void setGroundType(GroundType ground)
        {
            if (currentground != ground.name)
            {
                FPC.m_FootstepSounds = ground.footstepsounds;
                currentground = ground.name;
            }
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.tag == "Holz")
                setGroundType(GroundTypes[1]);
            else
                setGroundType(GroundTypes[0]);
        }
    }

    [System.Serializable]
    public class GroundType
    {
        public string name;
        public AudioClip[] footstepsounds;
   
    }
}