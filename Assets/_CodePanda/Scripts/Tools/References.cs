using UnityEngine;
namespace ca.codepanda
{

	public class References : Singleton<References> 
	{
		// Prevents the creator from being used
        protected References() { }

        private const string _MAINCAMTAG = "MainCamera";

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
    }
}
