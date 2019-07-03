using UnityEngine;

public class PauseMode : MonoBehaviour
{
    public GameObject PauseUIMenu, RightHand, LeftHand, AppHands, UIcamera, AppCamera;
    // Start is called before the first frame update
    void Start()
    {
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
    }

    void OnDestroy()
    {
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData handTrackerData)
    {
        foreach (nuitrack.UserHands userHands in handTrackerData.UsersHands)
        {
            if (userHands.RightHand != null && userHands.LeftHand != null)
            {
                if (userHands.RightHand.Value.Click && userHands.LeftHand.Value.Click)
                {

                    UIcamera.SetActive(true);
                    PauseUIMenu.SetActive(true);
                    RightHand.SetActive(true);
                    LeftHand.SetActive(true);

                    AppHands.SetActive(false);
                    AppCamera.SetActive(false);

                }
            }
            
        }
    }
}
