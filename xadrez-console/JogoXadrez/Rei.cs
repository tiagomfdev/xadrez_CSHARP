using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;
using xadrez_console.JogoXadrez;

namespace JogoXadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez PartidaDeXadrez;

        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partidaDeXadrez) : base(cor, tabuleiro)
        {
            PartidaDeXadrez = partidaDeXadrez;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TorreHabilitadaParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdeMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            //acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //diagonal direita acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //direita
            posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //diagonal direita abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //diagonal esquerda abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //diagonal esquerda acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // #jogadaespecial roque
            if (QtdeMovimentos == 0 && !PartidaDeXadrez.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posicaoTorrePeq = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TorreHabilitadaParaRoque(posicaoTorrePeq))
                {
                    Posicao posicaoLivre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicaoLivre2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(posicaoLivre1) == null && Tabuleiro.Peca(posicaoLivre2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Posicao posicaoTorreGrd = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TorreHabilitadaParaRoque(posicaoTorreGrd))
                {
                    Posicao posicaoLivre1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicaoLivre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicaoLivre3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.Peca(posicaoLivre1) == null &&
                        Tabuleiro.Peca(posicaoLivre2) == null &&
                        Tabuleiro.Peca(posicaoLivre3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }

            }

            return mat;
        }
    }
}
