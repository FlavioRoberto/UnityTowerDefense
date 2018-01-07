using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour {

	[SerializeField]
	private GameObject projetilPrefab;
	[SerializeField]
	private float tempoDeRecarga = 1f;
	[SerializeField]
	private float alcance;
	private float tempoUltimoDisparo;
	// Use this for initialization


	void Update(){
		Dispara ();
	}
	
	private void Dispara(){
		GameObject alvo = EscolheAlvo();
		if(alvo){
			float tempoAtual = Time.time;
			if (tempoAtual > tempoUltimoDisparo + tempoDeRecarga) {
				tempoUltimoDisparo = tempoAtual;
				//pega o game object responsável pela posição do ponto de disparo dentro do canhao
				GameObject pontoDeDisparo = this.transform.Find ("canhaoDaTorre/pontoDeDisparo").gameObject;
				//pega a posicao do gameobject
				Vector3 posicaoPontoDeDisparo = pontoDeDisparo.transform.position;
				//instancia o missel (prefab) na posicao do gameObject
				GameObject missilPrefab = Instantiate (projetilPrefab, posicaoPontoDeDisparo, Quaternion.identity);
				Missil missil = missilPrefab.GetComponent<Missil> ();
				missil.DefineAlvo (alvo);

			}
		}
	}

	private GameObject EscolheAlvo(){
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		foreach(GameObject alvo in inimigos){
			if(CalculaDistancia(alvo)){
				return alvo;
			}
		}
		return null;
	}

	private bool CalculaDistancia(GameObject inimigo){
		//pega a posicao de acordo com o plano
		Vector3 posicaoTorreNoPlano = Vector3.ProjectOnPlane(this.transform.position,Vector3.up);
		Vector3 posicaoInimigoNoPlano = Vector3.ProjectOnPlane (inimigo.transform.position,Vector3.up);
		return Vector3.Distance (posicaoTorreNoPlano, posicaoInimigoNoPlano) <= alcance;
	}
}
