using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;

namespace JogoXadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
