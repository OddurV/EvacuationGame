using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
	
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;            						// target to aim for
		public Transform backupTarget;
		bool m_Crouching = false;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
			if (target != null)
				agent.SetDestination (target.position);
			if (agent.remainingDistance > agent.stoppingDistance) {
				character.Move (agent.desiredVelocity, m_Crouching, false);
			} else {
				character.Move (Vector3.zero, m_Crouching, false);
			}
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

		public void SetBackupTarget(Transform target)
		{
			this.target = backupTarget;
		}

		void OnTriggerEnter(Collider other){
			if (other.tag == "Smoke") {
				m_Crouching = true;
			}
		}

		void OnTriggerStay(Collider other){
			if (other.tag == "Smoke") {
				m_Crouching = true;
			}
		}

		void OnTriggerExit(Collider other){
			if (other.tag == "Smoke") {
				m_Crouching = false;
			}
		}

    }
}