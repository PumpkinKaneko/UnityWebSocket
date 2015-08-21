using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using WebSocketSharp;

public class WSManager : MonoBehaviour {

	private WebSocket ws;

	public Text MessageBoard;
	private string Message;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		this.MessageBoard.text = this.Message;
	}

	public void OnConnect() {
		this.ws = new WebSocket("ws://10.0.1.3:8080");
		this.ws.OnMessage += (object sender, MessageEventArgs e) => {
			this.Message = e.Data;
		};
		this.ws.Connect ();
	}

	public void OnSend() {
		this.ws.Send (System.DateTime.Now.ToString ());
	}

	public void OnClose() {
		this.ws.Close ();
	}
}