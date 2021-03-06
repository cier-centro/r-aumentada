﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonQuest : MonoBehaviour {

	public Button btn;
	public static bool put = false;

	void Start ()
	{
		btn = GetComponent<Button> ();
		btn.interactable = false;
	}

	public void Eval()
	{
		GameObject.FindGameObjectWithTag("General").gameObject.GetComponent<GeneralGameManager>().QuestionDisable();
		switch (GeneralGameManager.preg) 
		{
		case 1:
			if (this.name == "OpcA")
			{
				//TODO Audio
			}
			else if (this.name == "OpcB")
			{
				//TODO Audio
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 2:
			if (this.name == "OpcA")
			{
				//TODO Audio
			}
			else if (this.name == "OpcB")
			{
				//TODO Audio
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 3: 
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Es un deber de tu coordinador sancionar los estudiantes más problemáticos, pero esta sanción no puede atentar contra tu bienestar físico y mental o el de tus compañeros.");
			}
			else if (this.name == "OpcB")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcC")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Es un deber de tu coordinador prevenir que los estudiantes incumplan las normas, pero esta prevención no puede atentar contra tu bienestar físico y mental o el de tus compañeros.");
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Es un deber de tu coordinador proteger el bienestar físico y mental de los estudiantes, pero esto no significa que tú o tus compañeros estén exentos de las normas de tu manual de convivencia.");
			}
			break;
		case 4:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("No atentar contra tus derechos, y no atentar contra tu dignidad  obedecen  al mismo sentido de proteger tu bienestar físico y mental.");
			}
			else if (this.name == "OpcB")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcC")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Que seas sancionado en público y seas sancionado frente a otros obedece al mismo sentido de buscar una reprimenda en frente de todos los demás.");
			}
			else if (this.name == "OpcD")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 5:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Recuerda que entre las funciones de tu personero no se encuentra la de sancionar directamente los docentes.");
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Recuerda que tu personero además de organizar jornadas de convivencia tiene la función de representar tus intereses.");	
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Recuerda que tu personero además de contribuir al cumplimiento de las normas debe darle prioridad a los problemas de los estudiantes.");
			}
			break;
		case 6:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Recuerda que el consejo de estudiantes no puede realizar un llamado de atención directo a los docentes.");
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>().FeedBack("Es cierto que el consejo académico puede evaluar el desempeño de tus docentes pero ¿para qué te serviría en esta situación?");
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 7:
			if (this.name == "OpcA")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcB")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 8:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<ClassroomGameManager>().FeedBack("El profesor no mostrò signos de temor y miedo sino de rabia e indignación.");
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<ClassroomGameManager>().FeedBack("Las agresiones que tú realizas sobre los adultos también tienen consecuencias negativas ¡ponte en su lugar!");
			}
			else if (this.name == "OpcC")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<ClassroomGameManager>().FeedBack("Para ti puede parecer un juego, pero para tu profesor es decepcionante que tú lo agredas ¡ponte en su lugar!");
			}
			else if (this.name == "OpcD")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 9:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Como Andrea supone que ella no es nada buena en el fútbol y supone que ellos juegan mucho es probable que no quiera jugar.");
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Como Juan supone que ellos son tramposos es probable que no quiera jugar.");
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Como Andrea supone que no es buena jugando y Juan cree que ellos son gente tramposa es probable que ninguno de los dos juegue.");
			}
			break;
		case 10:
			if (this.name == "OpcA")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Los 3, no deben cancelar la apertura de los ensayaderos el lunes en la mañana.");
			}
			else if (this.name == "OpcC")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Los 2, no deben cerrar su actividad de la 1:00 p.m. en el parque el Rosal.");
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Los 3, no deben cancelar la apertura de los ensayaderos el lunes en la mañana. Y los 2, no deben cerrar su actividad de la 1:00 p.m. en el parque el Rosal.");
			}
			break;
		case 11:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Esta es una función de la junta de acción comunal.");
			}
			else if (this.name == "OpcB")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Esta es una función de la junta de acción comunal.");
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Esta es una función de la junta de acción comunal.");
			}
			break;
		case 12:
			if (this.name == "OpcA")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("El edil como todos los representantes del ejecutivo, está sujeto a las normas constitucionales.");
			}
			else if (this.name == "OpcB")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcC")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("El Alcalde como todos los representantes del ejecutivo, está sujeto a las normas constitucionales.");
			}
			else if (this.name == "OpcD")
			{
				ButtonQuest.put = false;
				GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager_City>().FeedBack("Aunque la constitución promulga el derecho a protestar el grupo de chicos busca es difundir la información.");
			}
			break;
		case 13:
			if (this.name == "OpcA")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcB")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			else if (this.name == "OpcD")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 14:
			if (this.name == "OpcA")
			{
				//TODO Audio
			}
			else if (this.name == "OpcB")
			{
				//TODO Audio
			}
			else if (this.name == "OpcC")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		case 15:
			if (this.name == "OpcA")
			{
				//TODO Audio
			}
			else if (this.name == "OpcB")
			{
				//TODO Audio
			}
			else if (this.name == "OpcC")
			{
				//TODO Audio
			}
			else if (this.name == "OpcD")
			{
				GeneralGameManager.preg++;
				GeneralGameManager.advance++;
			}
			break;
		}
	}
}
