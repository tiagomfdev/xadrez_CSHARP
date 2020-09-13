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
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);
                Console.WriteLine(pos.toPosicao());
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
