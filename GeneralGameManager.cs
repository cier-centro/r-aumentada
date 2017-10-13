using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralGameManager : MonoBehaviour {

	public static GeneralGameManager instance = null;
	public static int score = 0; //TODO
	public static bool paper = false;
	public static bool hammer = false;
	public static bool gun = false;
	public static bool key = false;
	public static bool apple = false;
	public static int advance = 4;//20
	public static int preg = 3; //9

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void PutQuestion()
	{
		//ButtonQuest.put = false;
		string[] sentence;
		string[] buttonsD;
		switch (preg) 
		{
		case 1:
			//TODO Audio;
			sentence = new string[]{
				"Para que tu hermana se sienta escuchada debes responder:",
				"...se pelearon porque tú quieres ir a divertirte, mi mamá no quiere salir de la casa como siempre y mi hermano quiere ir al banco.",
				"...se pelearon porque tú quieres comprar unos audífonos, mi mamá quiere arreglarse el cabello y mi hermano debe ir al banco.",
				"...se pelearon porque mi hermano debe ir al banco, tú quieres ir a divertirte y mi mamá quiere arreglarse el cabello."
			};
			break;
		case 2:
			sentence = new string[]{
				"¿Cuál de los siguientes lugares de la ciudad escogerías para cumplir con los intereses de todos los familiares?",
				"En el cuadro 1 vemos: El casino-hotel. Hay bancos de varias entidades, una tienda tecnológica, un miniparque de diversiones y una tienda de cosméticos.",
				"En el cuadro 2 vemos: La plazoleta central de la ciudad. Hay una peluquería, una tienda tecnológica, un parque de diversiones y una papelería.",
				"En el cuadro 3 vemos: El centro comercial. Hay un parque de diversiones, una tienda tecnológica, una peluquería y bancos de distintas entidades."
			};
			break;
		case 3:
			sentence = new string[]{
				"De acuerdo con las normas del gobierno escolar ¿es correcta la sanción que el coordinador impone al estudiante?",
				"Sí, pues debe corregir los estudiantes más problemáticos.",
				"No, pues debe procurar el bienestar de todos los estudiantes.",
				"Sí, pues debe dar ejemplo a los demás estudiantes.",
				"No, pues debe respetar los deseos de todos los estudiantes."
			};
			break;
		case 4:
			sentence = new string[]{
				"Dos de las frases no suenen bien ¿Cuáles de éstas se contradicen?",
				"La de Chepe y la de Camilo.",
				"La de Camilo y la de María.",
				"La de Laura y la de María.",
				"La de Chepe y la de Laura."
			};
			break;
		case 5:
			sentence = new string[]{
				"De acuerdo con las normas del Gobierno estudiantil...¿Debería contarle la situación al personero? ¿Valdría la pena?",
				"Sí, porque entre sus funciones se encuentra llamar la atención a los profesores que se propasen.",
				"No, porque entre sus funciones solo se encuentra organizar jornadas de convivencia y recreación.",
				"Sí, porque entre de sus funciones se encuentra atender las peticiones de  los estudiantes.",
				"No, porque entre sus funciones solo se encuentra hacer cumplir lo que dicen las directivas del colegio."
			};
			break;
		case 6:
			sentence = new string[]{
				"¿A cuál de las siguientes instancias puede acudir el Personero para pasar la queja de los estudiantes?",
				"Al consejo de Estudiantes, porque éste puede de realizar un llamado de atención a los docentes.",
				"Al consejo académico, porque éste puede evaluar el desempeño de los docentes.",
				"Al Consejo Directivo, porque éste puede resolver llos problemas  relacionados con los docentes."
			};
			break;
		case 7:
			sentence = new string[]{
				"¡Ey! ¿Qué debes hacer ante esta situación?",
				"Expresar su acuerdo con el amigo de Niki porque molestar el profesor es la única forma de frenar la agresión a los estudiantes.",
				"Expresar su desacuerdo con el amigo de Niki porque esta forma de molestar el profesor es una manera de agredirlo.",
				"Guardar silencio porque cada quién decide la forma en que debe molestar al profesor para que se vaya del colegio."
			};
			break;
		case 8:
			sentence = new string[]{
				"Uch Parecía loco. ¿Es entendible que el profesor haya reaccionado de esta manera?",
				"Sí, porque esta acción hizo que él sintiera miedo  y temor.",
				"No, porque esta acción fue realizada por niños y él tiene que saber manejarlos",
				"Sí, porque esta acción hizo que él se sintiera ofendido y agredido.",
				"No, porque esta acción no es tan grave como para que él se sienta mal."
			};
			break;
		case 9:
			sentence = new string[]{
				"¿Con cuáles de los amigos puedes contar para jugar el partido?",
				"Hermana y Camilo.",
				"Niño nuevo y Maria",
				"Maria y Camilo",
				"Juan y Hermana"
			};
			break;
		case 10:
			sentence = new string[]{
				"De acuedo con las medidas tomadas por los reidentes del lugar ¿cuáles de los siguientes grupos tendrán que cancelar sus actividades?",
				"Los 1 y 2",
				"Los 1 y 3",
				"Los 2 y 4",
				"Los 2 y 3"
			};
			break;
		case 11:
			sentence = new string[]{
				"De acuerdo con la constitución colombiana:",
				"Su función principal es informar a los ciudadanos de las  medidas tomadas por el alcalde.",
				"Su función principal es organizar eventos culturales y recreativos par los habitantes del sector.",
				"Su función principal es recoger las quejas ciudadanas y comunicárselas al Alcalde.",
				"Su función principal es impulsar proyectos acordes con los planes comunitarios."
			};
			break;
		case 12:
			sentence = new string[]{
				"De acuerdo con nuestra constitución ¿Quién crees que tenga la razón?",
				"El líder comunitario, porque como representante del Alcalde el edil tiene la autoridad para prohibir lo que considere conveniente.",
				"Sandra, porque el grupo de niños tiene derecho a contar lo que está sucediendo a toda la comunidad.",
				"El líder comunitario, porque como representante del alcalde el edil tiene la función de hacer cumplir sus órdenes.",
				"Sandra, porque el grupo de niños tiene derecho a protestar contra lo que está sucediendo."
			};
			break;
		case 13:
			sentence = new string[]{
				"¿Qué amigo crees que tiene la razón?",
				"El Líder local, porque se sabe que hay personas favorecidas por la posición de sus padres.",
				"Maria, porque si van a decirles que se salgan de la pista hay que traer más gente por si se surge un conflicto.",
				"El Niño nuevo, porque si la policía que es la encargada de fomentar el orden no hace nada, ellos no deben involucrarse.",
				"La hermana, porque ellos deben procurar que sus compañeros de barrio cumplan los acuerdos."
			};
			break;
		case 14:
			//TODO Audio
			sentence = new string[]{
				"¿Estás escuchando? Te ves distraído. ¿Qué fue lo que dijo mi hermano?",
				"Que la obediencia de las normas permite a los insectos hacer grandes obras.",
				"Que la obediencia de las normas permite a los mosquitos hacer grandes obras.",
				"Que la obediencia de las normas permite a las abejas hacer grandes obras."
			};
			break;
		case 15:
			//TODO Audio
			sentence = new string[]{
				"¿En cuál de las siguientes formas NO le contestarías al hermano de Niki?",
				"Sí, tu padre y tú creen que están exentos de las normas.",
				"Sí, tu padre y tú creen que son como las abejas obreras.",
				"Sí, tu padre y tú creen que son los que hacen las normas.",
				"Sí, tu padre y tu creen que son como las abejas reina."
			};
			break;
		default :
			sentence = new string[]{
				"NP",
				"NP",
				"NP",
				"NP"
			};
			break;
		}

		buttonsD = new string[]{"OpcA", "OpcB", "OpcC", "OpcD"};
		if (GameObject.Find ("FeedBack(Clone)") == null) 
		{
			if (GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameManager> () != null)
				GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameManager> ().FeedBack ("");
			else if (GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<ClassroomGameManager> () != null)
				GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<ClassroomGameManager> ().FeedBack ("");
			else
				GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameManager_City> ().FeedBack ("");
		}
			

		GameObject.Find ("TextQuestion").gameObject.GetComponent<Text> ().text = sentence[0];
		
		for (int i = 1, k = sentence.Length ; i < k; i++) 
		{
			GameObject.Find (buttonsD[i-1]).gameObject.GetComponent<Button> ().interactable = true;
			GameObject.Find ("Text" + buttonsD[i-1]).gameObject.GetComponent<Text> ().text = sentence[i];
		}
	}

	public void QuestionDisable()
	{
		string[] buttonsD = {"OpcA", "OpcB", "OpcC", "OpcD"};
		//GameObject.Find ("Out").gameObject.GetComponent<Inventory> ().Appear (false);
		GameObject.Find ("TextQuestion").gameObject.GetComponent<Text> ().text = "";
		
		for (int i = 0; i < 4; i++) 
		{
			GameObject.Find (buttonsD[i]).gameObject.GetComponent<Button> ().interactable = false;
			GameObject.Find ("Text" + buttonsD[i]).gameObject.GetComponent<Text> ().text = "";
		}
	}

}
