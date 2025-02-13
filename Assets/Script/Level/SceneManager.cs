using UnityEngine;


    public class SceneManager : MonoBehaviour
    {

        // Declare any public variables that you want to be able 
        // to access throughout your scene
        public _FrogController player;
        public UserInterfaceManager userInterfaceManager;
        public int Score;

        public static SceneManager Instance { get; private set; } // static singleton
        void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            // Cache references to all desired variables
            player = FindFirstObjectByType<_FrogController>();
            userInterfaceManager = FindFirstObjectByType<UserInterfaceManager>();
    }
    }
