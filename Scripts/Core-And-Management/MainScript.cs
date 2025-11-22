
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class MainScript : MonoBehaviour
{
    //public GameObject StorePanelPort;
    public GameObject StorePanelLand;
    //public GameObject UpgradeStorePanelPort;
    public GameObject UpgradeStorePanelLand;
    public GameObject TipsPanel;
    public Transform Game_canvas;
    public Transform UI_canvas;
    public GameObject player;
    public GameObject triggerZone;
    public GameObject BackStoreUpgrade;
    public GameObject BackStore;
    public Transform Tails;
    public Text BestScore;
    //public Image[] Image;
    public Image[] ImageLand;
    //public Button[] Triple_Buttons; //graphics in settings
    public Button[] Triple_Buttons_Start; //graphics when starts
    public Button[] Triple_Buttons_Land;
    //public Text[] Triple_Text;
    public Text[] Triple_Text_Start;
    public Text[] Triple_Text_Land;
    //public Slider _Slider;
    //public Slider _SliderSounds;
    //public Slider _SliderMusic;
    public Slider _SliderLand;
    public Slider _SliderSoundsLand;
    public Slider _SliderMusicLand;
    public GameObject[] UI_Objects;

    public GameObject[] TextGravity = new GameObject[2];
    public GameObject[] SliderGravity = new GameObject[1];

    //public GameObject PortraitMenu;
    public GameObject LandscapeMenu;
    public GameObject BackgroundController;
    public GameObject GameplayController;

    private PostProcessVolume _PostProcessVolume;
    private Bloom _Bloom;
    private ColorGrading _ColorGrading;
    private ChromaticAberration _ChromaticAbberation;
    private Vignette _Vignette;
    private bool cameraCheckChanges;

    public AudioClip[] Soundtrack = new AudioClip[5];
    AudioSource audioSource;
    public AudioSource[] ButtonSound = new AudioSource[2];

    public GameObject tutorialZone;
    public GameObject tutorialText;


    void Awake()
    {
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 10000000);
        }
        if (!PlayerPrefs.HasKey("Gravi_Count"))
        {
            PlayerPrefs.SetInt("Gravi_Count", 10);
        }
        if (!PlayerPrefs.HasKey("Shields_Count"))
        {
            PlayerPrefs.SetInt("Shields_Count", 10);
        }
        if (!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetInt("Speed", 800);
        }
        if (!PlayerPrefs.HasKey("Acceleration"))
        {
            PlayerPrefs.SetFloat("Acceleration", 2f);
        }
        if (!PlayerPrefs.HasKey("MaxVelocity"))
        {
            PlayerPrefs.SetInt("MaxVelocity", 50);
        }
        if (!PlayerPrefs.HasKey("VerticalVelocity"))
        {
            PlayerPrefs.SetInt("VerticalVelocity", 10);
        }
        if (!PlayerPrefs.HasKey("Shield_Health"))
        {
            PlayerPrefs.SetInt("Shield_Health", 50);
        }
        if (!PlayerPrefs.HasKey("Gravi_Time"))
        {
            PlayerPrefs.SetInt("Gravi_Time", 5);
        }
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        if (!PlayerPrefs.HasKey("Ast_1"))
        {
            PlayerPrefs.SetInt("Ast_1", 145); //15
        }
        if (!PlayerPrefs.HasKey("Ast_2"))
        {
            PlayerPrefs.SetInt("Ast_2", 80); //10
        }
        if (!PlayerPrefs.HasKey("Ast_3"))
        {
            PlayerPrefs.SetInt("Ast_3", 30); //5
        }
        if (!PlayerPrefs.HasKey("Ast_4"))
        {
            PlayerPrefs.SetInt("Ast_4", 25); // 10
        }
        if (!PlayerPrefs.HasKey("Ast_5"))
        {
            PlayerPrefs.SetInt("Ast_5", 370); // 15
        }
        if (!PlayerPrefs.HasKey("Ast_6"))
        {
            PlayerPrefs.SetInt("Ast_6", 210); // 10
        }
        if (!PlayerPrefs.HasKey("Ast_7"))
        {
            PlayerPrefs.SetInt("Ast_7", 80);
        }
        if (!PlayerPrefs.HasKey("Ast_8"))
        {
            PlayerPrefs.SetInt("Ast_8", 85);
        }
        if (!PlayerPrefs.HasKey("Ast_9"))
        {
            PlayerPrefs.SetInt("Ast_9", 865);
        }
        if (!PlayerPrefs.HasKey("Ast_10"))
        {
            PlayerPrefs.SetInt("Ast_10", 475);
        }
        if (!PlayerPrefs.HasKey("Ast_11"))
        {
            PlayerPrefs.SetInt("Ast_11", 175);
        }
        if (!PlayerPrefs.HasKey("Ast_12"))
        {
            PlayerPrefs.SetInt("Ast_12", 10);
        }
        if (!PlayerPrefs.HasKey("CoinDoubler"))
        {
            PlayerPrefs.SetInt("CoinDoubler", 0);
        }
        if (!PlayerPrefs.HasKey("Premium"))
        {
            PlayerPrefs.SetInt("Premium", 0);
        }
        if (!PlayerPrefs.HasKey("Sounds"))
        {
            PlayerPrefs.SetFloat("Sounds", 1);
        }
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1);
        }
        if (!PlayerPrefs.HasKey("CameraDistance"))
        {
            PlayerPrefs.SetFloat("CameraDistance", 60f);
        }
        if (!PlayerPrefs.HasKey("GraphicsQuality"))
        {
            PlayerPrefs.SetInt("GraphicsQuality", 2);
        }
        if (!PlayerPrefs.HasKey("ChromaticAbberation"))
        {
            PlayerPrefs.SetInt("ChromaticAbberation", 1);
        }
        if (!PlayerPrefs.HasKey("LensFlare"))
        {
            PlayerPrefs.SetInt("LensFlare", 1);
        }
        if (!PlayerPrefs.HasKey("BlackBack"))
        {
            PlayerPrefs.SetInt("BlackBack", 0);
        }
        if (!PlayerPrefs.HasKey("ControlMode"))
        {
            PlayerPrefs.SetInt("ControlMode", 0);
        }
        if (!PlayerPrefs.HasKey("BrightStars"))
        {
            PlayerPrefs.SetInt("BrightStars", 0);
        }
        if (!PlayerPrefs.HasKey("PerformanceMode"))
        {
            PlayerPrefs.SetInt("PerformanceMode", 0);
        }
        if (!PlayerPrefs.HasKey("NumberObjects"))
        {
            PlayerPrefs.SetInt("NumberObjects", 1);
        }
        if (!PlayerPrefs.HasKey("DottedBorder"))
        {
            PlayerPrefs.SetInt("DottedBorder", 0);
        }
        if (!PlayerPrefs.HasKey("SimplifiedMode"))
        {
            PlayerPrefs.SetInt("SimplifiedMode", 0);
        }
        if (!PlayerPrefs.HasKey("HideInterface"))
        {
            PlayerPrefs.SetInt("HideInterface", 0);
        }
        if (!PlayerPrefs.HasKey("HideKM"))
        {
            PlayerPrefs.SetInt("HideKM", 1);
        }
        if (!PlayerPrefs.HasKey("GravityForce"))
        {
            PlayerPrefs.SetFloat("GravityForce", 1f);
        }
        if (!PlayerPrefs.HasKey("AsteroidTip"))
        {
            PlayerPrefs.SetInt("AsteroidTip", 1);
        }
        if (!PlayerPrefs.HasKey("StoreTip"))
        {
            PlayerPrefs.SetInt("StoreTip", 1);
        }

        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString() + " km";
        Time.timeScale = 0.65f;

        /*Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;*/

        
    }
    IEnumerator WaitForSongEnd()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        int ost = Random.Range(0, 5);
        audioSource.clip = Soundtrack[ost];
        audioSource.Play();
        StartCoroutine(WaitForSongEnd());
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int ost = Random.Range(0, 5);
        audioSource.clip = Soundtrack[ost];
        audioSource.Play();
        StartCoroutine(WaitForSongEnd());
        _PostProcessVolume = GetComponent<PostProcessVolume>();
        _PostProcessVolume.profile.TryGetSettings(out _Bloom);
        _PostProcessVolume.profile.TryGetSettings(out _ColorGrading);
        _PostProcessVolume.profile.TryGetSettings(out _Vignette);
        _PostProcessVolume.profile.TryGetSettings(out _ChromaticAbberation);

        //_Slider.value = PlayerPrefs.GetFloat("CameraDistance");
        _SliderLand.value = PlayerPrefs.GetFloat("CameraDistance");
        gameObject.GetComponent<Camera>().orthographicSize = PlayerPrefs.GetFloat("CameraDistance");
        _SliderLand.onValueChanged.AddListener((v) =>
        {
            PlayerPrefs.SetFloat("CameraDistance", v);
            gameObject.GetComponent<Camera>().orthographicSize = v;
            cameraCheckChanges = true;
        });

        _SliderMusicLand.value = PlayerPrefs.GetFloat("Music");
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
        _SliderMusicLand.onValueChanged.AddListener((v) =>
        {
            PlayerPrefs.SetFloat("Music", v);
            gameObject.GetComponent<AudioSource>().volume = v;
        });

        _SliderSoundsLand.value = PlayerPrefs.GetFloat("Sounds");
        _SliderSoundsLand.onValueChanged.AddListener((v) =>
        {
            PlayerPrefs.SetFloat("Sounds", v);
            ButtonSound[0].volume = v;
            ButtonSound[1].volume = v;
        });

        SliderGravity[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("GravityForce");
        SliderGravity[0].GetComponent<Slider>().onValueChanged.AddListener((v) =>
        {
            PlayerPrefs.SetFloat("GravityForce", v);
            GameplayController.GetComponent<GameObjectsCreator>().Gravity = v;
            TextGravity[1].GetComponent<Text>().text = "Gravity force: " + PlayerPrefs.GetFloat("GravityForce").ToString();
        });


        ButtonSound[0].volume = PlayerPrefs.GetFloat("Sounds");
        ButtonSound[1].volume = PlayerPrefs.GetFloat("Sounds");

        if (PlayerPrefs.GetInt("GraphicsQuality") == 0)
        {
            _Bloom.active = false;
            _ColorGrading.active = false;
            _Vignette.active = false;
            gameObject.GetComponent<Camera>().allowHDR = false;
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
            BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
            Triple_Text_Land[0].color = Color.black;
            Triple_Text_Land[1].color = Color.white;
            Triple_Text_Land[2].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("GraphicsQuality") == 1)
        {
            _Bloom.active = false;
            _ColorGrading.active = true;
            _Vignette.active = true;
            gameObject.GetComponent<Camera>().allowHDR = false;
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
            BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
            Triple_Text_Land[0].color = Color.white;
            Triple_Text_Land[1].color = Color.black;
            Triple_Text_Land[2].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("GraphicsQuality") == 2)
        {
            _Bloom.active = true;
            _ColorGrading.active = true;
            _Vignette.active = true;
            gameObject.GetComponent<Camera>().allowHDR = true;
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = true;
            BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 10;
            Triple_Text_Land[0].color = Color.white;
            Triple_Text_Land[1].color = Color.white;
            Triple_Text_Land[2].color = Color.black;
        }

        if (PlayerPrefs.GetInt("ControlMode") == 0)
        {
            Triple_Buttons_Land[3].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[4].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[5].GetComponent<Image>().enabled = false;
            Triple_Text_Land[3].color = Color.black;
            Triple_Text_Land[4].color = Color.white;
            Triple_Text_Land[5].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("ControlMode") == 1)
        {
            Triple_Buttons_Land[3].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[4].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[5].GetComponent<Image>().enabled = false;
            Triple_Text_Land[3].color = Color.white;
            Triple_Text_Land[4].color = Color.black;
            Triple_Text_Land[5].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("ControlMode") == 2)
        {
            Triple_Buttons_Land[3].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[4].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[5].GetComponent<Image>().enabled = true;
            Triple_Text_Land[3].color = Color.white;
            Triple_Text_Land[4].color = Color.white;
            Triple_Text_Land[5].color = Color.black;
        }

        if (PlayerPrefs.GetInt("NumberObjects") == 0)
        {
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 5;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 5;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 2;

            Triple_Buttons_Land[6].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[7].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[8].GetComponent<Image>().enabled = false;
            Triple_Text_Land[6].color = Color.black;
            Triple_Text_Land[7].color = Color.white;
            Triple_Text_Land[8].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("NumberObjects") == 1)
        {
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 10;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 10;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 5;

            Triple_Buttons_Land[6].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[7].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[8].GetComponent<Image>().enabled = false;
            Triple_Text_Land[6].color = Color.white;
            Triple_Text_Land[7].color = Color.black;
            Triple_Text_Land[8].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("NumberObjects") == 2)
        {
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 20;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 20;
            GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 7;
            GameplayController.GetComponent<GameObjectsCreator>().DelayBetweenSpawn = 0.1f;

            Triple_Buttons_Land[6].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[7].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[8].GetComponent<Image>().enabled = true;
            Triple_Text_Land[6].color = Color.white;
            Triple_Text_Land[7].color = Color.white;
            Triple_Text_Land[8].color = Color.black;
        }

        if (PlayerPrefs.GetInt("ChromaticAbberation") == 0)
        {
            _ChromaticAbberation.active = false;
            ImageLand[0].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("ChromaticAbberation") == 1)
        {
            _ChromaticAbberation.active = true;
            ImageLand[0].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("LensFlare") == 0)
        {
            _Bloom.dirtTexture.overrideState = false;
            ImageLand[1].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("LensFlare") == 1)
        {
            _Bloom.dirtTexture.overrideState = true;
            ImageLand[1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BlackBack") == 0)
        {
            ImageLand[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("BlackBack") == 1)
        {
            gameObject.GetComponent<Camera>().backgroundColor = new Color(0f / 255f, 0f / 255f, 0f / 255f);
            ImageLand[2].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BrightStars") == 0)
        {
            ImageLand[3].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("BrightStars") == 1)
        {
            ImageLand[3].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("PerformanceMode") == 0)
        {
            if (PlayerPrefs.GetInt("GraphicsQuality") == 0 || PlayerPrefs.GetInt("GraphicsQuality") == 1)
            {
                BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
            }
            else if (PlayerPrefs.GetInt("GraphicsQuality") == 2)
            {
                BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 10;
            }
            ImageLand[4].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PerformanceMode") == 1)
        {
            BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 0;
            ImageLand[4].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("DottedBorder") == 0)
        {
            ImageLand[5].gameObject.SetActive(false);
            Game_canvas.GetComponent<OrientaionChange>().DisableImages();
        }
        else if (PlayerPrefs.GetInt("DottedBorder") == 1)
        {
            ImageLand[5].gameObject.SetActive(true);
            Game_canvas.GetComponent<OrientaionChange>().ChangeOrientation();
        }

        if (PlayerPrefs.GetInt("SimplifiedMode") == 0)
        {
            ImageLand[6].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("SimplifiedMode") == 1)
        {
            ImageLand[6].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("HideInterface") == 0)
        {
            ImageLand[7].gameObject.SetActive(false);

            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -169.9004f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 1f;
            UI_Objects[0].GetComponent<Text>().color = color;

            var color_1 = UI_Objects[1].GetComponent<Text>().color;
            color_1.a = 1f;
            UI_Objects[1].GetComponent<Text>().color = color_1;

            var color_2 = UI_Objects[2].GetComponent<Text>().color;
            color_2.a = 1f;
            UI_Objects[2].GetComponent<Text>().color = color_2;

            var color_3 = UI_Objects[3].GetComponent<Text>().color;
            color_3.a = 1f;
            UI_Objects[3].GetComponent<Text>().color = color_3;

            var color_4 = UI_Objects[4].GetComponent<Image>().color;
            color_4.a = 1f;
            UI_Objects[4].GetComponent<Image>().color = color_4;

            var color_5 = UI_Objects[5].GetComponent<Image>().color;
            color_5.a = 1f;
            UI_Objects[5].GetComponent<Image>().color = color_5;
        }
        else if (PlayerPrefs.GetInt("HideInterface") == 1)
        {
            ImageLand[7].gameObject.SetActive(true);

            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -57f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 0f;
            UI_Objects[0].GetComponent<Text>().color = color;
            UI_Objects[0].GetComponent<Text>().enabled = false;

            var color_1 = UI_Objects[1].GetComponent<Text>().color;
            color_1.a = 0f;
            UI_Objects[1].GetComponent<Text>().color = color_1;

            var color_2 = UI_Objects[2].GetComponent<Text>().color;
            color_2.a = 0f;
            UI_Objects[2].GetComponent<Text>().color = color_2;

            var color_3 = UI_Objects[3].GetComponent<Text>().color;
            color_3.a = 0f;
            UI_Objects[3].GetComponent<Text>().color = color_3;

            var color_4 = UI_Objects[4].GetComponent<Image>().color;
            color_4.a = 0f;
            UI_Objects[4].GetComponent<Image>().color = color_4;

            var color_5 = UI_Objects[5].GetComponent<Image>().color;
            color_5.a = 0f;
            UI_Objects[5].GetComponent<Image>().color = color_5;
        }

        if (PlayerPrefs.GetInt("HideKM") == 0)
        {
            ImageLand[8].gameObject.SetActive(false);

            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -169.9004f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 1f;
            UI_Objects[0].GetComponent<Text>().color = color;
        }
        else if (PlayerPrefs.GetInt("HideKM") == 1)
        {
            ImageLand[8].gameObject.SetActive(true);

            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -57f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 0f;
            UI_Objects[0].GetComponent<Text>().color = color;
            UI_Objects[0].GetComponent<Text>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Tips") == 0)
        {
            GameplayController.SetActive(true);
            Destroy(tutorialZone);
            Destroy(tutorialText);
        }

        /*if (PlayerPrefs.GetInt("Premium") == 0)
        { 
            if (PlayerPrefs.GetInt("InterAd") >= 1500)
            {
                //triggerZone.SetActive(false);
                StartCoroutine(InterstitialAd());
                PlayerPrefs.SetInt("InterAd", 0);
            }
        }*/
    }

    /*IEnumerator InterstitialAd()
    {
        yield return new WaitForSeconds(0.1f);
        interAd.ShowAd();
    }*/

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GraphicsQualityLow()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 0);
        _Bloom.active = false;
        _ColorGrading.active = false;
        _Vignette.active = false;
        gameObject.GetComponent<Camera>().allowHDR = false;
        Triple_Buttons_Land[0].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
        Triple_Text_Land[0].color = Color.black;
        Triple_Text_Land[1].color = Color.white;
        Triple_Text_Land[2].color = Color.white;
    }
    public void GraphicsQualityLowStart()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 0);
        _Bloom.active = false;
        _ColorGrading.active = false;
        _Vignette.active = false;
        gameObject.GetComponent<Camera>().allowHDR = false;
        Triple_Buttons_Start[0].GetComponent<Image>().enabled = true;
        Triple_Buttons_Start[1].GetComponent<Image>().enabled = false;
        Triple_Buttons_Start[2].GetComponent<Image>().enabled = false;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
        Triple_Text_Start[0].color = Color.black;
        Triple_Text_Start[1].color = Color.white;
        Triple_Text_Start[2].color = Color.white;
    }

    public void GraphicsQualityMedium()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 1);
        _Bloom.active = false;
        _ColorGrading.active = true;
        _Vignette.active = true;
        gameObject.GetComponent<Camera>().allowHDR = false;
        Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[1].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
        Triple_Text_Land[0].color = Color.white;
        Triple_Text_Land[1].color = Color.black;
        Triple_Text_Land[2].color = Color.white;
    }
    public void GraphicsQualityMediumStart()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 1);
        _Bloom.active = false;
        _ColorGrading.active = true;
        _Vignette.active = true;
        gameObject.GetComponent<Camera>().allowHDR = false;
        Triple_Buttons_Start[0].GetComponent<Image>().enabled = false;
        Triple_Buttons_Start[1].GetComponent<Image>().enabled = true;
        Triple_Buttons_Start[2].GetComponent<Image>().enabled = false;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
        Triple_Text_Start[0].color = Color.white;
        Triple_Text_Start[1].color = Color.black;
        Triple_Text_Start[2].color = Color.white;
    }

    public void GraphicsQualityHigh()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 2);
        _Bloom.active = true;
        _ColorGrading.active = true;
        _Vignette.active = true;
        gameObject.GetComponent<Camera>().allowHDR = true;
        Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[2].GetComponent<Image>().enabled = true;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 10;
        Triple_Text_Land[0].color = Color.white;
        Triple_Text_Land[1].color = Color.white;
        Triple_Text_Land[2].color = Color.black;
    }
    public void GraphicsQualityHighStart()
    {
        PlayerPrefs.SetInt("GraphicsQuality", 2);
        _Bloom.active = true;
        _ColorGrading.active = true;
        _Vignette.active = true;
        gameObject.GetComponent<Camera>().allowHDR = true;
        Triple_Buttons_Start[0].GetComponent<Image>().enabled = false;
        Triple_Buttons_Start[1].GetComponent<Image>().enabled = false;
        Triple_Buttons_Start[2].GetComponent<Image>().enabled = true;
        BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 10;
        Triple_Text_Start[0].color = Color.white;
        Triple_Text_Start[1].color = Color.white;
        Triple_Text_Start[2].color = Color.black;
    }

    public void TapJoystick()
    {
        PlayerPrefs.SetInt("ControlMode", 0);

        Triple_Buttons_Land[3].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[4].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[5].GetComponent<Image>().enabled = false;
        Triple_Text_Land[3].color = Color.black;
        Triple_Text_Land[4].color = Color.white;
        Triple_Text_Land[5].color = Color.white;

        Game_canvas.GetComponent<OrientaionChange>().ChangeOrientation();
    }

    public void Slider()
    {
        PlayerPrefs.SetInt("ControlMode", 1);

        Triple_Buttons_Land[3].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[4].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[5].GetComponent<Image>().enabled = false;
        Triple_Text_Land[3].color = Color.white;
        Triple_Text_Land[4].color = Color.black;
        Triple_Text_Land[5].color = Color.white;

        Game_canvas.GetComponent<OrientaionChange>().ChangeOrientation();
    }

    public void Gyro()
    {
        PlayerPrefs.SetInt("ControlMode", 2);

        Triple_Buttons_Land[3].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[4].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[5].GetComponent<Image>().enabled = true;
        Triple_Text_Land[3].color = Color.white;
        Triple_Text_Land[4].color = Color.white;
        Triple_Text_Land[5].color = Color.black;

        Game_canvas.GetComponent<OrientaionChange>().ChangeOrientation();
    }

    public void Abberation()
    {
        //_ChromaticAbberation.active = !_ChromaticAbberation.active;
        if (PlayerPrefs.GetInt("ChromaticAbberation") == 0)
        {
            PlayerPrefs.SetInt("ChromaticAbberation", 1);
            _ChromaticAbberation.active = true;
            ImageLand[0].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ChromaticAbberation") == 1)
        {
            PlayerPrefs.SetInt("ChromaticAbberation", 0);
            _ChromaticAbberation.active = false;
            ImageLand[0].gameObject.SetActive(false);
        }
    }
    public void LensFlare()
    {
        if (PlayerPrefs.GetInt("LensFlare") == 0)
        {
            PlayerPrefs.SetInt("LensFlare", 1);
            _Bloom.dirtTexture.overrideState = true;
            ImageLand[1].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("LensFlare") == 1)
        {
            PlayerPrefs.SetInt("LensFlare", 0);
            _Bloom.dirtTexture.overrideState = false;
            ImageLand[1].gameObject.SetActive(false);
        }
    }

    public void BlackBack()
    {
        if (PlayerPrefs.GetInt("BlackBack") == 0)
        {
            PlayerPrefs.SetInt("BlackBack", 1);
            gameObject.GetComponent<Camera>().backgroundColor = new Color(0f / 255f, 0f / 255f, 0f / 255f);
            ImageLand[2].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("BlackBack") == 1)
        {
            PlayerPrefs.SetInt("BlackBack", 0);
            ImageLand[2].gameObject.SetActive(false);
        }
    }

    public void BrightStars()
    {
        if (PlayerPrefs.GetInt("BrightStars") == 0)
        {
            PlayerPrefs.SetInt("BrightStars", 1);
            ImageLand[3].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("BrightStars") == 1)
        {
            PlayerPrefs.SetInt("BrightStars", 0);
            ImageLand[3].gameObject.SetActive(false);
        }
    }

    public void PerformanceMode()
    {
        if (PlayerPrefs.GetInt("PerformanceMode") == 0)
        {
            PlayerPrefs.SetInt("PerformanceMode", 1);
            BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 0;
            ImageLand[4].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PerformanceMode") == 1)
        {
            PlayerPrefs.SetInt("PerformanceMode", 0);
            if (PlayerPrefs.GetInt("GraphicsQuality") == 0 || PlayerPrefs.GetInt("GraphicsQuality") == 1)
            {
                BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 5;
            }
            else if (PlayerPrefs.GetInt("GraphicsQuality") == 2)
            {
                BackgroundController.GetComponent<BackgroundCreator>().PresentAtOnceMist = 10;
            }
            ImageLand[4].gameObject.SetActive(false);
        }
    }
    public void NumberOfObjectsLow()
    {
        PlayerPrefs.SetInt("NumberObjects", 0);
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 5;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 5;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 2;

        Triple_Buttons_Land[6].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[7].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[8].GetComponent<Image>().enabled = false;
        Triple_Text_Land[6].color = Color.black;
        Triple_Text_Land[7].color = Color.white;
        Triple_Text_Land[8].color = Color.white;
    }
    public void NumberOfObjectsMedium()
    {
        PlayerPrefs.SetInt("NumberObjects", 1);
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 10;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 10;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 3;

        Triple_Buttons_Land[6].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[7].GetComponent<Image>().enabled = true;
        Triple_Buttons_Land[8].GetComponent<Image>().enabled = false;
        Triple_Text_Land[6].color = Color.white;
        Triple_Text_Land[7].color = Color.black;
        Triple_Text_Land[8].color = Color.white;
    }

    public void NumberOfObjectsHigh()
    {
        PlayerPrefs.SetInt("NumberObjects", 2);
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnce = 20;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOnceAst = 20;
        GameplayController.GetComponent<GameObjectsCreator>().PresentAtOncePlanet = 4;
        GameplayController.GetComponent<GameObjectsCreator>().DelayBetweenSpawn = 0.1f;

        Triple_Buttons_Land[6].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[7].GetComponent<Image>().enabled = false;
        Triple_Buttons_Land[8].GetComponent<Image>().enabled = true;
        Triple_Text_Land[6].color = Color.white;
        Triple_Text_Land[7].color = Color.white;
        Triple_Text_Land[8].color = Color.black;
    }

    public void DottedBorder()
    {
        if (PlayerPrefs.GetInt("DottedBorder") == 0)
        {
            PlayerPrefs.SetInt("DottedBorder", 1);
            ImageLand[5].gameObject.SetActive(true);
            Game_canvas.GetComponent<OrientaionChange>().ChangeOrientation();
        }
        else if (PlayerPrefs.GetInt("DottedBorder") == 1)
        {
            PlayerPrefs.SetInt("DottedBorder", 0);
            ImageLand[5].gameObject.SetActive(false);
            Game_canvas.GetComponent<OrientaionChange>().DisableImages();
        }
    }

    public void SimplifiedMode()
    {
        if (PlayerPrefs.GetInt("SimplifiedMode") == 0)
        {
            PlayerPrefs.SetInt("SimplifiedMode", 1);
            ImageLand[6].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("SimplifiedMode") == 1)
        {
            PlayerPrefs.SetInt("SimplifiedMode", 0);
            ImageLand[6].gameObject.SetActive(false);
        }
    }

    public void HideInterface()
    {
        if (PlayerPrefs.GetInt("HideInterface") == 0)
        {
            PlayerPrefs.SetInt("HideInterface", 1);
            ImageLand[7].gameObject.SetActive(true);
            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -57f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 0f;
            UI_Objects[0].GetComponent<Text>().color = color;

            var color_1 = UI_Objects[1].GetComponent<Text>().color;
            color_1.a = 0f;
            UI_Objects[1].GetComponent<Text>().color = color_1;

            var color_2 = UI_Objects[2].GetComponent<Text>().color;
            color_2.a = 0f;
            UI_Objects[2].GetComponent<Text>().color = color_2;

            var color_3 = UI_Objects[3].GetComponent<Text>().color;
            color_3.a = 0f;
            UI_Objects[3].GetComponent<Text>().color = color_3;

            var color_4 = UI_Objects[4].GetComponent<Image>().color;
            color_4.a = 0f;
            UI_Objects[4].GetComponent<Image>().color = color_4;

            var color_5 = UI_Objects[5].GetComponent<Image>().color;
            color_5.a = 0f;
            UI_Objects[5].GetComponent<Image>().color = color_5;
        }
        else if (PlayerPrefs.GetInt("HideInterface") == 1)
        {
            PlayerPrefs.SetInt("HideInterface", 0);
            ImageLand[7].gameObject.SetActive(false);
            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -169.9004f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 1f;
            UI_Objects[0].GetComponent<Text>().color = color;
            UI_Objects[0].GetComponent<Text>().enabled = true;

            var color_1 = UI_Objects[1].GetComponent<Text>().color;
            color_1.a = 1f;
            UI_Objects[1].GetComponent<Text>().color = color_1;

            var color_2 = UI_Objects[2].GetComponent<Text>().color;
            color_2.a = 1f;
            UI_Objects[2].GetComponent<Text>().color = color_2;

            var color_3 = UI_Objects[3].GetComponent<Text>().color;
            color_3.a = 1f;
            UI_Objects[3].GetComponent<Text>().color = color_3;

            var color_4 = UI_Objects[4].GetComponent<Image>().color;
            color_4.a = 1f;
            UI_Objects[4].GetComponent<Image>().color = color_4;

            var color_5 = UI_Objects[5].GetComponent<Image>().color;
            color_5.a = 1f;
            UI_Objects[5].GetComponent<Image>().color = color_5;
        }
    }

    public void HideKM()
    {
        if (PlayerPrefs.GetInt("HideKM") == 0)
        {
            PlayerPrefs.SetInt("HideKM", 1);
            ImageLand[8].gameObject.SetActive(true);
            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -57f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 0f;
            UI_Objects[0].GetComponent<Text>().color = color;
        }
        else if (PlayerPrefs.GetInt("HideKM") == 1)
        {
            PlayerPrefs.SetInt("HideKM", 0);
            ImageLand[8].gameObject.SetActive(false);
            var pos = UI_Objects[6].GetComponent<RectTransform>().anchoredPosition;
            pos.y = -169.9004f;
            UI_Objects[6].GetComponent<RectTransform>().anchoredPosition = pos;

            var color = UI_Objects[0].GetComponent<Text>().color;
            color.a = 1f;
            UI_Objects[0].GetComponent<Text>().color = color;
            UI_Objects[0].GetComponent<Text>().enabled = true;
        }
    }

    /*public void ChangeOrientation()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }*/

    public void MenuOrientation()
    {
        /*if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            if (PlayerPrefs.GetInt("Ast_9") <= 0 && PlayerPrefs.GetInt("Ast_10") <= 0 && PlayerPrefs.GetInt("Ast_11") <= 0)
            {
                TextGravity[0].SetActive(false);
                TextGravity[1].SetActive(true);
                SliderGravity[0].SetActive(true);
                SliderGravity[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("GravityForce");
                TextGravity[1].GetComponent<Text>().text = "Gravity force: " + PlayerPrefs.GetFloat("GravityForce").ToString();
            }
            PortraitMenu.gameObject.SetActive(true);
        }
        else
        {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            
        }*/
        if (PlayerPrefs.GetInt("Ast_9") <= 0 && PlayerPrefs.GetInt("Ast_10") <= 0 && PlayerPrefs.GetInt("Ast_11") <= 0)
        {
            TextGravity[0].SetActive(false);
            TextGravity[1].SetActive(true);
            SliderGravity[0].SetActive(true);
            SliderGravity[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("GravityForce");
            TextGravity[1].GetComponent<Text>().text = "Gravity force: " + PlayerPrefs.GetFloat("GravityForce").ToString();
        }
        LandscapeMenu.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("GraphicsQuality") == 0)
        {
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
            Triple_Text_Land[0].color = Color.black;
            Triple_Text_Land[1].color = Color.white;
            Triple_Text_Land[2].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("GraphicsQuality") == 1)
        {
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = true;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = false;
            Triple_Text_Land[0].color = Color.white;
            Triple_Text_Land[1].color = Color.black;
            Triple_Text_Land[2].color = Color.white;
        }
        else if (PlayerPrefs.GetInt("GraphicsQuality") == 2)
        {
            Triple_Buttons_Land[0].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[1].GetComponent<Image>().enabled = false;
            Triple_Buttons_Land[2].GetComponent<Image>().enabled = true;
            Triple_Text_Land[0].color = Color.white;
            Triple_Text_Land[1].color = Color.white;
            Triple_Text_Land[2].color = Color.black;
        }
    }

    public void CleanPlayer()
    {
        player.GetComponent<MeshRenderer>().enabled = false;
        Destroy(Tails.GetChild(0).gameObject);
        Destroy(Tails.GetChild(1).gameObject);
    }

    public void SetPlayer()
    {
        player.GetComponent<MeshRenderer>().enabled = true;
    }

    public void StoreAppear()
    {
        /*if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Instantiate(StorePanelPort, Game_canvas.transform);
        }
        else
        {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            
        }*/
        //BackStore.GetComponent<Animator>().Play("BackStore");

        Instantiate(StorePanelLand, Game_canvas.transform);

        if (PlayerPrefs.GetInt("Ast_1") <= 130)
        {
            GameObject.Find("ButtonAst_0").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (0)").SetActive(false);
            GameObject.Find("StartBack_0").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_1") <= 90 && PlayerPrefs.GetInt("Ast_2") <= 60)
        {
            GameObject.Find("ButtonAst_1").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (1)").SetActive(false);
            GameObject.Find("StartBack_1").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_1") <= 0 && PlayerPrefs.GetInt("Ast_2") <= 0 && PlayerPrefs.GetInt("Ast_3") <= 0)
        {
            GameObject.Find("ButtonAst_2").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (2)").SetActive(false);
            GameObject.Find("StartBack_2").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_4") <= 0)
        {
            GameObject.Find("ButtonAst_3").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (3)").SetActive(false);
            GameObject.Find("StartBack_3").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_5") <= 340)
        {
            GameObject.Find("ButtonAst_4").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (4)").SetActive(false);
            GameObject.Find("StartBack_4").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_5") <= 240 && PlayerPrefs.GetInt("Ast_6") <= 160)
        {
            GameObject.Find("ButtonAst_5").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (5)").SetActive(false);
            GameObject.Find("StartBack_5").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_5") <= 0 && PlayerPrefs.GetInt("Ast_6") <= 0 && PlayerPrefs.GetInt("Ast_7") <= 0)
        {
            GameObject.Find("ButtonAst_6").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (6)").SetActive(false);
            GameObject.Find("StartBack_6").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_8") <= 0)
        {
            GameObject.Find("ButtonAst_7").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (7)").SetActive(false);
            GameObject.Find("StartBack_7").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_9") <= 775)
        {
            GameObject.Find("ButtonAst_8").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (8)").SetActive(false);
            GameObject.Find("StartBack_8").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_9") <= 525 && PlayerPrefs.GetInt("Ast_10") <= 350)
        {
            GameObject.Find("ButtonAst_9").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (9)").SetActive(false);
            GameObject.Find("StartBack_9").SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ast_9") <= 0 && PlayerPrefs.GetInt("Ast_10") <= 0 && PlayerPrefs.GetInt("Ast_11") <= 0)
        {
            GameObject.Find("ButtonAst_10").GetComponent<Button>().interactable = true;
            GameObject.Find("Lock (10)").SetActive(false);
            GameObject.Find("StartBack_10").SetActive(false);
        }

        for (int i = 0; i <= 11; i++)
        {
            if (PlayerPrefs.GetInt("asteroidType") != i)
            {
                GameObject.Find("Frame_" + i).SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("AsteroidTip") == 1)
        {
            PlayerPrefs.SetInt("AsteroidTip", 0);
        }
        else if (PlayerPrefs.GetInt("AsteroidTip") == 0)
        {
            Destroy(GameObject.Find("AsteroidTip"));
        }
    }

    public void StoreDestroy()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Game_canvas.GetChild(2).GetComponent<Image>().enabled = false;
        Game_canvas.GetChild(2).GetComponent<Animator>().Play("StorePanelOut");
        BackStore.GetComponent<Animator>().Play("BackStoreOut");
        Destroy(Game_canvas.GetChild(2).gameObject, 0.4f);
        StartCoroutine(BackStoreButtn());
    }

    IEnumerator BackStoreButtn()
    {
        yield return new WaitForSeconds(0.2f);
        BackStore.SetActive(false);
    }

    public void UpgradeStoreAppear()
    {
        Instantiate(UpgradeStorePanelLand, UI_canvas.transform);
        /*if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Instantiate(UpgradeStorePanelPort, UI_canvas.transform);
        }
        else
        {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            
        }*/
        //BackStoreUpgrade.GetComponent<Animator>().Play("BackStore");
        if (PlayerPrefs.GetInt("StoreTip") == 1)
        {
            PlayerPrefs.SetInt("StoreTip", 0);
        }
        else if (PlayerPrefs.GetInt("StoreTip") == 0)
        {
            Destroy(GameObject.Find("StoreTip"));
        }
    }

    public void UpgradeStoreDestroy()
    {
        /*Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;*/
        //Game_canvas.GetChild(3).GetComponent<Image>().enabled = false;
        UI_canvas.GetChild(0).GetComponent<Animator>().Play("StoreUpgradesOut");
        BackStoreUpgrade.GetComponent<Animator>().Play("BackStoreOut");
        Destroy(UI_canvas.GetChild(0).gameObject, 0.4f);
        StartCoroutine(BackStoreButtnUpgrade());
    }
    IEnumerator BackStoreButtnUpgrade()
    {
        yield return new WaitForSeconds(0.2f);
        BackStoreUpgrade.SetActive(false);
    }
    /*public void SettingsDestroy()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        PortraitMenu.GetComponent<Animator>().Play("MenuPortOut");
        StartCoroutine(MenuPortOut());
    }*/
    public void SettingsDestroyLand()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        LandscapeMenu.GetComponent<Animator>().Play("MenuLandOut");
        StartCoroutine(MenuLandOut());
        if (cameraCheckChanges == true) {
            SceneManager.LoadScene(1);
            cameraCheckChanges = false;
        }
    }
    /*IEnumerator MenuPortOut()
    {
        yield return new WaitForSeconds(0.3f);
        PortraitMenu.SetActive(false);
    }*/

    IEnumerator MenuLandOut()
    {
        yield return new WaitForSeconds(0.3f);
        LandscapeMenu.SetActive(false);
    }

    public void TipsAppear()
    {
        Instantiate(TipsPanel);
    }
}
