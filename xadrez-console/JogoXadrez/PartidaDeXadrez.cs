using JogoXadrez;
using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;

namespace xadrez_console.JogoXadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;

            ColocarPecas();
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 2).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 2).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 2).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).toPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).toPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 7).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 7).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 7).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).toPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).toPosicao());
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQdteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }
    }
}
