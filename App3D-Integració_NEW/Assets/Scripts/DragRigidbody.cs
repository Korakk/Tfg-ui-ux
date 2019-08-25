using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class DragRigidbody : MonoBehaviour
    {
        private Animator animator;

        private bool grabObj = false;
        private GameObject hitObj;

        private void Start()
        {
            animator = GetComponent<Animator>();    
        }

        private void Update()
        {
            var mainCamera = FindCamera();

            RaycastHit hit = new RaycastHit();

            Vector2 pointOnScreenPosition = mainCamera.WorldToScreenPoint(transform.position);
            pointOnScreenPosition = new Vector2(pointOnScreenPosition.x, 
                Screen.currentResolution.height - pointOnScreenPosition.y);

            if (!animator.GetBool("isGrabbing") && grabObj == true)
            {
                grabObj = false;
                hitObj.GetComponent<Rigidbody>().useGravity = true;
            }

            if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                if (!hit.rigidbody || hit.rigidbody.isKinematic)
                    return;

                if (hit.collider.gameObject && animator.GetBool("isGrabbing") && grabObj == false)
                {
                    hitObj = hit.collider.gameObject;
                    hitObj.GetComponent<Rigidbody>().useGravity = false;
                    grabObj = true;
                }
            }

            if (grabObj)
                hitObj.transform.position = new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y, 
                    (float)(gameObject.transform.position.z + 0.3));
        }

        private Camera FindCamera()
        {
            if (GetComponent<Camera>())
            {
                return GetComponent<Camera>();
            }

            return Camera.main;
        }
    }
}