using UnityEngine;

public class GrabHands : MonoBehaviour
{
    public enum Hands { left = 0, right = 1 };

    // Gesture recognition
    [SerializeField]
    Hands currentHand;

    // Save animations
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
        anim = GetComponent<Animator>();
    }

    void OnDestroy()
    {
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData handTrackerData)
    {
        bool active = false;
        bool press = false;

        foreach (nuitrack.UserHands userHands in handTrackerData.UsersHands)
        {
            if (currentHand == Hands.right && userHands.RightHand != null)
            {
                active = true;
                press = userHands.RightHand.Value.Click;

            }
            else if (currentHand == Hands.left && userHands.LeftHand != null)
            {
                active = true;
                press = userHands.LeftHand.Value.Click;
            }
        }
        anim.SetBool("isGrabbing", active && press ? true : false);
    }
}