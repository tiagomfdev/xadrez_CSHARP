using Xadrez.Tabuleiro.Enums;
using Xadrez.Tabuleiro.Exceptions;

namespace Xadrez.Tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdeMovimentos = 0;
        }

        public void IncrementarQdteMovimentos()
        {
            QtdeMovimentos++;
        }

        public void DecrementarQdteMovimentos()
        {
            QtdeMovimentos--;
        }

        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public bool ExisteMoivimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            
            for(int linhas=0; linhas<Tabuleiro.Linhas; linhas++)
            {
                for (int colunas = 0; colunas < Tabuleiro.Colunas; colunas++)
                {
                    if (mat[linhas, colunas])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool MovimentoPossivel(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
        
    }
}
