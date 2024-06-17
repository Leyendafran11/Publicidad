using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class publicidad : MonoBehaviour
{

	private UnityWebRequest www;
	private Texture2D image;
	private string[] anuncios;

	private void Start()
	{
		anuncios = new string[4];
		anuncios[2] = "https://images7.memedroid.com/images/UPLOADED663/5f32bf42a7941.jpeg";
		anuncios[1] = "https://steamuserimages-a.akamaihd.net/ugc/1788514894914590098/5CF47F4FCC7016500D9F79AD30AA3694D7F49FBD/?imw=637&imh=358&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true";
		anuncios[0] = "https://pbs.twimg.com/media/FIguN7fXEAEf3xT.jpg";
		anuncios[3] = "https://pbs.twimg.com/media/EdjaqVPXgAE6rRt.png:large";

		StartCoroutine(cargarPublicidad());

	}

	private IEnumerator cargarPublicidad()
	{

		int cont = 0;

		while (true)
		{
			www = UnityWebRequestTexture.GetTexture(anuncios[cont]);
			yield return www.SendWebRequest();

			if (www.result != UnityWebRequest.Result.ConnectionError)
			{
				image = DownloadHandlerTexture.GetContent(www);
				GetComponent<MeshRenderer>().material.mainTexture = image;
			}
			else
			{
			}


			yield return new WaitForSeconds(2.0f);

			cont++;
			if (cont > 3)
			{
				cont = 0;
			}
		}
	}

}
