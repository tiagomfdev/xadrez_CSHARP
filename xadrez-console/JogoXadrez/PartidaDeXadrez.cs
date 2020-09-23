using JogoXadrez;
using System.Collections.Generic;
using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;
using Xadrez.Tabuleiro.Exceptions;

namespace xadrez_console.JogoXadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;

            Terminada = false;
            Xeque = false;

            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();

            ColocarPecas();
        }

        private Cor Adversaria(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);

            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecasEmJogo = new HashSet<Peca>();

            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    pecasEmJogo.Add(peca);
                }
            }

            return pecasEmJogo;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasCapturadas = new HashSet<Peca>();

            foreach (Peca peca in Capturadas)
            {
                if (peca.Cor == cor)
                {
                    pecasCapturadas.Add(peca);
                    Pecas.Remove(peca);
                }
            }

            return pecasCapturadas;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tabuleiro));

            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Tabuleiro));

            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tabuleiro));

            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Tabuleiro));

        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQdteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
                Pecas.Remove(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce nao pode se colocar em xeque!");
            }

            Xeque = EstaEmXeque(Adversaria(JogadorAtual));
            Terminada = EstaEmXequeMate(Adversaria(JogadorAtual));

            if (!Terminada)
            {
                Turno++;
                MudaJogador();
            }

        }

        public bool EstaEmXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                for (int linhas = 0; linhas < Tabuleiro.Linhas; linhas++)
                {
                    for (int colunas = 0; colunas < Tabuleiro.Colunas; colunas++)
                    {
                        if (mat[linhas, colunas])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(linhas, colunas);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.DecrementarQdteMovimentos();

            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
                Pecas.Add(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, origem);
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Nao existe peca na posicao de origem escolhida!");
            }

            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("A peca de origem escolhida nao eh sua!");
            }

            if (!Tabuleiro.Peca(posicao).ExisteMoivimentosPossiveis())
            {
                throw new TabuleiroException("Nao ha movimentos possiveis para a peca de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida!");
            }
        }

        public void MudaJogador()
        {
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
        }
    }
}
