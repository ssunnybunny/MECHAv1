using UnityEngine;
using UnityEngine.SceneManagement;

namespace MECHA.GUI
{
	public class MenuButtons : MonoBehaviour
	{
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) { Debug.Log("HardModeEnabled"); Global.canhard = true; hardbutton.SetActive(true); }
            if (Input.GetKeyDown(KeyCode.P)) { if (Global.hard) Debug.Log("HardModeOn"); }
        }
        void Start() { if (Global.canhard) {hardbutton.SetActive(true);} if(Global.seenstart){ starttxt.SetActive(false);}}

		[SerializeField] GameObject starttxt;
		public void StartText() 
		{
			starttxt.SetActive(false);
			Global.seenstart = true;
		}

		[SerializeField] GameObject fakestart;
		[SerializeField] GameObject fakestart2;

		public void FakeStart() 
		{
			fakestart.SetActive(false);
			fakestart2.SetActive(true);
		}

		public void StartButton()
		{
			SceneManager.LoadScene("Map");
			//Global.FirstSceneLoaded = false;
			//StartCoroutine(FirstLoadingScreen());
		}

		public void MenuScene() 
		{
			SceneManager.LoadScene("Menu");
		}


		public void LoadButton(){ }
		[SerializeField] public AudioClip asa;
		public AudioSource ask;
		public void soma()
		{
			ask.clip = asa;
			ask.PlayOneShot(asa);
		}
		public bool aaaaa;
		public void SettingsButton()
		{
			if (!aaaaa) { a.SetActive(true); aaaaa = true; }
			else { a.SetActive(false); aaaaa = false; }

		}

		public void LeaveButton()
		{
			Application.Quit();
		}

		[SerializeField] GameObject a;
		[SerializeField] GameObject e1;
		[SerializeField] GameObject e12;
		[SerializeField] GameObject e2;
		[SerializeField] GameObject e3;
		[SerializeField] GameObject e4;
		[SerializeField] GameObject et;

		public void engbt()
		{
			e1.SetActive(true);
			e2.SetActive(true);
			e3.SetActive(true);
			e4.SetActive(true);
			e12.SetActive(true);
			et.SetActive(true);
			p1.SetActive(false);
			p2.SetActive(false);
			p3.SetActive(false);
			p4.SetActive(false);
			p12.SetActive(false);
			pt.SetActive(false);
		}

		[SerializeField] GameObject p1;
		[SerializeField] GameObject p12;
		[SerializeField] GameObject p2;
		[SerializeField] GameObject p3;
		[SerializeField] GameObject p4;
		[SerializeField] GameObject pt;

		public void ptbt()
		{
			e1.SetActive(false);
			e2.SetActive(false);
			e3.SetActive(false);
			e4.SetActive(false);
			e12.SetActive(false);
			et.SetActive(false);
			p1.SetActive(true);
			p2.SetActive(true);
			p3.SetActive(true);
			p4.SetActive(true);
			p12.SetActive(true);
			pt.SetActive(true);
		}

        [SerializeField] GameObject hardbutton;
        [SerializeField] GameObject inferno;
        [SerializeField] GameObject hardctive;
        [SerializeField] GameObject harddective;

        public void hardactive()
        {
            if (Global.canhard && !Global.hard) { Global.hard = true; inferno.SetActive(true); Debug.Log("b"); hardctive.SetActive(false); harddective.SetActive(true); }
        }
        public void harddeactive()
        {
            if (Global.canhard && Global.hard) { Global.hard = false; inferno.SetActive(false); Debug.Log("a"); harddective.SetActive(false); hardctive.SetActive(true); }
        }

        public void PrintA() { Debug.Log("LogA"); }
        public void PrintB() { Debug.Log("LogB"); }

    }
}