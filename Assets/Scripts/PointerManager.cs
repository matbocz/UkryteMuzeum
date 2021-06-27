using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

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

    private RaycastHit raycastHit;
    private string[] selectTags;

    private void Start()
    {
        selectTags = new string[] { "MuseumSecret", "HiddenSecret", "StartQuiz", "PasswordClickObject" };
    }

    private void Update()
    {
        SetRaycast();

        SetDefaultPointerImage();

        if (raycastHit.transform != null)
        {
            if (selectTags.Contains(raycastHit.transform.tag))
            {
                SetSelectPointerImage();

                HandleActionButtonDown();
            }
        }
    }

    private void SetRaycast()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raycast, out raycastHit, raycastRange);
    }

    private void HandleActionButtonDown()
    {
        if (Input.GetButtonDown("Action"))
        {
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
