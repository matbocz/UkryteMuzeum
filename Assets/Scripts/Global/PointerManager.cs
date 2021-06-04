using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PointerManager : MonoBehaviour
{
    [Header("Pointer")]
    [SerializeField] private Image pointerImage;
    [SerializeField] private Sprite defaultPointer;
    [SerializeField] private Sprite selectPointer;

    [Space(10)]
    [SerializeField] private Vector3 defaultPointerScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private Vector3 selectPointerScale = new Vector3(2f, 2f, 2f);

    [Header("Raycast")]
    [SerializeField] private float raycastRange = 2f;

    RaycastHit raycastHit;

    private void Update()
    {
        SetRaycast();

        SetDefaultPointerImage();

        // Check if the ray hits any object
        if (raycastHit.transform != null)
        {
            // If the ray hits a specific object:
            // - change cursor
            // - let the user click on the object 
            if (raycastHit.transform.CompareTag("MuseumSecret") || raycastHit.transform.CompareTag("HiddenSecret") || raycastHit.transform.CompareTag("StartQuiz") || raycastHit.transform.CompareTag("PasswordClickObject"))
            {
                SetSelectPointerImage();

                HandleMouseClick();
            }
        }
    }

    private void SetRaycast()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raycast, out raycastHit, raycastRange);
    }

    private void HandleMouseClick()
    {
        // Check if the user clicked the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the user has not clicked on the UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                ActivateObject();
            }
        }
    }

    private void ActivateObject()
    {
        TutorialStateManager.instance.HideActiveTutorialOverlays();

        if (raycastHit.transform.CompareTag("MuseumSecret"))
        {
            SecretPickup secretPickup = raycastHit.transform.GetComponent<SecretPickup>();

            secretPickup.OpenSecretPanel();
            secretPickup.ReadDescription();
        }
        else if (raycastHit.transform.CompareTag("HiddenSecret"))
        {
            SecretPickup secretPickup = raycastHit.transform.GetComponent<SecretPickup>();

            secretPickup.OpenSecretPanel();
            secretPickup.ReadDescription();
            secretPickup.FindSecret();
        }
        else if (raycastHit.transform.CompareTag("PasswordClickObject"))
        {
            TutorialStateManager.instance.OpenPasswordInfoPanel();
        }
        else if (raycastHit.transform.CompareTag("StartQuiz"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void SetDefaultPointerImage()
    {
        pointerImage.sprite = defaultPointer;
        pointerImage.transform.localScale = defaultPointerScale;
    }

    private void SetSelectPointerImage()
    {
        pointerImage.sprite = selectPointer;
        pointerImage.transform.localScale = selectPointerScale;
    }
}
