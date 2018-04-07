using UnityEngine;
namespace ca.codepanda
{

	public class References : Singleton<References> 
	{
		// Prevents the creator from being used
        protected References() { }

        public int state = 0;

        private const string _MAINCAMTAG = "MainCamera";
        private const string _MAPMANAGER = "MapManager";
        private const string _ITEMMANAGER = "ItemManager";
        private const string _CHARACTERMANAGER = "CharacterManager";
        private const string _DYNAMIC = "_Dynamic";
		private const string _GAMEMANAGER = "GameManager";

        // EXAMPLE FOR A PERSISTENT OBJECT
        //private SessionValue _Session = null;
        //public SessionValue _session
        //{
        //    get
        //    {
        //        if (_Session == null)
        //        {
        //            _Session = gameObject.AddComponent<SessionValue>();
        //        }
        //        return _Session;
        //    }
        //}

        private Camera _Camera = null;
        public Camera _camera
        {
            get
            {
                if (_Camera == null)
                {
                    GameObject go = GameObject.FindGameObjectWithTag(_MAINCAMTAG);
                    _Camera = go.GetComponent<Camera>();
                }
                return _Camera;
            }
        }

        private ScreenShake _ScreenShake = null;
        public ScreenShake _screenShake
        {
            get
            {
                if(_ScreenShake == null)
                {
                    GameObject go = _camera.gameObject;
                    _ScreenShake = go.GetComponent<ScreenShake>();
                }
                return _ScreenShake;
            }
        }

        private AudioSource _GuiAudio = null;
        public AudioSource _guiAudio
        {
            get
            {
                if (_GuiAudio == null)
                {
                    GameObject go = _camera.gameObject;
                    _GuiAudio = go.GetComponentInChildren<AudioSource>();
                }
                return _GuiAudio;
            }
        }

        private MapManager _MapManager = null;
        public MapManager _mapManager
        {
            get
            {
                GameObject go = GameObject.Find(_MAPMANAGER);
                _MapManager = go.GetComponent<MapManager>();
                return _MapManager;
            }
        }

        private ItemManager _ItemManager = null;
        public ItemManager _itemManager
        {
            get
            {
                GameObject go = GameObject.Find(_ITEMMANAGER);
                _ItemManager = go.GetComponent<ItemManager>();
                return _ItemManager;
            }
        }

        private CharactersManager _CharacterManager = null;
        public CharactersManager _characterManager
        {
            get
            {
                GameObject go = GameObject.Find(_CHARACTERMANAGER);
                _CharacterManager = go.GetComponent<CharactersManager>();
                return _CharacterManager;
            }
        }

        private Transform _Dynamic;
        public Transform _dynamic
        {
            get
            {
                GameObject go = GameObject.Find(_DYNAMIC);
                _Dynamic = go.transform;
                return _Dynamic;
            }
        }
		
		private GameManager _GameManager = null;
        public GameManager _gameManager
        {
            get
            {
                GameObject go = GameObject.Find(_GAMEMANAGER);
                _GameManager = go.GetComponent<GameManager>();
                return _GameManager;
            }
        }
    }
}
