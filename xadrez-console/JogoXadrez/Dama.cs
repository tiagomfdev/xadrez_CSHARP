﻿using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;

namespace JogoXadrez
{
    class Dama : Peca
    {

        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            //acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha - 1, posicao.Coluna);
            }

            //abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha + 1, posicao.Coluna);
            }

            //direita
            posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha, posicao.Coluna + 1);
            }

            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha, posicao.Coluna - 1);
            }


            //diagonal direita abaixo
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

            //diagonal esquerda abaixo
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

            //diagonal esquerda acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null)
                {
                    break;
                }

                posicao.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            //diagonal direita acima
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

            return mat;
        }
    }
}
