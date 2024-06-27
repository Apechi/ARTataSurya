using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QNA> Qna;
    public GameObject[] options;
    public int currentQuestion;
    public int score = 0;
    public GameObject ScoreUI;  // add a public game object variable to hold the ScoreUI game object
    public Text Conter;
    public int x;

    public Text QuestionTxt;
    private void Start()
    {
        Shuffle(Qna); // Acak urutan soal pada list Qna
        if (Qna.Count > 10) // Jika jumlah soal lebih dari 10, hapus soal yang kelebihan
        {
            Qna.RemoveRange(10, Qna.Count - 10);
        }
        generateQuestion(); // Tampilkan soal pertama
        StartCoroutine(loading()); // Memulai coroutine loading untuk menampilkan hitungan mundur sebelum pertanyaan berganti
    }

    public void correct()
    {
        x=0;
        StopAllCoroutines();
        score += 10;  // add 10 to the score when the answer is correct
        Qna.RemoveAt(currentQuestion);
        if (Qna.Count > 0)  // check if there are more questions
        {   
            StartCoroutine(loading());    
            generateQuestion();  
        }
        else  // end the quiz if there are no more questions
        {
            endQuiz();
        }
        
    }

    public void wrong()
    {
        x=0;
        StopAllCoroutines();
        Qna.RemoveAt(currentQuestion);
        if (Qna.Count > 0)  // check if there are more questions
        {   
            StartCoroutine(loading());
            generateQuestion();
        }
        else  // end the quiz if there are no more questions
        {
            endQuiz();
        }
        
    }

    void SetAnswer()
    {
        ShuffleOptions(Qna[currentQuestion].Answers);
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = Qna[currentQuestion].Answers[i];

            if (Qna[currentQuestion].Answers[i] == Qna[currentQuestion].CorrectAnswer)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, Qna.Count);
        QuestionTxt.text = Qna[currentQuestion].Question;
        


        SetAnswer();

        
    }

    void endQuiz()
    {
        // activate the ScoreUI game object
        ScoreUI.SetActive(true);

        // display the score
        Text scoreText = ScoreUI.GetComponentInChildren<Text>();
        scoreText.text = "Nilai Anda: " + score;
    }

    private void Shuffle(List<QNA> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            QNA temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }


    //ripuh sikit
    private void ShuffleOptions(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            int randomIndex = Random.Range(i, options.Length);
            string temp = options[i];
            options[i] = options[randomIndex];
            options[randomIndex] = temp;
        }
    }

     IEnumerator loading()  //  <-  its a standalone method
        {
            x=10;
            do{
                Conter.text=x.ToString();
                yield return new WaitForSeconds(1);
                x--;
                if(x==0){
                    Conter.text="";
                }
            }while(x>0);
            Conter.text="";
            wrong();
        }

}