using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandsTracker : MonoBehaviour
{
    public enum Hands { left = 0, right = 1 };

    [SerializeField]
    Hands currentHand;

    [Header("Visualization")]
    [SerializeField]
    RectTransform baseRect;
    [SerializeField]
    Image background;

    [SerializeField]
    Sprite defaultSprite;

    [SerializeField]
    Sprite pressSprite;

    [Header("Raycasting")]

    [SerializeField]
    Camera cam;

    Button selectedButton;
    Slider selectedSlider;
    Dropdown selectedDropdown;
    Toggle selectedToggle;

    PointerEventData eventData = new PointerEventData(null);
    List<RaycastResult> raycastResults = new List<RaycastResult>();

    public float TimeLeft = 1.0f;

    private float _currentTimeLeft;

    float dragSensitivity = 5f;

    private void Start()
    {
        _currentTimeLeft = TimeLeft;
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
    }

    private void OnDestroy()
    {
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData handTrackerData)
    {
        _currentTimeLeft -= Time.deltaTime;



        bool active = false;
        bool press = false;
        foreach (nuitrack.UserHands userHands in handTrackerData.UsersHands)
        {
            if (currentHand == Hands.right && userHands.RightHand != null)
            {
                baseRect.anchoredPosition = new Vector2(userHands.RightHand.Value.X * Screen.width, -userHands.RightHand.Value.Y * Screen.height);
                active = true;
                press = userHands.RightHand.Value.Click;
            }
            else if (currentHand == Hands.left && userHands.LeftHand != null)
            {
                baseRect.anchoredPosition = new Vector2(userHands.LeftHand.Value.X * Screen.width, -userHands.LeftHand.Value.Y * Screen.height);
                active = true;
                press = userHands.LeftHand.Value.Click;
            }
            background.enabled = active;
            background.sprite = active && press ? pressSprite : defaultSprite;

            if (!active)
                return;

            Vector2 pointOnScreenPosition = cam.WorldToScreenPoint(transform.position);
            eventData.delta = pointOnScreenPosition - eventData.position;
            eventData.position = pointOnScreenPosition;

            raycastResults.Clear();// clear the raycasting results from the previous frame


            EventSystem.current.RaycastAll(eventData, raycastResults);

            Button newButton = null;
            Slider newSlider = null;
            Toggle newToggle = null;

            for (int q = 0; q < raycastResults.Count && newButton == null && newSlider == null && newToggle == null; q++)
            {
                newButton = raycastResults[q].gameObject.GetComponent<Button>();
                newToggle = raycastResults[q].gameObject.GetComponent<Toggle>();
            }

            if (_currentTimeLeft < 0)
            {
                _currentTimeLeft = TimeLeft;

                //Toogle
                if (newToggle != selectedToggle)
                {
                    if (selectedToggle != null)
                        selectedToggle.OnPointerExit(eventData);

                    selectedToggle = newToggle;

                    if (selectedToggle != null)
                        selectedToggle.OnPointerEnter(eventData);
                }

                else if (selectedToggle != null)
                {
                    if (press)
                    {
                        if (eventData.delta.sqrMagnitude < dragSensitivity)
                        {
                            Debug.Log("ToggleIn");
                            eventData.dragging = true;
                            selectedToggle.OnPointerDown(eventData);
                        }
                        selectedToggle.OnPointerClick(eventData);
                    }
                    else if (eventData.dragging)
                    {
                        eventData.dragging = false;
                        selectedToggle.OnPointerUp(eventData);
                    }
                }

                //Button
                if (newButton != selectedButton)
                {
                    if (selectedButton != null)
                        selectedButton.OnPointerExit(eventData);

                    selectedButton = newButton;

                    if (selectedButton != null)
                        selectedButton.OnPointerEnter(eventData);
                }

                else if (selectedButton != null)
                {
                    if (press)
                    {

                        if (eventData.delta.sqrMagnitude < dragSensitivity)
                        {
                            Debug.Log("In");
                            eventData.dragging = true;
                            selectedButton.OnPointerDown(eventData);
                        }
                        selectedButton.OnPointerClick(eventData);
                    }
                    else if (eventData.dragging)
                    {
                        eventData.dragging = false;
                        selectedButton.OnPointerUp(eventData);
                    }
                }
            }
        }
    }
}