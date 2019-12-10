﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contato : MonoBehaviour
{
    public bool ligado = false;

    //digo se esse contato será a fonte de energia
    public bool fonte = false;

    public bool finishPoint = false;
    //guardo os dois tipos de materiais, o dele ligado e desligado
    private static Material off;
    private static Material on;
    private static Material finish;

    public LevelChanger levelChanger;
    //cada contato pode estar ligado a apenas dois outros, um sera a provavel fonte e o outro o destino
    //obs, dessa forma nao tem como ligar 3 contatos, tem que modificar o codigo pra isso
    public List<Contato> contatos = new List<Contato>();
    
    
    
    void Start () {
        //guardo os materiais
        if (fonte){
            //o objeto fonte ja deve vir com o material que sera com ele ligado
            on = GetComponent<Renderer>().material;
        } else if (finishPoint){
            finish = GetComponent<Renderer>().material;
        } else if (off == null) {
            off = GetComponent<Renderer>().material;
        }

        levelChanger = FindObjectOfType<LevelChanger>();
    }


    void OnTriggerEnter(Collider other) {
        Contato contato = other.gameObject.GetComponent<Contato>();
        if (contato != null){
            //adiciona nos contatos
            contatos.Add(contato);

            //roda a verificacao de quem esta ligado
            runLiga();
        }
    }

    void OnTriggerExit(Collider other) {
        Contato contato = other.gameObject.GetComponent<Contato>();

        if (contato != null){
            //remove dos contatos
            contatos.Remove(contato);

            //roda a verificacao de quem esta ligado
            runLiga();
        }
    }


    public void runLiga(){


        GameObject[] cs = GameObject.FindGameObjectsWithTag("Contato");
        //seta todos os booleans para false
        foreach(GameObject c in cs){
            c.GetComponent<Contato>().ligado = false;
        }

        //verifica a partir da fonte, quem esta conectado
        Contato fonteObj = GameObject.FindGameObjectWithTag("Fonte").GetComponent<Contato>();
        turnBoolOn(fonteObj.contatos);

        //atualiza os materiais dos que estao conectados
        foreach(GameObject c in cs){
            c.GetComponent<Contato>().updateMaterial();
        }


    }

    public void turnBoolOn(List<Contato> conts) {
        foreach(Contato c in conts) {
            if (!c.ligado){
                c.ligado = true;
                turnBoolOn(c.contatos);
            }
            if (c.name.Equals("CrossEnd")) {
                Invoke("NextLevel", 0.2f);
            }
        }
    }

    void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void updateMaterial(){
        if (ligado){
            liga();
        } else {
            desliga();
        }
    }


    public void liga(){
        GetComponent<Renderer>().material = on;
        ligado = true;
    }

    public void desliga(){
        ligado = false;
        if(!finishPoint) {
            GetComponent<Renderer>().material = off;
        } else {
            GetComponent<Renderer>().material = finish;
        }
    }
}
