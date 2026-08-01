using MECHA;
using System.Collections;
using System.Text;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

namespace MECHA
{
	class DinosaurAI : MonoBehaviour
	{
		void Awake()
		{
			Global.alive = true;
			if (Global.hard) { Debug.Log("hardOn"); difficulty = 3; } else { Debug.Log("hardOff"); difficulty = 1; }
			dinovida = 3;
			x = 0;
			xdone = false;
			ydone = false;
			zdone = false;
			decider1 = 0;
			decider2 = 0;
			StartCoroutine(Roar());
		}


		[SerializeField] float dashtime;
		[SerializeField] float firetime;
		[SerializeField] float warningtime;
		[SerializeField] int stage1lives;
		[SerializeField] int stage2lives;
		[SerializeField] int stage3lives;

		[SerializeField] int decider1;
		[SerializeField] int decider2;
		[SerializeField] GameObject fire1;
		[SerializeField] GameObject fire2;
		[SerializeField] GameObject fire3;
		[SerializeField] GameObject fire4;
		[SerializeField] GameObject awarning1;
		[SerializeField] GameObject awarning2;
		[SerializeField] GameObject awarning3;
		[SerializeField] GameObject awarning4;

		[SerializeField] GameObject dinoheart1;
		[SerializeField] GameObject dinoheart2;
		[SerializeField] GameObject dinoheart3;
		[SerializeField] GameObject gamewin;
		[SerializeField] int dinovida;
		[SerializeField] int difficulty;
		[SerializeField] float x;
		[SerializeField] bool xdone;
		[SerializeField] bool ydone;
		[SerializeField] bool zdone;

		[SerializeField] GameObject spritedefault;
		[SerializeField] GameObject spriteroar;

		[SerializeField] AudioClip aa;
		[SerializeField] AudioSource ak;


		IEnumerator Attack()
		{
			Debug.Log("start fire");
			transform.position = new Vector3(0, 20, 0);
			yield return new WaitForSeconds(2f);
			Debug.Log("dash");
			for (int i = 0;  i <= 40; i++)
			{
				transform.position = transform.position + new Vector3(0, -1f, 0);
				yield return new WaitForSeconds(.1f);
			}
			x += 1;
			if (x == stage1lives && !xdone) { xdone = true; if (!Global.hard) { difficulty++; }; dinovida--; RoarScream(); dinoheart1.SetActive(false); }
			if (x == stage2lives && !ydone) { ydone = true; if (!Global.hard) { difficulty++; }; dinovida--; RoarScream(); dinoheart2.SetActive(false); }
			if (x == stage3lives && !zdone) { zdone = true; dinovida--; RoarScream(); dinoheart2.SetActive(false); gamewin.SetActive(true); Global.canhard = true; Global.alive = false; }
			yield return new WaitForSeconds(2f);
			transform.position = new Vector3(0, 0, 0);
			yield return new WaitForSeconds(3f);
			if (Global.alive) {StartCoroutine(Idle());}
			yield return null;
		}
		IEnumerator Idle()
		{
			Debug.Log("idle");
			if (difficulty == 1) { decider1 = Random.Range(1, 4); }
			if (difficulty == 2) { decider1 = Random.Range(1, 4); decider2 = Random.Range(1, 4); if (decider1 == decider2 && decider2 != 4) { decider2++; } else if (decider1 == decider2 && decider2 == 4) { decider2--; } }
			if (difficulty == 3) { decider1 = Random.Range(1, 4); }
			Debug.Log("start warning");
			if (difficulty == 1) switch (decider1) 
			{
			case 1: StartCoroutine(FireA()); break;
			case 2: StartCoroutine(FireB()); break;
			case 3: StartCoroutine(FireC()); break;
			case 4: StartCoroutine(FireD()); break;
			}
			if (difficulty == 2)
			{
				switch (decider1)
				{
					case 1: StartCoroutine(FireA()); break;
					case 2: StartCoroutine(FireB()); break;
					case 3: StartCoroutine(FireC()); break;
					case 4: StartCoroutine(FireD()); break;
				}
				switch (decider2)
				{
					case 1: StartCoroutine(FireA()); break;
					case 2: StartCoroutine(FireB()); break;
					case 3: StartCoroutine(FireC()); break;
					case 4: StartCoroutine(FireD()); break;
				}
			}
			if (difficulty == 3) switch (decider1)
			{
			case 1: StartCoroutine(FireB()); StartCoroutine(FireC()); StartCoroutine(FireD()); break;
			case 2: StartCoroutine(FireA()); StartCoroutine(FireC()); StartCoroutine(FireD()); break;
			case 3: StartCoroutine(FireA()); StartCoroutine(FireB()); StartCoroutine(FireD()); break;
			case 4: StartCoroutine(FireA()); StartCoroutine(FireB()); StartCoroutine(FireC()); break;
			}


			for (int i = 0; i <= 50; i++)
			{
				transform.position = transform.position + new Vector3(0, -.2f, 0);
				yield return new WaitForSeconds(.05f);
			}
			yield return new WaitForSeconds(1f);
			for (int i = 0; i <= 200; i++)
			{
				transform.position = transform.position + new Vector3(0, .2f, 0);
				yield return new WaitForSeconds(.05f);
			}
			if (Global.alive) {StartCoroutine(Attack());}
			yield return null;
		}


		IEnumerator FireA()
		{
			Debug.Log("Fire1");
			for (int i = 0; i <= 8; i++)
			{
				awarning1.SetActive(true);
				yield return new WaitForSeconds(warningtime/2);
				awarning1.SetActive(false);
				yield return new WaitForSeconds(warningtime/2);
			}
			fire1.SetActive(true);
			yield return new WaitForSeconds(8.5f);
			fire1.SetActive(false);
			yield return null;
		}

		IEnumerator FireB()
		{
			Debug.Log("Fire2");
			for (int i = 0; i <= 8; i++)
			{
				awarning2.SetActive(true);
				yield return new WaitForSeconds(warningtime/2);
				awarning2.SetActive(false);
				yield return new WaitForSeconds(warningtime/2);
			}
			fire2.SetActive(true);
			yield return new WaitForSeconds(8.5f);
			fire2.SetActive(false);
			yield return null;
		}

		IEnumerator FireC()
		{
			Debug.Log("Fire3");
			for (int i = 0; i <= 8; i++)
			{
				awarning3.SetActive(true);
				yield return new WaitForSeconds(warningtime/2);
				awarning3.SetActive(false);
				yield return new WaitForSeconds(warningtime/2);
			}
			fire3.SetActive(true);
			yield return new WaitForSeconds(8.5f);
			fire3.SetActive(false);
			yield return null;
		}

		IEnumerator FireD()
		{
			Debug.Log("Fire4");
			for (int i = 0; i <= 8; i++)
			{
				awarning4.SetActive(true);
				yield return new WaitForSeconds(warningtime/2);
				awarning4.SetActive(false);
				yield return new WaitForSeconds(warningtime/2);
			}
			fire4.SetActive(true);
			yield return new WaitForSeconds(8.5f);
			fire4.SetActive(false);
			yield return null;
		}


		IEnumerator Roar() 
		{
		Debug.Log("roar");
		spritedefault.SetActive(false);
		spriteroar.SetActive(true);
		RoarScream();
		yield return new WaitForSeconds(6.5f);
		spriteroar.SetActive(false);
		spritedefault.SetActive(true);
		if (Global.alive){StartCoroutine(Idle());}
		}
		void RoarScream()
		{
			ak.clip = aa;
			ak.Play();
		}
	}
}

