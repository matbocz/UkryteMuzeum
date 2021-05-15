using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStateManager : MonoBehaviour
{
    [Header("Tutorial Start - Start Panel")]
    [SerializeField] private GameObject tutorialStartPanel;

    [Header("Tutorial Step 1 - Road to the muzeum")]
    [SerializeField] private GameObject tutorialPanel1;
    [SerializeField] private GameObject tutorialOverlay1;

    [Header("Tutorial Step 2 - Entrance to the museum")]
    [SerializeField] private GameObject tutorialPanel2;
    [SerializeField] private GameObject tutorialOverlay2;

    [Header("Tutorial Step 3 - Museum floor")]
    [SerializeField] private GameObject tutorialPanel3;
    [SerializeField] private GameObject[] lockedDoors = new GameObject[6];

    [Header("Tutorial End - Return to the museum")]
    [SerializeField] private GameObject passwordClickObject;
    [SerializeField] private GameObject passwordInfoPanel;
    [SerializeField] private GameObject tutorialEndPanel;
    [SerializeField] private GameObject tutorialEndOverlay;
    [SerializeField] private GameObject quizDoor;

    private GameObject[] tutorialOverlays = new GameObject[6];
    private GameObject[] activeTutorialOverlays = new GameObject[3];

    public static TutorialStateManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        OpenTutorialPanelStart();
    }

    private void OpenTutorialPanelStart()
    {
        // Wywołanie: Uruchomienie sceny

        // Otwórz panel początkowy
        tutorialStartPanel.SetActive(true);

        // Zatrzymaj grę
        GameStateManager.instance.StopGame();
    }

    public void CloseTutorialPanelStart()
    {
        // Wywołanie: Naciśnięcie przycisku - panel początkowy

        // Zamknij panel początkowy
        tutorialStartPanel.SetActive(false);

        // Wznów grę
        GameStateManager.instance.StartGame();
    }

    public void CloseTutorialPanel1()
    {
        // Wywołanie: Naciśnięcie przycisku - panel z informacją o ustawieniach sterowania

        // Zamknij panel z informacją o ustawieniach sterowania; pokaż informacje o konieczności pójścia dalej ścieżką
        tutorialPanel1.SetActive(false);
        tutorialOverlay1.SetActive(true);

        // Wznów grę
        GameStateManager.instance.StartGame();
    }

    public void CloseTutorialPanel2()
    {
        // Wywołanie: Naciśnięcie przycisku - panel z informacją o muzeum

        // Zamknij panel z informacją o muzeum i informacje o konieczności pójścia dalej ścieżką; pokaż informacje o konieczności wjechania windą w górę
        tutorialPanel2.SetActive(false);
        tutorialOverlay1.SetActive(false);
        tutorialOverlay2.SetActive(true);

        // Wznów grę
        GameStateManager.instance.StartGame();
    }

    public void CloseTutorialPanel3()
    {
        // Wywołanie: Naciśnięcie przycisku - panel z informacją o poszukiwaniach sekretów

        // Zamknij panel z informacją o poszukiwaniach sekretów i informacje o konieczności wjechania windą w górę
        tutorialPanel3.SetActive(false);
        tutorialOverlay2.SetActive(false);

        // Pokaż na ekranie ilość znalezionych sekretów i hasło
        HiddenSecretsManager.instance.ShowSecretsFoundUIText();
        HiddenSecretsManager.instance.ShowPasswordUIText();

        // Otwórz wszystkie zamknięte przejścia
        foreach (GameObject lockedDoor in lockedDoors)
        {
            lockedDoor.SetActive(false);
        }

        // Wznów grę
        GameStateManager.instance.StartGame();
    }

    public void ActivatePasswordClickObject()
    {
        // Wywołanie: Znalezienie wszystkich sekretów - skrypt HiddenSecretsManager

        // Aktywuj możliwość kliknięcia na hasło w labiryncie
        passwordClickObject.SetActive(true);
    }

    public void OpenPasswordInfoPanel()
    {
        // Wywołanie: Kliknięcie na hasło w muzeum - skrypt PointerManager

        // Ukryj ilość znalezionych sekretów, hasło i informacje o konieczności powrotu do muzeum
        HiddenSecretsManager.instance.CloseSecretsFoundUIText();
        HiddenSecretsManager.instance.ClosePasswordUIText();
        HiddenSecretsManager.instance.CloseInfoUIText();

        // Otwórz panel z informacją o haśle
        passwordInfoPanel.SetActive(true);

        // Zatrzymaj grę
        GameStateManager.instance.StopGame();
    }

    public void OpenTutorialEndPanel()
    {
        // Wywołanie: Naciśnięcie przycisku - panel z informacją o haśle

        // Zamknij panel z informacją o haśle
        passwordInfoPanel.SetActive(false);

        // Pokaż panel z ostatnim zadaniem
        tutorialEndPanel.SetActive(true);
    }

    public void CloseTutorialEndPanel()
    {
        // Wywołanie: Naciśnięcie przycisku - panel z ostatnim zadaniem

        // Zamknij panel z ostatnim zadaniem
        tutorialEndPanel.SetActive(false);

        // Pokaż informacje o konieczności znalezienia pomieszczenia z quizem i otwórz drzwi do pomieszczenia z quizem
        tutorialEndOverlay.SetActive(true);
        quizDoor.SetActive(true);

        // Wznów grę
        GameStateManager.instance.StartGame();
    }

    public void HideActiveTutorialOverlays()
    {
        // Zapisz wszystkie overlaye do tablicy: tutorialOverlays
        GetAllTutorialOverlays();

        // Znajdź wszystkie aktywne overlaye i zapisz je do tablicy: activeTutorialOverlays
        int i = 0;
        foreach (GameObject tutorialOverlay in tutorialOverlays)
        {
            if (tutorialOverlay.activeSelf == true)
            {
                activeTutorialOverlays[i] = tutorialOverlay;
                tutorialOverlay.SetActive(false);

                i++;
            }
        }
    }

    private void GetAllTutorialOverlays()
    {
        tutorialOverlays[0] = tutorialOverlay1;
        tutorialOverlays[1] = tutorialOverlay2;
        tutorialOverlays[2] = tutorialEndOverlay;
        tutorialOverlays[3] = HiddenSecretsManager.instance.secretsFoundUIText.gameObject;
        tutorialOverlays[4] = HiddenSecretsManager.instance.passwordUIText.gameObject;
        tutorialOverlays[5] = HiddenSecretsManager.instance.infoUIText.gameObject;
    }

    public void ShowActiveTutorialOverlays()
    {
        // Aktywuj wszystkie overlaye zapisane w tablicy: activeTutorialOverlays
        foreach (GameObject activeTutorialOverlay in activeTutorialOverlays)
        {
            try
            {
                activeTutorialOverlay.SetActive(true);
            }
            catch
            {
                continue;
            }
        }
    }
}