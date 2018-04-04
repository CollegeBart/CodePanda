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

        private GameObject _Camera = null;
        public GameObject _camera
        {
            get
            {
                if (_Camera == null)
                {
                    _Camera = GameObject.FindGameObjectWithTag(_MAINCAMTAG);
                }
                return _Camera;
            }
        }

        private AudioSource _GuiAudio = null;
        public AudioSource _guiAudio
        {
            get
            {
                if (_GuiAudio == null)
                {
                    _GuiAudio = _camera.GetComponentInChildren<AudioSource>();
                }
                return _GuiAudio;
            }
        }
    }
}
