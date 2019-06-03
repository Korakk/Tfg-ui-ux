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

    float dragSensitivity = 5f;

    private void Start()
    {
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
    }

    private void OnDestroy()
    {
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData handTrackerData)
    {
        bool active = false;
        bool press = false;
        bool clickDropdown = false;
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
            Dropdown newDropdown = null;
            Toggle newToggle = null;
            ScrollRect ddScrollRect = null;

            for (int q = 0; q < raycastResults.Count && newButton == null && newSlider == null && newDropdown == null && newToggle == null; q++)
            {
                newButton = raycastResults[q].gameObject.GetComponent<Button>();
                newSlider = raycastResults[q].gameObject.GetComponent<Slider>();
                newDropdown = raycastResults[q].gameObject.GetComponent<Dropdown>();
                newToggle = raycastResults[q].gameObject.GetComponent<Toggle>();
            }

            //Slider
            if (newSlider != selectedSlider)
            {
                Debug.Log("hola");
                if (selectedSlider != null)
                    selectedSlider.OnPointerExit(eventData);

                selectedSlider = newSlider;

                if (selectedSlider != null)
                    selectedSlider.OnPointerEnter(eventData);
            }

            else if (selectedSlider != null)
            {
                if (press)
                    selectedSlider.OnDrag(eventData);
            }

            //Dropdown
            if (newDropdown != selectedDropdown)
            {
                if (selectedDropdown != null)
                    selectedDropdown.OnPointerExit(eventData);

                selectedDropdown = newDropdown;

                if (selectedDropdown != null)
                    selectedDropdown.OnPointerEnter(eventData);
            }

            else if (selectedDropdown != null)
            {
                if (press && !clickDropdown)
                {
                    clickDropdown = true;
                    if (eventData.delta.sqrMagnitude < dragSensitivity)
                    {
                        Debug.Log("In");
                        eventData.dragging = true;
                        selectedDropdown.OnPointerDown(eventData);
                    }
                    selectedDropdown.OnPointerClick(eventData);
                }
                else if (eventData.dragging)
                {
                    eventData.dragging = false;
                    selectedDropdown.OnPointerUp(eventData);
                }

                if (press && clickDropdown)
                {
                    Debug.Log("Opened Dropdown");
                    GameObject DdList = GameObject.Find("Dropdown List");
                    Debug.Log(DdList.GetComponent<Canvas>().sortingOrder = 0);
                }
            }

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
                        Debug.Log("In");
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
            if (newDropdown != selectedButton)
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