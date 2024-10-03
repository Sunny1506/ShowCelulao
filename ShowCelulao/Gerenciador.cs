namespace ShowCelulao
{
    public class Gerenciador
    {
        List<Questao> ListaTodasQuestoes = new List<Questao>();
        List<Questao> ListaTodasQuestoesRespondidas = new List<Questao>();
        public int Pontuacao { get; private set; }
        Label labelPontuacao;
        Label labelNivel;
        Questao QuestaoAtual;

        void AdicionaPontuacao(int n)
        {
            if (n == 1)
                Pontuacao = 1000;
            else if (n == 2)
                Pontuacao = 2000;
            else if (n == 3)
                Pontuacao = 5000;
            else if (n == 4)
                Pontuacao = 10000;
            else if (n == 5)
                Pontuacao = 20000;
            else if (n == 6)
                Pontuacao = 50000;
            else if (n == 7)
                Pontuacao = 10000;
            else if (n == 8)
                Pontuacao = 20000;
            else if (n == 9)
                Pontuacao = 500000;
            else if (n == 10)
                Pontuacao = 1000000;
        }
        public Questao GetQuestaoAtual()
        {
            return QuestaoAtual;
        }
        public void ProximaQuestao()
        {
            var ListaQuestoes = ListaTodasQuestoes.Where(d => d.Nivelresposta == NivelAtual).ToList();
            var numRandomico = Random.Shared.Next(0, ListaQuestoes.Count - 1);

            QuestaoAtual = ListaQuestoes[numRandomico];

            while (ListaTodasQuestoesRespondidas.Contains(QuestaoAtual))
            {
                numRandomico = Random.Shared.Next(0, ListaQuestoes.Count - 1);
                QuestaoAtual = ListaQuestoes[numRandomico];
            }

            ListaTodasQuestoesRespondidas.Add(QuestaoAtual);

            QuestaoAtual.Desenhar();
        }

        public async void VerfiicaCorreto(int RespostaSelecionada)
        {
            if (QuestaoAtual.VerificaResposta(RespostaSelecionada))
            {
                await Task.Delay(1500);
                if (NivelAtual == 10)
                {


                    await App.Current.MainPage.DisplayAlert("VOCÊ GANHOU 1 🌽🌽🌽🌽🌽🌽🌽!", "Parabéns!", "Ok");
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    AdicionaPontuacao(NivelAtual);
                    NivelAtual++;
                    ProximaQuestao();
                    labelPontuacao.Text = "Pontuação:R$" + Pontuacao.ToString();
                    labelNivel.Text = "Nível:" + NivelAtual.ToString();
                }



            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Você errou!", "Tente novamente", "Ok");
                Inicializar();
            }

        }


        int NivelAtual = 1;

        void Inicializar()
        {
            Pontuacao = 0;
            NivelAtual = 1;
            ListaTodasQuestoesRespondidas.Clear();
            ProximaQuestao();

        }
        public Gerenciador(Label labelpergunta, Button button1, Button button2, Button button3, Button button4, Button button5, Label labelPoint, Label labelNivel)
        {
            CriarQuestoes(labelpergunta, button1, button2, button3, button4, button5);
            labelPontuacao = labelPoint;
            this.labelNivel = labelNivel;

        }
         void CriarQuestoes(Label labelpergunta, Button button1, Button button2, Button button3, Button button4, Button button5)
         {
             var Q1 = new Questao();
            Q1.Nivelresposta = 1;
            Q1.Pergunta = "Qual é o planeta mais próximo do Sol?";
            Q1.Resposta01 = "Vênus";
            Q1.Resposta02 = "Marte";
            Q1.Resposta03 = "Júpiter";
            Q1.Resposta04 = "Mercúrio";
            Q1.Resposta05 = "Saturno";
            Q1.RespostaCorreta = 4;
            Q1.ConfiguraEstruturaDesenho(labelpergunta, button1, button2, button3, button4, button5);
            ListaTodasQuestoes.Add(Q1);

            var Q2 = new Questao();
            Q2.Nivelresposta = 2;
            Q2.Pergunta = "Quem escreveu 'Dom Quixote'?";
            Q2.Resposta01 = "William Shakespeare";
            Q2.Resposta02 = "Miguel de Cervantes";
            Q2.Resposta03 = "Gabriel García Márquez";
            Q2.Resposta04 = "Jorge Amado";
            Q2.Resposta05 = "Machado de Assis";
            Q2.RespostaCorreta = 2;
            Q2.ConfiguraEstruturaDesenho(labelpergunta, button1, button2, button3, button4, button5);
            ListaTodasQuestoes.Add(Q2);

            var Q3 = new Questao();
            Q3.Nivelresposta = 3;
            Q3.Pergunta = "Qual é a capital da Austrália?";
            Q3.Resposta01 = "Sydney";
            Q3.Resposta02 = "Melbourne";
            Q3.Resposta03 = "Canberra";
            Q3.Resposta04 = "Perth";
            Q3.Resposta05 = "Brisbane";
            Q3.RespostaCorreta = 3;
            Q3.ConfiguraEstruturaDesenho(labelpergunta, button1, button2, button3, button4, button5);
            ListaTodasQuestoes.Add(Q3);

            var Q4 = new Questao();
            Q4.Nivelresposta = 4;
            Q4.Pergunta = "Quem foi o primeiro presidente do Brasil?";
            Q4.Resposta01 = "Getúlio Vargas";
            Q4.Resposta02 = "Juscelino Kubitschek";
            Q4.Resposta03 = "Marechal Deodoro da Fonseca";
            Q4.Resposta04 = "Dom Pedro II";
            Q4.Resposta05 = "Epitácio Pessoa";
            Q4.RespostaCorreta = 3;
            Q4.ConfiguraEstruturaDesenho(labelpergunta, button1, button2, button3, button4, button5);
            ListaTodasQuestoes.Add(Q4);

            var Q5 = new Questao();
            Q5.Nivelresposta = 5;
            Q5.Pergunta = "Qual é a fórmula química da água?";
            Q5.Resposta01 = "H2O2";
            Q5.Resposta02 = "CO2";
            Q5.Resposta03 = "H2O";
            Q5.Resposta04 = "O2";
            Q5.Resposta05 = "CH4";
            Q5.RespostaCorreta = 3;
            Q5.ConfiguraEstruturaDesenho(labelpergunta, button1, button2, button3, button4, button5);
            ListaTodasQuestoes.Add(Q5);

            ProximaQuestao();

         }





    }


}
