using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;

namespace JogoXadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            //acima esquerda
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna -1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            //acima direita
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }


            //abaixo esquerda
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            //abaixo direita
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }


            return mat;
        }
    }
}
