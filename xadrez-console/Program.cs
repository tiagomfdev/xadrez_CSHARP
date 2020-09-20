using Game.Tela;
using JogoXadrez;
using System;
using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;
using Xadrez.Tabuleiro.Exceptions;
using xadrez_console.JogoXadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();


                while (!partidaDeXadrez.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                        partidaDeXadrez.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);

                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                        partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);

                        partidaDeXadrez.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
