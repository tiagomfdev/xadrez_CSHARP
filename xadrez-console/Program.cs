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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                    partidaDeXadrez.ExecutaMovimento(origem, destino);
                }

                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
